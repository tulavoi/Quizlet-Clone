
import { postData } from '../../shared/postData.js';

const btn = document.getElementById('addFolderToLibraryBtn');
if (btn) {
    btn.addEventListener('click', async function () {
        const title = document.getElementById('folderTitle').textContent;

        const courseListContainer = document.getElementById('courseInFolderList');
        const courses = courseListContainer.querySelectorAll('.card-item');
        const courseIds = Array.from(courses).map(course => {
            return parseInt(course.querySelector('input[name="courseId"]').value, 10);
        });

        const result = await postData('/add-folder-to-library', { Title: title, UserId: "", CourseIds: courseIds });
        if (result?.redirectUrl) {
            window.location.href = result.redirectUrl;
        }
    });
}