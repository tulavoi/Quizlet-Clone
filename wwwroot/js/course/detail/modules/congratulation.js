// congratulation.js
// ==============================================
// Mô tả: File JavaScript này chứa các hàm và logic dành riêng cho
// phần xử lý chức năng trong file _CongratulationPartial.cshtml.
// Bao gồm: các sự kiện click quay về thẻ cuối cùng, khởi động lại học phần, bắn pháo bông,... v.v.
// ==============================================

// Import variables from variablesShared.js
import {
    cards,
    sharedVariables,
    postFlashcardProgress
} from './sharedVariables.js';

const btnRestartAll = document.getElementById('btn-restart-all');
const btnResetFlashcard = document.getElementById('btn-reset-flashcards');

// Bắn pháo bông
export function triggerConfetti() {
    confetti({
        particleCount: 100,                                 // Số hạt pháo bông
        angle: 90,                                          // Góc bắn 90 độ
        spread: 360,                                        // Độ lan tỏa (360: bung toàn diện)
        startVelocity: 45,                                  // Tốc độ bắn ban đầu
        origin: { x: 0.5, y: 0.5 },                         // Vị trí giữa screen
        colors: ['#ff0', '#ff6347', '#87ceeb', '#32cd32'],  // Màu sắc pháo bông
    });
}

// Trở về thẻ cuối cùng
export function backToLastCard() {
    sharedVariables.congratulationContainer.classList.add('d-none');
    sharedVariables.flashcardsContainer.classList.remove('d-none');

    // Gán lại currIndexCard là phần tử cuối cùng trong cards
    sharedVariables.currIndexCard = cards.length - 1;
}
window.backToLastCard = backToLastCard;

document.addEventListener('DOMContentLoaded', () => {
    // Lấy giá trị hiện tại của isShuffle từ URL hiện tại
    var urlParams = new URLSearchParams(window.location.search);
    const isStarred = urlParams.get('isStarred') === 'true';

    // Nếu đang học các flashcard có gắn sao thì hiển thị btnRestartAll và ẩn btnResetFlashcard
    if (isStarred) {
        btnRestartAll.classList.remove('d-none');
        btnResetFlashcard.classList.add('d-none');
    } else {
        btnRestartAll.classList.add('d-none');
        btnResetFlashcard.classList.remove('d-none');
    }
});

export function resetFlashcards(){
    sharedVariables.congratulationContainer.classList.add('d-none');
    sharedVariables.flashcardsContainer.classList.remove('d-none');
    const firstCardId = cards[0].getAttribute('data-flashcard-id');
    resetFlashcardProgress(firstCardId);
    window.location.reload();
}
window.resetFlashcards = resetFlashcards;

function resetFlashcardProgress(flashcardId) {
    postFlashcardProgress('/fc-progress/reset-progress', flashcardId, 'failed to reset progress');
}