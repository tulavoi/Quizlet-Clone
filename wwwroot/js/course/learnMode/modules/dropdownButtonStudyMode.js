// dropdownButtonStudyMode.js
// ==============================================
// Mô tả: File JavaScript này chứa các hàm và logic dành riêng cho
// chức năng xổ xuống khi click vào button
// ==============================================

document.querySelectorAll('.dropdown-toggle').forEach(button => {
    button.addEventListener('click', function (event) {
        // Toggle the dropdown menu
        const dropdown = this.parentElement;
        dropdown.classList.toggle('show');
    });
});

// Close dropdown when clicking outside
window.addEventListener('click', function (event) {
    const dropdowns = document.querySelectorAll('.dropdown');
    dropdowns.forEach(dropdown => {
        if (!dropdown.contains(event.target)) {
            dropdown.classList.remove('show');
        }
    });
});