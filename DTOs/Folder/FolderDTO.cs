using SmartCards.DTOs.Course;

namespace SmartCards.DTOs.Folder
{
    public class FolderDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<CourseDTO>? Courses { get; set; }
    }
}
