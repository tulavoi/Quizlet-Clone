
import { handleContinue, handleKeyContinue } from './notificationBarEvents.js';

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

// Ẩn thông báo tiếp tục
export function hideNotificationBar() {
    const notification = document.querySelector('.notification-bar-container');
    notification.classList.add('d-none');
    notification.classList.remove('show');
}