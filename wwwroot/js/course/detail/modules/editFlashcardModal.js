// editFlashcardModal.js
// ==============================================
// Mô tả: File JavaScript này chứa các hàm và logic dành riêng cho
// phần sửa flashcard trong file _EditFlashcardModal.cshtml.
// ==============================================

import { postData } from './sharedVariables.js';
import { pressKeyToFlipCard } from './flashcardsPartial.js';

const modal = document.getElementById('edit-flashcard-modal');

// Gán dữ liệu flashcard khi mở modal
export function assignDataToModal(flashcardId, term, definition){
    const termInput = modal.querySelector('#term');
    const defiInput = modal.querySelector('#definition');
    const idInput = modal.querySelector('#flashcardId');

    idInput.value = flashcardId;
    termInput.value = term;
    defiInput.value = definition;
}
window.assignDataToModal = assignDataToModal;

// Quản lý lắng nghe sự kiện keydown
function toggleKeydownListening(isListening) {
    if (isListening) {
        document.addEventListener('keydown', pressKeyToFlipCard);
    } else {
        document.removeEventListener('keydown', pressKeyToFlipCard);
    }
}

// Đảm bảo rằng sự kiện keydown được đăng ký ngay khi trang tải
let isListeningPressKey = true;
toggleKeydownListening(isListeningPressKey);

// Tắt lắng nghe sự kiện phím khi modal mở
modal.addEventListener('show.bs.modal', function () {
    if (isListeningPressKey) {
        toggleKeydownListening(false);
        isListeningPressKey = false;
    }
});

// Bật lắng nghe sự kiện phím khi modal mở
modal.addEventListener('hidden.bs.modal', function () {
    if (!isListeningPressKey) {
        toggleKeydownListening(true);
        isListeningPressKey = true;
    }
});

export async function updateFlashcard() {
    const Id = document.getElementById('flashcardId').value;
    const Term = document.getElementById('term').value;
    const Definition = document.getElementById('definition').value;

    await postData('/flashcard/update', { Id, Term, Definition }, 'failed to update flashcard');
    window.location.reload(true); // Reload trang sau khi cập nhật thành công
}
window.updateFlashcard = updateFlashcard;