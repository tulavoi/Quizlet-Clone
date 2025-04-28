import { updateProgressBar } from './progressUpdater.js';
import { updateQuizUI } from './uiUpdater.js';
import { showNotificationBar, hideNotificationBar } from './notificationHandler.js';
import { nextQuestion } from './quizHandler.js';

let learnProgress = document.querySelector('#learnProgress');

// Xử lý khi user chọn đáp án đúng
export function checkAnswer(selectedAnswer) {
    if (!selectedAnswer) return;

    let isCorrect = selectedAnswer.dataset.correct === 'true';
    updateQuizUI(isCorrect, selectedAnswer);

    // Nếu chọn đúng đáp án thì cập nhật progress bar
    if (isCorrect) {
        updateProgressBar(learnProgress);
        setTimeout(() => {
            nextQuestion();
        }, 1000);
    }
    else showNotificationBar();
}
window.checkAnswer = checkAnswer;

export function enableCorrectAnswerForNext(correctAnswer) {
    if (!correctAnswer) return;

    // Bật pointer-events
    correctAnswer.style.pointerEvents = 'auto';
    correctAnswer.style.cursor = 'pointer';

    // Gỡ sự kiện cũ (tránh bị gọi lại checkAnswer)
    correctAnswer.onclick = null;

    // Gán sự kiện mới để chuyển sang câu hỏi tiếp theo
    correctAnswer.onclick = function(){
        // Ẩn notification bar trước khi chuyển sang câu hỏi tiếp theo
        hideNotificationBar();
        nextQuestion();

        // Sau khi next xong, khóa lại để không bị spam click
        correctAnswer.style.pointerEvents = 'none';
        correctAnswer.onclick = null;
    };
}