
import {
    correctMessages,
    incorrectMessages,
    skipMessages,
    getMessage
} from '../messages.js';

export function showSkipMessageInHelpBox() {
    const quizCardHelp = document.querySelector('.quiz-card-help');
    quizCardHelp.innerHTML = "";

    quizCardHelp.innerHTML = `
        <div class="quiz-card-title">
            <span style="padding: 8px 16px;">Đã bỏ qua</span>
        </div>
    `;
}

export function setQuizTitleWithResult(isCorrect) {
    const quizCardTitle = document.querySelector('.quiz-section .quiz-card-title span');
    if (typeof isCorrect === 'boolean') {
        quizCardTitle.textContent = getMessage(isCorrect ? correctMessages : incorrectMessages);
        quizCardTitle.style.color = isCorrect ? 'var(--green-deep)' : 'var(--orange-deep)';
    } else {
        quizCardTitle.textContent = getMessage(skipMessages);
    }
}
