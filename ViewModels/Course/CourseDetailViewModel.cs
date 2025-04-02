using QuizletClone.DTOs.Course;
using QuizletClone.DTOs.Folder;

namespace QuizletClone.ViewModels.Course
{
    public class CourseDetailViewModel
    {
        public CourseDetailDTO Course { get; set; } = new();
        public List<FolderDTO>? Folders { get; set; } = new();
        public List<FolderDTO>? FoldersContainingCourse { get; set; } = new();
    }
}
