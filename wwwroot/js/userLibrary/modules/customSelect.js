export function setupCustomSelect() {
    document.addEventListener("DOMContentLoaded", function () {
        const selectBox = document.querySelector(".custom-select");
        if (!selectBox) return; // Kiểm tra nếu không có selectBox thì không làm gì

        const selected = selectBox.querySelector(".selected");
        const options = selectBox.querySelector(".options");
        const optionItems = selectBox.querySelectorAll(".option");

        // Hiển thị hoặc ẩn dropdown khi click
        selectBox.addEventListener("click", function () {
            selectBox.classList.toggle("active");
        });

        // Xử lý khi chọn option
        optionItems.forEach(option => {
            option.addEventListener("click", function () {
                selected.textContent = this.textContent;
                selectBox.classList.remove("active");
            });
        });

        // Đóng dropdown khi click ra ngoài
        document.addEventListener("click", function (event) {
            if (!selectBox.contains(event.target)) {
                selectBox.classList.remove("active");
            }
        });
    });
}