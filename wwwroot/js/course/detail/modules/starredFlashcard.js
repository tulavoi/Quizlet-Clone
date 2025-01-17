// starredFlashcard.js
// ==============================================
// Mô tả: File JavaScript này chứa các hàm và logic dành riêng cho
// chức năng gắn sao cho thẻ.
// Bao gồm: các sự kiện click cho gắn sao, thay đổi màu sắc icon khi gắn/bỏ sao,
// gửi dữ liệu lên server.
// ==============================================

// Lấy biến đếm số thẻ được gắn sao
let starredCardCount = parseInt(document.getElementById('flashcards-container')
    .getAttribute('data-starred-card-count'), 10);

// Bắt đầu quy trình gắn sao flashcard
export function starredFlashcard(btn) {
    let isStarred = getDataIsStarredValue(btn);
    const flashcardId = btn.getAttribute('data-flashcard-id');
    // Đảo ngược trạng thái gắn sao
    isStarred = !isStarred;

    // Cập  nhật lại màu icon
    updateBtnIconColor(btn, isStarred);

    // Cập nhật giá trị trạng thái gắn sao của flashcard
    updateFlashcardState(flashcardId, isStarred);

    btn.setAttribute('data-is-starred', isStarred.toString());
}
window.starredFlashcard = starredFlashcard;

// Lấy giá trị data-is-starred trong button
function getDataIsStarredValue(btn) {
    return btn.getAttribute('data-is-starred').toLowerCase() === 'true';
}

// Cập nhật màu icon của btn
function updateBtnIconColor(btn, isStarred) {
    const icon = btn.querySelector('i');
    icon.style.color = isStarred ? '#FFCD1F' : '#6C757D';
}

// Lưu trạng thái gắn sao của flashcard
function updateFlashcardState(flashcardId, isStarred) {
    fetch('/fc-progress/starred-card', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            flashcardId,
            isStarred
        })
    })
    .then(response => {
        if (!response.ok) {
            console.error(errorMessage);
        } else {
            // Cập nhật biến đếm starredCardCount(được khai báo và gán giá trị ở Details.cshtml)
            // Tăng nếu gắn sao, giảm nếu gắn sao
            starredCardCount = isStarred ? starredCardCount + 1 : starredCardCount - 1;

            changeStateToggleStarred();
        }
    })
    .catch(error => {
        console.error('Error:', error);
    });
}

// Bật/tắt toggleStarred 
function changeStateToggleStarred() {
    const switchElement = toggleStarred.closest('.switch');

    if (starredCardCount > 0) {
        toggleStarred.removeAttribute('disabled');
        switchElement.removeAttribute('disabled');
    } else {
        toggleStarred.checked = false;
        toggleStarred.setAttribute('disabled', 'true');
        switchElement.setAttribute('disabled', 'true');
    }

    // Lấy giá trị hiện tại của isShuffle từ URL hiện tại
    var urlParams = new URLSearchParams(window.location.search);
    const isStarred = urlParams.get('isStarred') === 'true';
    if (isStarred) {
        toggleStarred.checked = true;
    }
}

// Hàm chạy khi trang được load
window.addEventListener('DOMContentLoaded', () => {
    // Lặp qua tất cả các button để cập nhật màu sắc ban đầu
    const buttons = document.querySelectorAll('[data-is-starred]');

    buttons.forEach(btn => {
        let isStarred = getDataIsStarredValue(btn);
        updateBtnIconColor(btn, isStarred);
    });

    // Gọi lại hàm để kiểm tra có flashcard nào đc gắn sao k và cập nhật trạng thái
    changeStateToggleStarred();
});