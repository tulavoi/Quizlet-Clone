import { getAllQuestions } from '../questions.js';

const courseId = window.quizData.courseId;

const questions = getAllQuestions();
const stepSize = generateStepSize();

// Lấy chỉ số câu hỏi hiện tại từ quizData, index của câu hỏi trong questions[]
let questionIndexInQuestions = window.quizData.learningProgress.currentQuestionIndex;
let totalCorrectAnswers = window.quizData.learningProgress.correctAnswerCount;

// Index của câu hỏi trong 1 step
let questionIndexInStep = 0;

let questionStartIndexOfStep = 0;       // Vị trí bắt đầu của step hiện tại trong mảng questions
let stepIndex = 0;                      // Step hiện tại trong bộ câu hỏi
let numCorrectAnswersInStep = 0;        // Số câu trả lời đúng trong mỗi step

// Hàm này phải nằm trong hàm khởi tạo
export function updateStepIndexFromCurrentQestionIndex() {
    let accumulatedSize = 0;
    for (let i = 0; i < stepSize.length; i++) {
        accumulatedSize += stepSize[i];
        if (questionIndexInQuestions < accumulatedSize) {
            stepIndex = i;
            break;
        }
    }

    questionStartIndexOfStep = stepSize.slice(0, stepIndex).reduce((sum, val) => sum + val, 0);

    // Nếu bạn cần biết vị trí câu hỏi trong step hiện tại:
    questionIndexInStep = questionIndexInQuestions - questionStartIndexOfStep;

    console.log("stepCorrectCount :", getNumCorrectAnswersInStep());
    console.log("stepIndex:", stepIndex);
    console.log("stepStartIndex:", questionStartIndexOfStep);
    console.log("questionIndexInStep:", questionIndexInStep);
}

// ==============================
// Getter
// ==============================
export function getData() {
    const courseId = getCourseId();
    const correctAnswerCount = getTotalCorrectAnswers();
    const currentQuestionIndex = questionStartIndexOfStep + questionIndexInStep;
    return { courseId, correctAnswerCount, currentQuestionIndex };
}

export function getCourseId() {
    return courseId;
}

export function getNumCorrectAnswersInStep() {
    // Nếu tổng số câu đúng hiện tại nhỏ hơn số câu trong step hiện tại
    // → Có thể hiểu là user đang ở step đầu tiên, hoặc chưa làm đủ để vượt qua step hiện tại
    if (getTotalCorrectAnswers() < stepSize[getStepIndex()])
        numCorrectAnswersInStep = getTotalCorrectAnswers(); // Gán luôn toàn bộ số đúng hiện tại

    else
        // Ngược lại: tổng đúng lớn hơn số câu trong step hiện tại
        // → Giả định rằng user đã làm xong các step trước rồi, nên số đúng trong step này
        // = Tổng số đúng - số câu của step hiện tại
        numCorrectAnswersInStep = getTotalCorrectAnswers() - stepSize[getStepIndex()];

    // Trả về số câu đúng trong step hiện tại
    return numCorrectAnswersInStep;
}

export function getCurrentQuestion() {
    return questions[questionStartIndexOfStep + questionIndexInStep];
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

export function getQuestionIndexInStep() {
    return questionIndexInStep;
}

export function getQuestionPerStep(index) {
    return stepSize[index];
}

// ==============================
// Increase Functions
// ==============================

function increaseCurrQuestionIndex() {
    questionIndexInStep++;
}

export function increaseStepCorrectCount() {
    numCorrectAnswersInStep++;
}

export function increaseStep() {
    questionStartIndexOfStep += stepSize[stepIndex];
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
    numCorrectAnswersInStep = 0;
}

function resetCurrentQuestionIndex() {
    questionIndexInStep = 0;
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