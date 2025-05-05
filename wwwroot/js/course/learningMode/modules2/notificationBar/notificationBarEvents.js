
import { nextQuiz } from '../quiz/quizHandler.js';
import { hideNotificationBar } from './notificationBarHandler.js';

// Xử lý khi bấm phím bất kỳ
export function handleKeyContinue(event) {
    // Nếu nhấn kèm phím Alt, Shift, Ctrl hoặc Meta(command, window) thì bỏ qua
    if (event.altKey || event.shiftKey || event.ctrlKey || event.metaKey) return;

    // Ngăn hành vi mặc định như cuộn trang khi bấm Space
    event.preventDefault();

    handleContinue();
}

// Xử lý khi bấm tiếp tục
export function handleContinue() {
    hideNotificationBar();
    nextQuiz();

    // Remove event listeners để tránh lặp bug
    document.removeEventListener('keydown', handleKeyContinue);
    const continueBtn = document.querySelector('.btn-continue');
    continueBtn.removeEventListener('click', handleContinue);
}