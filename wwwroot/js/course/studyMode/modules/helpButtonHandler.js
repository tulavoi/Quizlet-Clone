import { showNotificationBar } from './notificationHandler.js';
import { findCorrectAnswer } from './uiUpdater.js';

// Nhớ refactor lại
export function showCorrectAnswer() {
    const answers = document.querySelectorAll('.quiz-answer');
    const correctAnswer = findCorrectAnswer(answers);
    correctAnswer.classList.add('is-correct-2');

    disableAnswers(answers, correctAnswer);
    showNotificationBar();
    hideHelpButton();
}
window.showCorrectAnswer = showCorrectAnswer;

function hideHelpButton() {
    const quizCardHelp = document.querySelector('.quiz-card-help');
    quizCardHelp.innerHTML = "";

    quizCardHelp.innerHTML = `
        <div class="quiz-card-title">
            <span style="padding: 8px 16px;">Đã bỏ qua</span>
        </div>
    `;
}

function disableAnswers(answers, correctAnswer) {
    answers.forEach(answer => {
        answer.classList.add(answer === correctAnswer ? 'is-correct' : 'is-disabled');
    });
}