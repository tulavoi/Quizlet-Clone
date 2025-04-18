import { updateProgressBar } from './progressUpdater.js';
import { updateQuizUI } from './uiUpdater.js';
import { showNotificationBar } from './notificationHandler.js';

// Xử lý khi user chọn đáp án đúng
export function checkAnswer(selectedAnswer) {
    if (!selectedAnswer) return;

    let isCorrect = selectedAnswer.dataset.correct === 'true';
    updateQuizUI(isCorrect, selectedAnswer);

    // Nếu chọn đúng đáp án thì cập nhật progress bar
    if (isCorrect) updateProgressBar();
    else showNotificationBar();
}
window.checkAnswer = checkAnswer;
