
import {
    updateBagdePosition,
    calculatePercentage,
    updateProgressStepColor,
    totalQuestions
} from './progressUpdater.js';

let proressOverview = document.querySelector('#progressOverview');

export function updateProgressbar(correctAnswer) {
    proressOverview.querySelector('.total-pill span').textContent = totalQuestions;
    proressOverview.querySelector('.progress-number').textContent = correctAnswer;

    const percentage = Math.round(calculatePercentage(correctAnswer, totalQuestions));

    updateProgressStepColor(percentage, proressOverview);

    updateBagdePosition(percentage, proressOverview);

    // Cập nhật phần trăm tiến độ
    const progressPercent = document.querySelector('.progress-percentage');
    progressPercent.textContent = `${percentage}%`;
}

export function hideProgressOverview() {
    document.querySelector('.progress-overview-container').classList.add('d-none');
    document.querySelector('.quiz-container').classList.remove('d-none');
    document.querySelector('.study-progress-container').classList.remove('d-none');
}

export function displayProgressOverview() {
    document.querySelector('.quiz-container').classList.add('d-none');
    document.querySelector('.study-progress-container').classList.add('d-none');
    document.querySelector('.progress-overview-container').classList.remove('d-none');
}

