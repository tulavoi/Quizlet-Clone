using QuizletClone.DTOs.Course;
using QuizletClone.DTOs.User;

namespace QuizletClone.DTOs.Folder
{
    public class FolderDetailDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
		public string UpdatedAt { get; set; } = string.Empty;
        public UserDTO Owner { get; set; } = new UserDTO();
        public List<CourseInFolderDTO>? CoursesInFolder { get; set; }
        public List<CoursesAccessedDTO>? CoursesAccessed { get; set; }
    }
}
