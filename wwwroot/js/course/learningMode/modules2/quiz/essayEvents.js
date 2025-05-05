
import { nextQuiz } from './quizHandler.js';
import { showNotificationBar, hideNotificationBar } from '../notificationBar/notificationBarHandler.js';
import { setQuizTitleWithResult } from './updateQuizText.js';
import {
    correctMessages,
    incorrectMessages,
    skipMessages,
    getMessage
} from '../messages.js';

export function attachCharacterButtonsEvent() {
    const buttons = document.querySelectorAll('.character-button');
    const input = document.querySelector('.answer-input');

    buttons.forEach(btn => {
        btn.addEventListener('click', () => {
            input.value += btn.textContent;
            input.focus();
        })
    });
}

export function displaySuggestion(correctAnswer) {
    const suggestionContainer = document.querySelector('.suggestion-container');
    if (!suggestionContainer || !correctAnswer || correctAnswer.trim() === '') return;

    const firstChar = correctAnswer.charAt(0);
    const suggestionBlockHtml = `
        <div class="sugesstion-block">
            <span class="suggestion-title">GỢI Ý</span>
            <span class="suggestion-text">
                ${firstChar}________
            </span>
        </div>
    `;

    suggestionContainer.innerHTML = suggestionBlockHtml;
}
window.displaySuggestion = displaySuggestion;

export function checkAnswer(correctAnswer) {
    const userInput = document.querySelector('.answer-input').value.trim().toLowerCase();
    if (!correctAnswer) return;

    const isCorrect = isAnswerCorrect(userInput, correctAnswer);

    updateAnswerArea(isCorrect, userInput, correctAnswer);
    setQuizTitleWithResult(isCorrect);

    if (isCorrect) {
        setTimeout(() => {
            nextQuiz();
        }, 1000);
    } else {
        showNotificationBar();
    }
}
window.checkAnswer = checkAnswer;

function updateAnswerArea(isCorrect, userInput, correctAnswer) {
    const essayQuiz = document.querySelector('.essay-quiz');
    essayQuiz.innerHTML = '';

    if (isCorrect) {
        essayQuiz.innerHTML = `
            <div class="answer-area">
                <div class="quiz-card-title">
                    <span style="color: var(--green-deep);">${ getMessage(correctMessages) }</span>
                </div>

                <div class="quiz-option is-correct">
                    <div class="quiz-option-no"></div>
                    <div class="quiz-option-text">${userInput}</div>
                </div>
            </div>
        `;
    } else {
        essayQuiz.innerHTML = `
            <div class="answer-area">
                <div class="quiz-card-title">
                    <span style="color: var(--orange-deep);">${ getMessage(incorrectMessages) }</span>
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
    }
}

function isAnswerCorrect(userInput, correctAnswer) {
    const normalizeAnswer = normalizeText(correctAnswer);

    // Tách từng từ từ đáp án chuẩn (dựa theo khoảng trắng)
    const validAnswers = normalizeAnswer.split(/\s+/);
    return validAnswers.includes(userInput);
}

function normalizeText(text){
    return text
        .replace(/[()、,。.．，\[\]{}<>「」『』]/g, '')  // loại ký tự đặc biệt phổ biến
        .trim()
        .toLowerCase();
}
