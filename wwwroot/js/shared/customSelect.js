document.addEventListener("DOMContentLoaded", function () {
    const customSelect = document.querySelector(".custom-select");
    if (!customSelect) return; // Kiểm tra nếu không có customSelect thì không làm gì

    const selected = customSelect.querySelector(".selected");
    const optionItems = customSelect.querySelectorAll(".option");

    // Hiển thị hoặc ẩn dropdown khi click
    selected.addEventListener('click', toggleDropdown);

    // Xử lý khi chọn option
    optionItems.forEach(option => {
        option.addEventListener("click", selectOption);
    });

    // Đóng dropdown khi click ra ngoài
    document.addEventListener("click", function (event) {
        if (!customSelect.contains(event.target)) {
            toggleDropdown();
        }
    });

    function toggleDropdown() {
        customSelect.classList.toggle("active");
    }

    function selectOption(event) {
        const selectedText = event.target.textContent;
        const icon = selected.querySelector('i');
        selected.textContent = selectedText + " ";
        selected.appendChild(icon);

        const selectedValue = event.target.getAttribute("data-value");

        if (selectedValue) {
            sortCourses(selectedValue);
        }

        toggleDropdown();
    }

    function sortCourses(sortBy) {
        const courseListContainer = document.getElementById('courseInFolderList');
        if (!courseListContainer) return;
        console.log(sortBy);

        const courses = Array.from(courseListContainer.querySelectorAll('.card-item'));
        courses.sort((a, b) => {
            switch (sortBy) {
                case "updated":
                    const dateA = new Date(a.getAttribute("data-updated"));
                    const dateB = new Date(b.getAttribute("data-updated"));
                    return dateB - dateA; // Sắp xếp giảm dần (mới nhất trước)
                case "title":
                    const titleA = a.querySelector('.title span').textContent.trim().toLowerCase();
                    const titleB = b.querySelector('.title span').textContent.trim().toLowerCase();
                    return titleA.localeCompare(titleB); // Sắp xếp theo chữ cái
                default:
                    return 0;
            }
        });

        // Xóa danh sách cũ và gắn danh sách đã sắp xếp vào lại
        courseListContainer.innerHTML = "";
        courses.forEach(course => courseListContainer.appendChild(course));
    }
});