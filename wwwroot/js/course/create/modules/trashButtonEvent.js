export function removeCard(event) {
    // Lấy button được click
    const btn = event.currentTarget;

    // Tìm phần tử cha gần nhất có class term-item
    const termItem = btn.closest('.term-item');
    if (!termItem) return;

    // Xóa phần tử
    termItem.remove();

    const btnTrash = document.querySelectorAll('.btn-trash');

    // Cập nhật lại số thứ tự và index của các thẻ còn lại
    document.querySelectorAll('.term-item').forEach(function (item, newIndex) {
        const countElement = item.querySelector('.term-item-count');
        if (countElement) {
            countElement.textContent = newIndex + 1; // Cập nhật lại số thứ tự bắt đầu từ 1
        }

        // Cập nhật lại name của các input
        item.querySelectorAll('input, select').forEach(function (input) {
            if (input.name.includes('Flashcards[')) {
                input.name = input.name.replace(/\d+/, `${newIndex}`);
            }
        });
    });
}
window.removeCard = removeCard;