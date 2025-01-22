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
} from './sharedVariables.js';

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