
import { getStepIndex, getCorrectCount, getQuestionPerStep } from '../../quiz/quizState.js';

let stepIndex = getStepIndex();
let correctCount = getCorrectCount();
let questionPerStep = getQuestionPerStep(stepIndex);

export function updateProgress(progress, isAnsweredCorrect) {
    const progressIndicator = progress.querySelector('.progress-indicator');
    const progressNumber = progress.querySelector('.progress-number');
    const progressSteps = progress.querySelectorAll('.progress-step');
    const progressBadge = progressIndicator.querySelector('.progress-badge');

    // Nếu trả lời sai
    if (!isAnsweredCorrect) {
        markIncorrect(progressSteps[stepIndex], progressBadge);
        return;
    }

    const percentage = calculatePercentage(++correctCount, questionPerStep);
    updateBagde(progressIndicator, progressNumber, percentage);
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

function updateProgressStep(step, percentage) {
    step.style.setProperty('--progress-fill', `calc(${percentage}% + .3rem)`);
}

function updateBagde(indicator, numberElement, percentage) {
    numberElement.textContent = correctCount;
    indicator.style.setProperty('--progress-indicator-0', `${percentage}%`);
    indicator.style.setProperty('--progress-indicator-1', `translateX(calc(-1% * ${percentage}))`);
}

function calculatePercentage(current, total) {
    return Math.min((current / total) * 100, 100)
}