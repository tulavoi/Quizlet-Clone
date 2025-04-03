
import { postData } from '../../../shared/postData.js';

export async function AddCourseToFolder(courseId, folderId) {
    try {
        // Gửi request lên server
        await postData("/course-folder/toggle-course-folder", { courseId, folderId });
        location.reload();
    } catch (error) {
        console.error(error);
    }
}
window.AddCourseToFolder = AddCourseToFolder;