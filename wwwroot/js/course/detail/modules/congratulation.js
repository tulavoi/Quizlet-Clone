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
    postData
} from './sharedVariables.js';

import { updateCardDisplay } from './flashcardsPartial.js';

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
    toggleFlashcardsView(true);

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

    // Nếu có tồn tại resetCurrIndex or resetCurrIndex = true thì hiển thị first flashcard
    if (localStorage.getItem('resetCurrIndex') === 'true') {
        displayFirstFlashcard();

        // Dòng này đảm bảo rằng chỉ có lần tải lại này mới reset lại currIndexCard, và không lặp lại trong các lần tải lại sau
        localStorage.removeItem('resetCurrIndex');
    }
});

// Khi click reset lại flashcards (quay lại flashcard đầu tiên)
export function resetFlashcards() {
    // Ẩn congratulation và hiển thị flashcards
    toggleFlashcardsView(true);

    displayFirstFlashcard();
}
window.resetFlashcards = resetFlashcards;

// Khi click hiển thị các flashcard có gắn sao
export function studyStarredCards(){
    // Lấy url hiện tại
    let url = new URL(window.location.href);

    // Nếu url hiện tại có isStarred thì sẽ bật flashcard view và hiển thị flashcard đầu tiên
    if (url.searchParams.has('isStarred')) {
        toggleFlashcardsView(true);
        displayFirstFlashcard();
    }
    else {
        url.searchParams.set('isStarred', 'true');
        window.location.href = url.toString();
    }
}
window.studyStarredCards = studyStarredCards;

// Khi click reset lại flashcards (quay lại flashcard đầu tiên)
export function restartAll(){
    // Lấy url hiện tại
    let url = new URL(window.location.href);

    // Reset lại giá trị của currIndexCard trong lần tải lại tiếp theo.
    localStorage.setItem('resetCurrIndex', 'true');

    if (url.searchParams.has('isStarred')) {
        url.searchParams.delete('isStarred');
        window.location.href = url.toString();
    }
}
window.restartAll = restartAll;

// Cập nhật lại flashcard cần hiển thị (flashcard đầu tiên)
function displayFirstFlashcard() {
    sharedVariables.currIndexCard = 0;
    updateCardDisplay();
}

// Ẩn, hiện flashcards / congratulation
function toggleFlashcardsView(showFlashcards = true) {
    if (showFlashcards) {
        sharedVariables.congratulationContainer.classList.add('d-none'); // Ẩn congratulation
        sharedVariables.flashcardsContainer.classList.remove('d-none'); // Hiển thị flashcards
    } else {
        sharedVariables.congratulationContainer.classList.remove('d-none'); // Hiển thị congratulation
        sharedVariables.flashcardsContainer.classList.add('d-none'); // Ẩn flashcards
    }
}