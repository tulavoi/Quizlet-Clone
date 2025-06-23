
import {
    getStepIndex,
    getTotalCorrectAnswers,
    getQuestionPerStep,
    getNumCorrectAnswersPerStep,
    increaseTotalCorrectAnswers,
    increaseNumCorrectAnswersPerStep,
} from '../../quiz/quizState.js';

let stepIndex = 0;

export function updateProgress(progress, isAnsweredCorrect) {
    stepIndex = getStepIndex();
    let questionPerStep = getQuestionPerStep(stepIndex);

    const progressIndicator = progress.querySelector('.progress-indicator');
    const progressNumber = progress.querySelector('#totalCorrectAnswers');
    const progressSteps = progress.querySelectorAll('.progress-step');
    const progressBadge = progressIndicator.querySelector('.progress-badge');

    // Nếu không có step hiện tại thì không làm gì cả
    if (!progressSteps[stepIndex]) return;

    // Nếu trả lời sai đổi màu sắc của step và badge, không cập nhật số lượng câu trả lời đúng
    if (!isAnsweredCorrect) {
        markIncorrect(progressSteps[stepIndex], progressBadge);
        return;
    }

    increaseNumCorrectAnswersPerStep();
    increaseTotalCorrectAnswers();

    const percentage = calculatePercentage(getNumCorrectAnswersPerStep(), questionPerStep);
    updateProgressIndicator(progressIndicator, progressNumber, percentage);
    updateProgressStep(progressSteps[stepIndex], percentage);
}

// Có thể sửa lại hàm này
export function resetIncorrectState() {
    const progressSteps = document.querySelectorAll('.progress-step');
    const progressBadge = document.querySelector('.progress-badge');

    progressSteps[stepIndex].classList.remove('in-correct');
    progressBadge.classList.remove('in-correct');
}

function markIncorrect(step, badge) {
    step.classList.add('in-correct');
    badge.classList.add('in-correct');
}

// TODO: Refactor code
export function updateCurrentStepProgress() {
    stepIndex = getStepIndex();
    let questionPerStep = getQuestionPerStep(stepIndex);
    const percentage = calculatePercentage(getNumCorrectAnswersPerStep(), questionPerStep);
    const progress = document.querySelector('#learningProgress');
    const progressSteps = progress.querySelectorAll('.progress-step');
    const progressIndicator = progress.querySelector('.progress-indicator');
    const progressNumber = progress.querySelector('#totalCorrectAnswers');

    updateProgressIndicator(progressIndicator, progressNumber, percentage);
    updateProgressStep(progressSteps[stepIndex], percentage);
}

// Cập nhật màu sắc của thanh step dựa trên tỷ lệ phần trăm đã hoàn thành
export function updateProgressStep(step, percentage) {
    if (step) {
        step.style.setProperty('--progress-fill', `calc(${percentage}%)`);
    }
}

// Hàm di chuyển indicator đến đúng vị trí trong thanh step và cập nhật số lượng câu trả lời đúng
export function updateProgressIndicator(indicator, numberElement, percentage) {
    if (!numberElement || !indicator) return;

    numberElement.textContent = getTotalCorrectAnswers();
    indicator.style.setProperty('--progress-indicator-0', `${percentage}%`);
    indicator.style.setProperty('--progress-indicator-1', `translateX(calc(-1% * ${percentage}))`);
}

export function calculatePercentage(current, total) {
    return current != 0 ? Math.min((current / total) * 100, 100) : 0;
}

export function fillStepProgress(progress, currStepIndex) {
    return new Promise(resolve => {
        const progressSteps = progress.querySelectorAll('.progress-step');
        updateProgressStep(progressSteps[currStepIndex], 100);
        setTimeout(resolve, 120);
    });
}

export function moveIndicatorToEnd(progress) {
    return new Promise(resolve => {
        const indicator = progress.querySelector('.progress-indicator');
        const progressNumber = progress.querySelector('#totalCorrectAnswers');

        updateProgressIndicator(indicator, progressNumber, 100);
        setTimeout(resolve, 120);
    });
}

export function moveIndicatorToNextStep() {
    stepIndex = getStepIndex();
    const progress = document.querySelector('#learningProgress');
    if (!progress) return;

    const progressSteps = progress.querySelectorAll('.progress-step');
    const indicator = progress.querySelector('.progress-indicator');
    const progressNumber = progress.querySelector('#totalCorrectAnswers');

    updateProgressIndicator(indicator, progressNumber, 0);
    if (progressSteps[stepIndex]) {
        progressSteps[stepIndex].appendChild(indicator);
    }
}