
import { renderQuiz, hideQuizContainer, displayQuizContainer } from './quiz/quizHandler.js';
import { hideOverviewProgress, displayOverviewProgress } from './progressBar/overviewProgress/progressRenderer.js';
import { hideLearningProgress, displayLearningProgress } from './progressBar/learningProgress/progressRenderer.js';
import {
    getQuestionPerStep,
    getCurrentQuestionIndex,
    increaseStep,
    getStepIndex
} from './quiz/quizState.js';
import { showNotificationBar } from './notificationBar/notificationBarHandler.js';
import { fillStepProgress, moveBagdeToEnd, moveBadgeToNextStep } from './progressBar/learningProgress/progressUpdater.js';

const learningProgress = document.querySelector('#learningProgress');

export function renderUI() {
    const stepIndex = getStepIndex();
    const questionsPerStep = getQuestionPerStep(stepIndex);
    const currQuestionIndex = getCurrentQuestionIndex();

    if (currQuestionIndex < questionsPerStep) {
        displayLearningProgress();
        displayQuizContainer();
        renderQuiz();
        hideOverviewProgress();
    } else {
        setTimeout(() => {
            Promise.all([
                fillStepProgress(learningProgress, stepIndex),      // Fill màu xanh đầy thanh step
                moveBagdeToEnd(learningProgress)                    // Di chuyển Bagde đến cuối thanh step
            ]).then(() => {
                setTimeout(() => {
                    hideLearningProgress();
                    hideQuizContainer();
                    displayOverviewProgress();
                    showNotificationBar();
                    moveBadgeToNextStep();
                }, 550);
            });
        }, 100);

        increaseStep();
    }
}