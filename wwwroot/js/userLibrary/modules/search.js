
const searchInput = document.getElementById("searchInputInLibrary");
if (searchInput) {
    searchInput.addEventListener("input", function () {
        let keyword = this.value.toLowerCase();
        let items = document.querySelectorAll('.card-item');
        let groups = document.querySelectorAll(".course-group");

        items.forEach(item => {
            let titleElement = item.querySelector('.title span');
            let titleText = titleElement.innerText;
            let titleLower = titleText.toLowerCase();
            if (!keyword || titleLower.includes(keyword)) {
                item.style.display = "block";

                // Bôi đen phần khớp với keyword
                if (keyword) {
                    let highlightedTitle = titleText.replace(
                        new RegExp(`(${keyword})`, "gi"),
                        `<span class="highlight">$1</span>`
                    );
                    titleElement.innerHTML = highlightedTitle; // Highlight title
                } else {
                    titleElement.innerHTML = titleText; // Trả lại title như ban đầu
                } 
            } else {
                item.style.display = "none";
            }
        });

        if (groups) {
            // Ẩn course-group nếu tất cả course trong course-group bị ẩn
            groups.forEach(group => {
                let visibleCourses = group.querySelectorAll(".card-item[style='display: block;']"); // Lấy các course đang hiển thị
                group.style.display = visibleCourses.length > 0 ? "block" : "none";
            });
        }
    });
}
