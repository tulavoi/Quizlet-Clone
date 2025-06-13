
import { nextQuiz } from './quizHandler.js';
import { disableHelpButton } from './quizHelp.js';
import { setQuizTitleWithResult } from './quizUIManager.js';
import { showNotificationBar, hideNotificationBar } from '../notificationBar/notificationBarHandler.js';
import { updateProgress } from '../progressBar/learningProgress/progressUpdater.js';

const learningProgress = document.querySelector('#learningProgress');

export function checkOption(selectedOption) {
    const isCorrect = selectedOption.dataset.correct === 'true';
    const options = document.querySelectorAll('.quiz-option');

    updateOptionState(selectedOption, options);
    setQuizTitleWithResult(isCorrect);
    disableHelpButton();

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
window.checkOption = checkOption;

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

function disableWrongOptions(correctOption) {
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

    // BUG: Sau khi click vào sẽ chuyển đến câu hỏi tiếp theo, nếu nhấn nút bất kỳ câu hỏi đó sẽ bị skip
    // Khi click sẽ đóng notification bar và chuyển tới câu hỏi tiếp theo
    option.addEventListener('click', () => {
        hideNotificationBar();
        nextQuiz();
    });
}

function findCorrectOption() {
    const options = document.querySelectorAll('.quiz-option');
    return Array.from(options).find(option =>
        option.dataset.correct === 'true'
    );
}

export function displayCorrectOption() {
    const option = findCorrectOption();
    disableWrongOptions(option);
    hightlightCorrectOption(option);
}