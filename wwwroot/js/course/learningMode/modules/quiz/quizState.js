import { getAllQuestions } from '../questions.js';

const courseId = window.quizData.courseId;

const questions = getAllQuestions();
const stepSize = generateStepSize();

let currQuestionIndex = 0;
let stepStartIndex = 0;                 // Vị trí bắt đầu của step hiện tại trong mảng questions
let stepIndex = 0;                      // Biến này đại diện cho đang ở step nào trong bộ câu hỏi
let totalCorrectAnswers = 0;            // Biến này đại diện cho số câu trả lời đúng của user trong học phần
let stepCorrectCount = 0;               // Biến đại diện cho số câu trả lời đúng trong mỗi step

// ==============================
// Getter
// ==============================
export function getData() {
    const courseId = getCourseId();
    const correctAnswerCount = getTotalCorrectAnswers();
    const currentQuestionIndex = getCurrentQuestionIndex();
    return { courseId, correctAnswerCount, currentQuestionIndex };
}

export function getCourseId() {
    return courseId;
}

export function getStepCorrectCount() {
    return stepCorrectCount;
}

export function getCurrentQuestion() {
    return questions[stepStartIndex + currQuestionIndex];
}

export function getTotalCorrectAnswers() {
    return totalCorrectAnswers;
}

export function getStepIndex() {
    return stepIndex;
}

export function getStepSize() {
    return stepSize;
}

export function getTotalQuestionCount() {
    return questions.length;
}

export function getCurrentQuestionIndex() {
    return currQuestionIndex;
}

export function getQuestionPerStep(index) {
    return stepSize[index];
}

// ==============================
// Increase Functions
// ==============================

function increaseCurrQuestionIndex() {
    currQuestionIndex++;
}

export function increaseStepCorrectCount() {
    stepCorrectCount++;
}

export function increaseStep() {
    stepStartIndex += stepSize[stepIndex];
    stepIndex++;
    resetCurrentQuestionIndex();
    resetStepCorrectCount();
}

export function increaseTotalCorrectAnswers() {
    totalCorrectAnswers++;
}

// ==============================
// Logic cập nhật trạng thái
// ==============================

export function nextQuestion() {
    increaseCurrQuestionIndex();
}

function resetStepCorrectCount() {
    stepCorrectCount = 0;
}

function resetCurrentQuestionIndex() {
    currQuestionIndex = 0;
}

function generateStepSize() {
    const numberOfQuestions = getTotalQuestionCount();

    // Các số lượng question/step được ưu tiên thử nghiệm
    const preferredPerStep = [5, 6, 7];
    var stepDistribution = [];

    // Trường hợp nếu số câu hỏi <= 14, chia làm 2 phần gần bằng nhau
    if (numberOfQuestions <= 14) {
        // Chia đều thành 2 phần
        const part1 = Math.ceil(numberOfQuestions / 2);
        const part2 = numberOfQuestions - part1;
        stepDistribution = [part1, part2];
    } else {
        // Tìm giá trị chia đều nhất trong preferredPerStep (tức là dư ít nhất)
        let bestPerStep = preferredPerStep[0];
        let minRemainder = numberOfQuestions;

        for (let perStep of preferredPerStep) {
            const remainder = numberOfQuestions % perStep;
            if (remainder < minRemainder) {
                bestPerStep = perStep;
                minRemainder = remainder;
                if (remainder === 0) break; // Nếu chia hết thì không cần tìm tiếp
            }
        }

        const steps = Math.floor(numberOfQuestions / bestPerStep);     // Số step
        const remainder = numberOfQuestions % bestPerStep;             // Phần dư cần phân phối

        // Duyệt qua số bước, phân phối phần dư vào các bước đầu
        for (let i = 0; i < steps; i++) {
            // Các bước đầu sẽ được cộng thêm 1 nếu vẫn còn dư
            stepDistribution.push(bestPerStep + (i < remainder ? 1 : 0));
        }
    }
    return stepDistribution;
}