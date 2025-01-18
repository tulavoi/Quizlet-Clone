// flashcardAction.js
// ==============================================
// Mô tả: File JavaScript này chứa các hàm và logic dành riêng cho
// phần xử lý các button trong file _FlashcardsPartial.cshtml.
// Bao gồm: các sự kiện click cho phát âm thanh, edit card.
// ==============================================

const actionButtons = document.querySelectorAll('.card-actions button');
// Gắn sự kiện click cho các button trong card-actions để ngăn lật thẻ
actionButtons.forEach(function (button) {
    button.addEventListener('click', function (event) {
        event.stopPropagation(); // Ngừng lan truyền sự kiện lên các phần tử cha
    });
});

// Phát âm thanh
export function textToSpeech(text, lang) {
    const utterance = new SpeechSynthesisUtterance(text);
    utterance.lang = lang; // Set language code (e.g., "en-US", "vi-VN")
    window.speechSynthesis.speak(utterance);
}
window.textToSpeech = textToSpeech;

