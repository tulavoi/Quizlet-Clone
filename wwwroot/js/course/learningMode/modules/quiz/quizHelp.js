
import { displayCorrectOption } from './multipleEvents.js';
import { showSkipMessageInHelpBox, setQuizTitleWithResult, renderSkippedAnswer } from './quizUIManager.js';
import { getCorrectAnswer } from './essayEvents.js';
import { showNotificationBar } from '../notificationBar/notificationBarHandler.js';

export function disableHelpButton() {
    const helpBtn = document.querySelector('.quiz-help-button');
    helpBtn.classList.add('is-disabled');
}

function helpButtonClickEvent() {
    const button = event.currentTarget;
    const quizSection = button.closest('.quiz-section');

    showSkipMessageInHelpBox();
    showNotificationBar();

    if (quizSection.classList.contains('essay-quiz')) {
        renderSkippedAnswer(getCorrectAnswer());
    } else if (quizSection.classList.contains('multiple-choice-quiz')) {
        setQuizTitleWithResult();
        displayCorrectOption();
    }
}
window.helpButtonClickEvent = helpButtonClickEvent;