
import {
    correctMessages,
    incorrectMessages,
    skipMessages,
    getMessage
} from '../messages.js';

import { hightlightCorrectOption } from './multipleEvents.js';

export function renderSkippedAnswer(correctAnswer) {
    const essayQuiz = document.querySelector('.essay-quiz');
    essayQuiz.innerHTML = '';

    essayQuiz.innerHTML = `
        <div class="answer-area">
            <div class="quiz-card-title muted">
                <span>${getMessage(skipMessages)}</span>
            </div>

            <div class="quiz-option is-skipped">
                <div class="quiz-option-no"></div>
                <div class="quiz-option-text">Đã bỏ qua</div>
            </div>

            <div class="my-2"></div>

            <div class="quiz-card-title">
                <span style="color: var(--green-deep);">Đáp án đúng</span>
            </div>

            <div class="quiz-option is-correct-2">
                <div class="quiz-option-no"></div>
                <div class="quiz-option-text">${correctAnswer}</div>
            </div>
        </div>
    `;

    const option = document.querySelector('.answer-area .quiz-option.is-correct-2');
    hightlightCorrectOption(option);
}

export function renderCorrectAnswer(userInput) {
    const essayQuiz = document.querySelector('.essay-quiz');
    essayQuiz.innerHTML = '';

    essayQuiz.innerHTML = `
        <div class="answer-area">
            <div class="quiz-card-title">
                <span style="color: var(--green-deep);">${getMessage(correctMessages)}</span>
            </div>

            <div class="quiz-option is-correct">
                <div class="quiz-option-no"></div>
                <div class="quiz-option-text">${userInput}</div>
            </div>
        </div>
    `;
}

export function renderIncorrectAnswer(userInput, correctAnswer)  {
    const essayQuiz = document.querySelector('.essay-quiz');
    essayQuiz.innerHTML = '';

    essayQuiz.innerHTML = `
        <div class="answer-area">
            <div class="quiz-card-title">
                <span style="color: var(--orange-deep);">${getMessage(incorrectMessages)}</span>
            </div>

            <div class="quiz-option is-incorrect">
                <div class="quiz-option-no"></div>
                <div class="quiz-option-text">${userInput}</div>
            </div>

            <div class="my-2"></div>

            <div class="quiz-card-title">
                <span style="color: var(--green-deep);">Đáp án đúng</span>
            </div>

            <div class="quiz-option is-correct-2">
                <div class="quiz-option-no"></div>
                <div class="quiz-option-text">${correctAnswer}</div>
            </div>
        </div>
    `;

    const option = document.querySelector('.answer-area .quiz-option.is-correct-2');
    hightlightCorrectOption(option);
}

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
