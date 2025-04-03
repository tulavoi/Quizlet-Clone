import { postData } from '../../shared/postData.js';

export async function ToggleCourseFolder(courseId, folderId, event = null) {
    try {
        // Gửi request lên server
        await postData("/course-folder/toggle-course-folder", { courseId, folderId });

        if (event) {
            const btnAddToFolder = event.currentTarget; // Lấy ra button đang được click
            const icon = btnAddToFolder.querySelector("i");

            // Kiểm tra trạng thái hiện tại của icon
            const isCurrentlyInFolder = icon.classList.contains("fa-circle-check");

            // Đảo trạng thái icon
            icon.classList.toggle("fa-circle-check", !isCurrentlyInFolder);
            icon.classList.toggle("fa-plus", isCurrentlyInFolder);
        } else {
            location.reload();
        }
    } catch (error) {
        console.error(error);
    }
}
window.ToggleCourseFolder = ToggleCourseFolder;