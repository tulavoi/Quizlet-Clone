
import { postData } from '../../shared/postData.js';

const btn = document.getElementById('addFolderToLibraryBtn');
btn.addEventListener('click', async function () {
    const title = document.getElementById('folderTitle').textContent;

    const courseListContainer = document.getElementById('courseInFolderList');
    const courses = courseListContainer.querySelectorAll('.card-item');
    const courseIds = Array.from(courses).map(course => {
        return parseInt(course.querySelector('input[name="courseId"]').value, 10);
    });
    //const payload = JSON.stringify({ Title: title, UserId: "asds", CourseIds: courseIds });
    //console.log("Title trước khi gửi:", title);
    //console.log("Payload gửi lên:", payload);
    await postData('/add-folder-to-library', { Title: title, UserId: "asds", CourseIds: courseIds }, "Adding folder to library failed");
});