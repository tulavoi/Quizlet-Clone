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
    document.querySelector('.navbar').classList.add('d-none'); // Ẩn navbar
    document.querySelector('.create-course-container').classList.remove('container');
});

// Khi nhấn hủy nhập sẽ hiện lên gd tạo course và ẩn gd nhâp flashcards
document.getElementById('cancel-import').addEventListener('click', () => {
    toggleContainer('.import-flashcards-container', '.create-course-container', '#f6f7fb');
    document.querySelector('.navbar').classList.remove('d-none'); // Hiện navbar
    document.querySelector('.create-course-container').classList.add('container');
});

export function toggleContainer(hideThis, showThis, bgColor) {
    // Ẩn container hiện tại
    document.querySelector(hideThis).style.display = 'none';

    // Hiển thị container khác
    document.querySelector(showThis).style.display = 'block';

    // Thay đổi màu nền (nếu có)
    if (bgColor) {
        document.body.style.backgroundColor = bgColor;
    }
}