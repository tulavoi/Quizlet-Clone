
import { renderQuiz, hideQuizContainer, displayQuizContainer } from './quiz/quizHandler.js';
import { renderOverviewProgress, hideOverviewProgress } from './progressBar/overviewProgress/progressRenderer.js';
import { questionPerStep } from './progressBar/learningProgress/progressUpdater.js';
import { renderLearningProgess, hideLearningProgress, displayLearningProgress } from './progressBar/learningProgress/progressRenderer.js';
import { getCurrentQuestionIndex } from './quiz/quizState.js';

export function renderUI() {
    const currQuestionIndex = getCurrentQuestionIndex();

    // Nếu câu hỏi hiện tại nằm trong số lượng câu hỏi mỗi step
    if (currQuestionIndex + 1 <= questionPerStep) {
        hideOverviewProgress();
        renderLearningProgess();
        renderQuiz();
    } else {
        hideLearningProgress();
        hideQuizContainer();
        renderOverviewProgress();

        // Hiển thị ra notification bar, nếu bấm tiếp tục thì tăng step index lên 1, renderQuiz, hiển thị learning progress, ẩn overview progress
        setTimeout(() => {
            hideOverviewProgress();
            displayLearningProgress();
            displayQuizContainer();
        }, 3000);
    }
}