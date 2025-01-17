// flashcardsOptionsModal.js
// ==============================================
// Mô tả: File JavaScript này chứa các hàm và logic dành riêng cho
// phần xử lý các chức năng trong file _FlashcardsOptionsModal.cshtml.
// Bao gồm: các chức năng khởi động lại flashcards
// ==============================================

// Hàm khởi động lại flashcards
export function resetCards() {
    const toggleStarred = document.getElementById('toggleStarred');
    let isStarred = toggleStarred.checked;

    // Lấy slug từ URL hiện tại
    const slug = window.location.pathname.split('/').pop();

    if (isStarred) {
        // Chuyển tới url mới
        window.location.href = `/${slug}?isStarred=${isStarred}`;
    } else {
        window.location.href = `/${slug}`;
    }
}
window.resetCards = resetCards;