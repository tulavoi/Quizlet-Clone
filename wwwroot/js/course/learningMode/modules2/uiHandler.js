
import { renderQuiz, hideQuizContainer, displayQuizContainer } from './quiz/quizHandler.js';
import { hideOverviewProgress, displayOverviewProgress } from './progressBar/overviewProgress/progressRenderer.js';
import { hideLearningProgress, displayLearningProgress } from './progressBar/learningProgress/progressRenderer.js';
import { getCurrentQuestionIndex, getQuestionPerStep } from './quiz/quizState.js';


export function renderUI() {
    const currQuestionIndex = getCurrentQuestionIndex();

    const questionPerStep = getQuestionPerStep(1);

    // Nếu câu hỏi hiện tại nằm trong số lượng câu hỏi mỗi step thì hiển thị quiz, learning progress và hiển thị overview progress
    // Nếu không thì ẩn quiz, learning progress để hiển thị overview progress
    if (currQuestionIndex + 1 <= questionPerStep) {
        displayLearningProgress();
        displayQuizContainer();
        renderQuiz();

        hideOverviewProgress();
    } else {
        hideLearningProgress();
        hideQuizContainer();

        displayOverviewProgress();
        // Hiển thị progress bar, tăng step index lên 1
    }
}