
import { updateLearningProgress } from '../services/apiHandler.js';
import { getCourseId } from '../quiz/quizState.js';

export function displayLearningFinish() {
    document.querySelector('.learning-finish-container').classList.remove('d-none');
}

export function hideLearningFinish() {
    document.querySelector('.learning-finish-container').classList.add('d-none');
}

export function resetLearningProgress() {
    updateLearningProgress({
        courseId: getCourseId(),
        correctAnswerCount: 0,
        currentQuestionIndex: 0,
        correctAnswersPerStep: ''
    });
    location.reload();
}
window.resetLearningProgress = resetLearningProgress;