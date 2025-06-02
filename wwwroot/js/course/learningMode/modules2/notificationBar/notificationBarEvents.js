
import { nextQuiz } from '../quiz/quizHandler.js';
import { hideNotificationBar } from './notificationBarHandler.js';
import { hideOverviewProgress } from '../progressBar/overviewProgress/progressRenderer.js';
import { moveIndicatorToNextStep } from '../progressBar/learningProgress/progressUpdater.js';
import { renderUI } from '../uiHandler.js';

// Xử lý khi bấm phím bất kỳ
export function handleKeyContinue(event) {
    // Nếu nhấn kèm phím Alt, Shift, Ctrl hoặc Meta(command, window) thì bỏ qua
    if (event.altKey || event.shiftKey || event.ctrlKey || event.metaKey || event.key === 'Enter') return;

    // Nếu nhấn F1 -> F12 thì bỏ qua
    if (/^F[1-9]$|^F1[0-2]$/.test(event.key)) return;

    // Ngăn hành vi mặc định như cuộn trang khi bấm Space
    event.preventDefault();

    handleContinue();
}

// Xử lý khi bấm tiếp tục
export function handleContinue() {
    const overviewVisible = !document.querySelector('.progress-overview-container').classList.contains('d-none');

    if (overviewVisible) {
        hideOverviewProgress();
        renderUI();
    } else {
        nextQuiz();
    }

    hideNotificationBar();

    // Remove event listeners để tránh lặp bug
    document.removeEventListener('keydown', handleKeyContinue);
    const continueBtn = document.querySelector('.btn-continue');
    continueBtn.removeEventListener('click', handleContinue);
}