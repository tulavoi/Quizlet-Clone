import { nextQuestion } from './questionNavigator.js';

// Hiển thị thanh thông báo tiếp tục
export function showNotificationBar() {
    const notification = document.querySelector('.notification-bar-container');
    const continueBtn = document.querySelector('.btn-continue');

    notification.classList.remove('d-none');
    requestAnimationFrame(() => {
        notification.classList.add('show'); // kích hoạt hiệu ứng
    });

    document.addEventListener('keydown', handleContinue);
    continueBtn.addEventListener('click', handleContinue);
}

// Xử lý khi bấm tiếp tục or phím bất kỳ
function handleContinue() {
    nextQuestion();
    hideNotificationBar();
}

// Ẩn thông báo tiếp tục
function hideNotificationBar() {
    const notification = document.querySelector('.notification-bar-container');
    notification.classList.add('d-none');
}