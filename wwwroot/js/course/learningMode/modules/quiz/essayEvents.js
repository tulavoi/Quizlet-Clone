
import { nextQuiz } from './quizHandler.js';
import { showNotificationBar } from '../notificationBar/notificationBarHandler.js';
import { renderCorrectAnswer, renderIncorrectAnswer, renderSkippedAnswer } from './quizUIManager.js';
import { updateProgress } from '../progressBar/learningProgress/progressUpdater.js';

const learningProgress = document.querySelector('#learningProgress');

export function getCorrectAnswer() {
    return document.querySelector('.quiz-section').dataset.correctAnswer;
}

export function attachInputAnswerEvent() {
    const input = document.querySelector('.answer-input');
    if (input) {
        input.focus();

        input.addEventListener('keydown', (event) => {
            if (event.key === 'Enter') {
                checkAnswer();
            }
        });
    }
}

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


export function checkAnswer() {
    const correctAnswer = getCorrectAnswer();
    const userInput = document.querySelector('.answer-input').value.trim().toLowerCase();
    if (!correctAnswer) return;

    const isCorrect = isAnswerCorrect(userInput, correctAnswer);

    updateAnswerArea(isCorrect, userInput, correctAnswer);

    if (isCorrect) {
        setTimeout(() => {
            nextQuiz();
        }, 1000);
        updateProgress(learningProgress, isCorrect);
    } else {
        updateProgress(learningProgress, isCorrect);
        showNotificationBar();
    }
}
window.checkAnswer = checkAnswer;

export function displaySuggestion() {
    const correctAnswer = getCorrectAnswer();
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

export function updateAnswerArea(isCorrect, userInput, correctAnswer) {
    if (userInput === '') {
        renderSkippedAnswer(correctAnswer);
    } else if (isCorrect) {
        renderCorrectAnswer(userInput);
    } else {
        renderIncorrectAnswer(userInput, correctAnswer);
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
