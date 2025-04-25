import { showNotificationBar } from './notificationHandler.js';
import { findCorrectAnswer, markAnswers } from './uiUpdater.js';
import { nextQuestion } from './quizHandler.js';
import { enableCorrectAnswerForNext } from './answerHandler.js';

// Nhớ refactor lại
export function showCorrectAnswer() {
    const answers = document.querySelectorAll('.quiz-answer');
    const correctAnswer = findCorrectAnswer(answers);
    correctAnswer.classList.add('is-correct-2');

    markAnswers(answers, correctAnswer, true, true);
    showNotificationBar();
    hideHelpButton();

    enableCorrectAnswerForNext(correctAnswer);
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
