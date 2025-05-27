
import {
    getStepIndex,
    getTotalCorrectAnswers,
    getQuestionPerStep,
    getStepCorrectCount,
    increaseTotalCorrectAnswers,
    increaseStepCorrectCount,
} from '../../quiz/quizState.js';

let stepIndex = 0;

export function updateProgress(progress, isAnsweredCorrect) {
    stepIndex = getStepIndex();
    let questionPerStep = getQuestionPerStep(stepIndex);

    const progressIndicator = progress.querySelector('.progress-indicator');
    const progressNumber = progress.querySelector('#totalCorrectAnswers');
    const progressSteps = progress.querySelectorAll('.progress-step');
    const progressBadge = progressIndicator.querySelector('.progress-badge');

    // Nếu trả lời sai
    if (!isAnsweredCorrect) {
        markIncorrect(progressSteps[stepIndex], progressBadge);
        return;
    }

    increaseStepCorrectCount();
    increaseTotalCorrectAnswers();

    const percentage = calculatePercentage(getStepCorrectCount(), questionPerStep);
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

export function updateProgressStep(step, percentage) {
    step.style.setProperty('--progress-fill', `calc(${percentage}% + .3rem)`);
}

export function updateProgressIndicator(indicator, numberElement, percentage) {
    if (!numberElement || !indicator) return;

    numberElement.textContent = getTotalCorrectAnswers(); 
    indicator.style.setProperty('--progress-indicator-0', `${percentage}%`);
    indicator.style.setProperty('--progress-indicator-1', `translateX(calc(-1% * ${percentage}))`);
}

export function calculatePercentage(current, total) {
    return Math.min((current / total) * 100, 100)
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

export function moveBadgeToNextStep() {
    stepIndex = getStepIndex();
    const progress = document.querySelector('#learningProgress');
    const progressSteps = progress.querySelectorAll('.progress-step');
    const indicator = progress.querySelector('.progress-indicator');
    const progressNumber = progress.querySelector('#totalCorrectAnswers');

    updateProgressIndicator(indicator, progressNumber, 0);
    progressSteps[stepIndex].appendChild(indicator);
}