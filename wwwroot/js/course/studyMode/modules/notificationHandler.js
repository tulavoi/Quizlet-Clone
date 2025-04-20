import { nextQuestion } from './quizHandler.js';

// Hiển thị thanh thông báo tiếp tục
export function showNotificationBar() {
    const notification = document.querySelector('.notification-bar-container');
    const continueBtn = document.querySelector('.btn-continue');

    notification.classList.remove('d-none');
    requestAnimationFrame(() => {
        notification.classList.add('show');
    });

    document.addEventListener('keydown', handleKeyContinue);
    continueBtn.addEventListener('click', handleContinue);
}

// Xử lý khi bấm phím bất kỳ
function handleKeyContinue(event) {
    // Nếu nhấn Alt, Shift hoặc Ctrl thì bỏ qua
    const disallowKeys = ['Alt', 'Shift', 'Ctrl'];
    if (disallowKeys.includes(event.key)) return;

    handleContinue();
}

// Xử lý khi bấm tiếp tục
function handleContinue() {
    hideNotificationBar();
    nextQuestion();

    // Remove event listeners để tránh lặp bug
    document.removeEventListener('keydown', handleKeyContinue);
    const continueBtn = document.querySelector('.btn-continue');
    continueBtn.removeEventListener('click', handleContinue);
}

// Ẩn thông báo tiếp tục
function hideNotificationBar() {
    const notification = document.querySelector('.notification-bar-container');
    notification.classList.add('d-none');
}