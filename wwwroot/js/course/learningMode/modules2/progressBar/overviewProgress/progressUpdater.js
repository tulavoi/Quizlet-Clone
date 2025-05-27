
import {
    updateProgressIndicator,
    calculatePercentage,
    updateProgressStep,
} from '../learningProgress/progressUpdater.js';

import {
    getTotalCorrectAnswers,
    getTotalQuestionCount,
} from '../../quiz/quizState.js';

export function updateProgress(progress) {
    const progressIndicator = progress.querySelector('.progress-indicator');
    const progressNumber = progress.querySelector('#totalCorrectAnswers');
    const progressStep = progress.querySelector('.progress-step');

    const percentage = calculatePercentage(getTotalCorrectAnswers(), getTotalQuestionCount());
    updateOverviewProgressValue(percentage);

    setTimeout(() => {
        updateProgressIndicator(progressIndicator, progressNumber, percentage);
        updateProgressStep(progressStep, percentage);
    }, 1000);
}

function updateOverviewProgressValue(percentage) {
    const progressPercentage = document.querySelector('.progress-percentage');
    progressPercentage.textContent = percentage + "%";
}
