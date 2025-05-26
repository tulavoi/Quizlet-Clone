
import { getStepIndex, getCorrectCount, getQuestionPerStep, increaseCorrectCount } from '../../quiz/quizState.js';

let stepIndex = 0;
let questionPerStep = getQuestionPerStep(stepIndex);

export function updateProgress(progress, isAnsweredCorrect) {
    stepIndex = getStepIndex();
    const progressIndicator = progress.querySelector('.progress-indicator');
    const progressNumber = progress.querySelector('.progress-number');
    const progressSteps = progress.querySelectorAll('.progress-step');
    const progressBadge = progressIndicator.querySelector('.progress-badge');

    // Nếu trả lời sai
    if (!isAnsweredCorrect) {
        markIncorrect(progressSteps[stepIndex], progressBadge);
        return;
    }

    increaseCorrectCount();

    // không cập nhật màu dựa vào số câu trả lời đúng, cập nhật dựa vào câu hỏi thứ báo nhiêu trong step
    const percentage = calculatePercentage(getCorrectCount(), questionPerStep);
    updateBadge(progressIndicator, progressNumber, percentage);
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

function updateBadge(indicator, numberElement, percentage) {
    if (!numberElement) {
        // hoàn thành step 1 -> sang step 2 -> trả lời đúng -> lỗi numberElement null
        // không cập nhật màu dựa vào số câu trả lời đúng, cập nhật dựa vào câu hỏi thứ báo nhiêu trong step
        console.log("num element null"); 
        return;
    }
    numberElement.textContent = getCorrectCount(); 
    indicator.style.setProperty('--progress-indicator-0', `${percentage}%`);
    indicator.style.setProperty('--progress-indicator-1', `translateX(calc(-1% * ${percentage}))`);
}

function calculatePercentage(current, total) {
    return Math.min((current / total) * 100, 100)
}

export function fillStepProgress(progress, currStepIndex) {
    return new Promise(resolve => {
        const progressSteps = progress.querySelectorAll('.progress-step');
        updateProgressStep(progressSteps[currStepIndex], 100);
        setTimeout(resolve, 120);
    });
}

export function moveBagdeToEnd(progress) {
    return new Promise(resolve => {
        const indicator = progress.querySelector('.progress-indicator');
        const badge = indicator.querySelector('.progress-badge');

        updateBadge(indicator, badge, 100);
        setTimeout(resolve, 120);
    });
}

export function moveBadgeToNextStep() {
    stepIndex = getStepIndex();
    const progress = document.querySelector('#learningProgress');
    const progressSteps = progress.querySelectorAll('.progress-step');
    const indicator = progress.querySelector('.progress-indicator');
    const badge = indicator.querySelector('.progress-badge');

    // Xóa indicator cũ nếu đang nằm trong một step trước
    progressSteps.forEach(step => {
        if (step.contains(indicator)) {
            step.removeChild(indicator);
        }
    });

    updateBadge(indicator, badge, 0);
    progressSteps[stepIndex].appendChild(indicator);
}