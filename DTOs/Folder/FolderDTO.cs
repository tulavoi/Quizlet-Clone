using QuizletClone.DTOs.Course;

namespace QuizletClone.DTOs.Folder
{
    public class FolderDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string UpdatedAt { get; set; } = string.Empty;
        public List<CoursesInFolderDTO>? Courses { get; set; }
    }
}
