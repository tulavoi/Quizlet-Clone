
import { nextQuiz } from './quizHandler.js';
import { disableHelpButton } from './quizHelp.js';
import { setQuizTitleWithResult } from './updateQuizText.js';
import { showNotificationBar, hideNotificationBar } from '../notificationBar/notificationBarHandler.js';

export function checkAnswer(selectedOption) {
    const isCorrect = selectedOption.dataset.correct === 'true';
    const options = document.querySelectorAll('.quiz-option');

    updateOptionState(selectedOption, options);
    setQuizTitleWithResult(isCorrect);
    disableHelpButton();

    if (isCorrect) {
        // update learning progress
        setTimeout(() => {
            nextQuiz();
        }, 1000);
    } else {
        showNotificationBar();
    }
}
window.checkAnswer = checkAnswer;

function updateOptionState(selectedOption, options) {
    options.forEach(option => {
        option.onclick = null;

        const isCorrect = option.dataset.correct === 'true';

        if (option === selectedOption) {
            option.classList.add(isCorrect ? 'is-correct' : 'is-incorrect');
        }
        else if (isCorrect){
            hightlightCorrectOption(option);
        }
        else {
            option.classList.add('is-disabled');
        }
    });
}

export function disableWrongOptions(correctOption) {
    const options = document.querySelectorAll('.quiz-option');
    options.forEach(option => {
        if (option !== correctOption) {
            option.classList.add('is-disabled');
        }
    });
}

export function hightlightCorrectOption(option) {
    option.classList.add('is-correct-2');
    option.classList.add('clickable');

    // Khi click sẽ đóng notification bar và chuyển tới câu hỏi tiếp theo
    option.addEventListener('click', () => {
        hideNotificationBar();
        nextQuiz();
    });
}

export function findCorrectOption() {
    const options = document.querySelectorAll('.quiz-option');
    return Array.from(options).find(option =>
        option.dataset.correct === 'true'
    );
}