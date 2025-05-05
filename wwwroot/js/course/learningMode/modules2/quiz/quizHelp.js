
import { hightlightCorrectOption, findCorrectOption, disableWrongOptions } from './multipleEvents.js';
import { showSkipMessageInHelpBox, setQuizTitleWithResult } from './updateQuizText.js';
import { showNotificationBar } from '../notificationBar/notificationBarHandler.js';

export function disableHelpButton() {
    const helpBtn = document.querySelector('.quiz-help-button');
    helpBtn.classList.add('is-disabled');
}

function helpButtonClickEvent(){
    showSkipMessageInHelpBox();
    setQuizTitleWithResult();
    displayCorrectOption();
    showNotificationBar();
}
window.helpButtonClickEvent = helpButtonClickEvent;

function displayCorrectOption() {
    const option = findCorrectOption();
    disableWrongOptions(option);
    hightlightCorrectOption(option);
}