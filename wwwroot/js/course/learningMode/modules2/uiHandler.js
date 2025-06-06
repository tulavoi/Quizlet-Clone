
import { renderQuiz, hideQuizContainer, displayQuizContainer } from './quiz/quizHandler.js';
import { hideOverviewProgress, displayOverviewProgress } from './progressBar/overviewProgress/progressRenderer.js';
import { hideLearningProgress, displayLearningProgress } from './progressBar/learningProgress/progressRenderer.js';
import {
    getQuestionPerStep,
    getCurrentQuestionIndex,
    increaseStep,
    getStepIndex,
    getStepSize,
} from './quiz/quizState.js';
import { showNotificationBar } from './notificationBar/notificationBarHandler.js';
import { fillStepProgress, moveIndicatorToEnd, moveIndicatorToNextStep } from './progressBar/learningProgress/progressUpdater.js';
import { displayLearningFinish } from './learningFinish/learningFinishHandler.js';
import { triggerConfetti } from '../../../shared/confetti.js';


const learningProgress = document.querySelector('#learningProgress');

export function renderUI() {
    const stepIndex = getStepIndex();
    const stepSizes = getStepSize();
    const questionsPerStep = getQuestionPerStep(stepIndex);
    const currQuestionIndex = getCurrentQuestionIndex();

    if (stepIndex >= stepSizes.length) {
        handleLearningFinish();
    }
    else if (currQuestionIndex < questionsPerStep) {
        showQuiz();
    } else {
        handleStepComplete(stepIndex);
    }
}

function handleLearningFinish() {
    triggerConfetti();          // Bắn pháo bông khi hoàn thành tất cả các bước
    displayLearningFinish();    // Hiển thị thông báo hoàn thành học tập
}

function showQuiz() {
    displayLearningProgress();
    displayQuizContainer();
    renderQuiz();
    hideOverviewProgress();
}

function handleStepComplete(stepIndex) {
    setTimeout(() => {
        Promise.all([
            fillStepProgress(learningProgress, stepIndex),  // Fill màu xanh đầy thanh step
            moveIndicatorToEnd(learningProgress)            // Di chuyển Indicator đến cuối thanh step
        ]).then(() => {
            setTimeout(() => {
                hideLearningProgress();
                hideQuizContainer();
                displayOverviewProgress();
                showNotificationBar();
                moveIndicatorToNextStep();
            }, 550);
        });
    }, 100);

    increaseStep();
}