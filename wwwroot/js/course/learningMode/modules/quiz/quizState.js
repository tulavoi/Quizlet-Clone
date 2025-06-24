import { getAllQuestions } from '../questions.js';

// ==============================
// Biến trạng thái
// ==============================
let questions = [];
let stepSize = [];

let courseId = 0;
let stepIndex = 0;
let questionIndexInStep = 0;
let questionStartIndexOfStep = 0;
let questionIndexInQuestions = 0;
let totalCorrectAnswers = 0;

let correctAnswersPerStep = [];

// ==============================
// Khởi tạo Quiz
// ==============================
export function initQuizState() {
    questions = getAllQuestions();
    stepSize = generateStepSize();
    courseId = window.quizData.courseId;

    questionIndexInQuestions = window.quizData.learningProgress.currentQuestionIndex;
    totalCorrectAnswers = window.quizData.learningProgress.correctAnswerCount;

    updateStepState();
}

// Cập nhật các chỉ số liên quan đến step hiện tại, dựa vào questionIndexInQuestions
function updateStepState() {
    let accumulated = 0;
    for (let i = 0; i < stepSize.length; i++) {
        const nextAccumulated = accumulated + stepSize[i];

        // Nếu câu hỏi hiện tại nằm trong khoảng của step i
        if (questionIndexInQuestions < nextAccumulated) {
            stepIndex = i;
            questionStartIndexOfStep = accumulated;
            questionIndexInStep = questionIndexInQuestions - accumulated;
            return;
        }
        accumulated = nextAccumulated; // Chuyển sang step kế tiếp
    }

    // Đã vượt quá step cuối cùng
    stepIndex = stepSize.length;
    questionStartIndexOfStep = accumulated;
    questionIndexInStep = 0;
}

// ==============================
// Getter
// ==============================
export function getData() {
    return {
        courseId: getCourseId(),
        correctAnswerCount: getTotalCorrectAnswers(),
        currentQuestionIndex: questionStartIndexOfStep + questionIndexInStep,
        correctAnswersPerStep: JSON.stringify(correctAnswersPerStep),
    };
}

export function getCourseId() {
    return courseId;
}

export function getNumCorrectAnswersPerStep() {
    correctAnswersPerStep = window.quizData.learningProgress.correctAnswersPerStep || [];
    return correctAnswersPerStep[getStepIndex()] || 0;
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

export function increaseNumCorrectAnswersPerStep() {
    correctAnswersPerStep[getStepIndex()] = (correctAnswersPerStep[getStepIndex()] || 0) + 1;
}

export function increaseStep() {
    questionStartIndexOfStep += stepSize[stepIndex];
    stepIndex++;
    resetCurrentQuestionIndex();
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