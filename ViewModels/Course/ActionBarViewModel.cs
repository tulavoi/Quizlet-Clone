using QuizletClone.DTOs.Folder;

namespace QuizletClone.ViewModels.Course
{
    public class ActionBarViewModel
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; } = string.Empty;
        public List<FolderDTO>? Folders { get; set; } = new();
        public List<FolderDTO>? FoldersContainingCourse { get; set; } = new();
    }
}
