
const searchCourseInput = document.getElementById("searchCourseInput");
if (searchCourseInput) {
    searchCourseInput.addEventListener("input", function () {
        let keyword = this.value.toLowerCase();
        let courses = document.querySelectorAll(".course-item");
        let groups = document.querySelectorAll(".course-group");

        courses.forEach(course => {
            let titleElement = course.querySelector('.title span');
            let titleText = titleElement.innerText;
            let titleLower = titleText.toLowerCase();

            if (!keyword || titleLower.includes(keyword)) {
                course.style.display = "block";

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
                course.style.display = "none";
            }

        });

        // Ẩn course-group nếu tất cả course trong course-group bị ẩn
        groups.forEach(group => {
            let visibleCourses = group.querySelectorAll(".course-item[style='display: block;']"); // Lấy các course đang hiển thị
            group.style.display = visibleCourses.length > 0 ? "block" : "none";
        });
    });
}
