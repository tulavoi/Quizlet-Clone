using QuizletClone.DTOs.CourseFolder;

namespace QuizletClone.Interfaces
{
    public interface ICourseFolderRepository
    {
        Task ToggleCourseFolder(ToggleCourseFolderRequestDTO requestDTO);
    }
}
