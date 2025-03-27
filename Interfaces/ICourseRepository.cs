using api.Helpers;
using QuizletClone.DTOs.Course;
using QuizletClone.Models;

namespace QuizletClone.Interfaces
{
    public interface ICourseRepository
    {
        Task CreateAsync(Course course, int viewPerId, int editPerId);
        Task<List<Course>?> GetAllByUserAsync(string userId, CourseQueryObject query);
        Task<Course?> GetByIdAsync(int id, CourseQueryObject? query = null);
        string GetErrorMessage(CreateCourseRequestDTO courseDTO);
    }
}
