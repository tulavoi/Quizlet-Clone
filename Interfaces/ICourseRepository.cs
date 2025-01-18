using api.Helpers;
using SmartCards.DTOs.Course;
using SmartCards.Models;

namespace SmartCards.Interfaces
{
    public interface ICourseRepository
    {
        Task CreateAsync(Course course, int viewPerId, int editPerId);
        Task<Course?> GetByIdAsync(int id, CourseQueryObject? query = null);
        Task<List<Course>> GetAllAsync(string userId, CourseQueryObject query);
        string GetErrorMessage(CreateCourseRequestDTO courseDTO); 
    }
}
