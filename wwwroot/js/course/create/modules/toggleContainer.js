// toggleContainer.js
// ==============================================
// Mô tả: File JavaScript này chứa các hàm và logic dành riêng cho
// phần xử lý chức năng chuyển đổi giao diện tạo course và giao diện nhập flashcards file Create.cshtml.
// Bao gồm: các sự kiện click quay về thẻ cuối cùng, khởi động lại học phần, bắn pháo bông,... v.v.
// ==============================================

import { termsSection } from './sharedVariables.js';

// Khi nhấn Nhập sẽ hiện lên gd nhập flashcards và ẩn gd tạo course
document.getElementById('open-import-flashcards').addEventListener('click', () => {
    toggleContainer('.create-course-container', '.import-flashcards-container', 'white');
});

// Khi nhấn hủy nhập sẽ hiện lên gd tạo course và ẩn gd nhâp flashcards
document.getElementById('cancel-import').addEventListener('click', () => {
    toggleContainer('.import-flashcards-container', '.create-course-container', '#f6f7fb');
});

export function toggleContainer(hideSelector, showSelector, bgColor) {
    // Ẩn container hiện tại
    document.querySelector(hideSelector).style.display = 'none';

    // Hiển thị container khác
    document.querySelector(showSelector).style.display = 'block';

    // Thay đổi màu nền (nếu có)
    if (bgColor) {
        document.body.style.backgroundColor = bgColor;
    }
}