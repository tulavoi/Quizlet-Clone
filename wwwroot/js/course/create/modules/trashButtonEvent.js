
// Hàm gắn sự kiện cho các nút btn-trash
export function bindTrashButtonEvent() {
    document.querySelectorAll('.btn-trash').forEach(function (btn) {
        btn.addEventListener('click', function () {
            // Tìm phần tử cha gần nhất có class "term-item"
            const termItem = btn.closest('.term-item');

            // Xóa phần tử
            termItem.remove();

            // Cập nhật lại số thứ tự
            document.querySelectorAll('.term-item').forEach(function (item, index) {
                item.querySelector('.term-item-count').textContent = index + 1; // Cập nhật lại số thứ tự bắt đầu từ 1
            });
        });
    });
}