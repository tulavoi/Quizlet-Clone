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
export function starredFlashcard(btn, isStarred = null) {
    if (isStarred === null) {
        isStarred = getDataIsStarredValue(btn);
    }
    const flashcardId = btn.getAttribute('data-flashcard-id');

    // Đảo ngược trạng thái gắn sao
    isStarred = !isStarred;

    // Cập  nhật lại màu icon
    updateBtnIconColor(btn, isStarred);
   
    // Cập nhật giá trị trạng thái gắn sao của flashcard
    updateFlashcardStarred(flashcardId, isStarred);
}
window.starredFlashcard = starredFlashcard;

// Lấy giá trị data-is-starred trong button
function getDataIsStarredValue(btn) {
    return btn.getAttribute('data-is-starred').toLowerCase() === 'true';
}

// Cập nhật màu icon của btn
function updateBtnIconColor(btn, isStarred) {
    btn.setAttribute('data-is-starred', isStarred.toString());
    const icon = btn.querySelector('i');
    icon.style.color = isStarred ? '#FFCD1F' : '#6C757D';
}

// Lưu trạng thái gắn sao của flashcard
function updateFlashcardStarred(flashcardId, isStarred) {
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
            console.error('Failed to starred');
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

    const btnStarredLearned = document.querySelector('#btn-starred-learned');
    const btnStarredNotLearned = document.querySelector('#btn-starred-not-learned');

    let areLearnedCardsStarred = false;
    let areNotLearnedCardsStarred = false;

    if (btnStarredLearned) {
        areLearnedCardsStarred = btnStarredLearned.getAttribute('data-are-learned-starred')?.toLowerCase() === 'true';
    }

    if (btnStarredNotLearned) {
        areNotLearnedCardsStarred = btnStarredNotLearned.getAttribute('data-are-not-learned-starred')?.toLowerCase() === 'true';
    }
    updateTitleStarredBtn(areLearnedCardsStarred, btnStarredLearned);
    updateTitleStarredBtn(areNotLearnedCardsStarred, btnStarredNotLearned);
});

// Cập nhật lại tiêu đề của button gắn sao nhiều flashcards
function updateTitleStarredBtn(areStarred, btn){
    if (btn !== null) {
        // Lấy phần tử <span> bên trong button
        const span = btn.querySelector('span');

        // Lấy số lượng flashcards từ textContent
        //const cardCount = span.textContent.split(' ')[span.textContent.length - 1];
        const cardCount = btn.getAttribute('data-cards-count');

        // Nếu areStarred = true, thay đổi nội dung thành "Bỏ chọn"
        span.textContent = areStarred ? `Bỏ chọn ${cardCount}` : `Chọn ${cardCount}`;
    }
}

// Thực hiện gắn sao nhiều cards
export function starredFlashcards(flashcards, btn) {
    let allAreStarred = true;

    // Lặp qua từng flashcard và kiểm tra trạng thái của các button
    flashcards.forEach(card => {
        let btns = document.querySelectorAll(`button[data-flashcard-id="${card.id}"]`);
        btns.forEach(btn => {
            const btnIsStarred = btn.getAttribute('data-is-starred').toLowerCase() === 'true';

            // Nếu có bất kỳ button nào không được gắn sao, chuyển thành false
            if (!btnIsStarred) {
                allAreStarred = false;
            }
        });

        // Thực hiện gắn sao thẻ và cập nhật từng button
        btns.forEach(btn => {
            starredFlashcard(btn, allAreStarred);
        });
    });

    // Đảo ngược isStarred và cập nhật lại tiêu đề của button
    updateTitleStarredBtn(!allAreStarred, btn);
}
window.starredFlashcards = starredFlashcards;