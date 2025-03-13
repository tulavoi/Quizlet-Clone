using api.Helpers;
using QuizletClone.Models;

namespace QuizletClone.Interfaces
{
    public interface ICoursePermissionRepository
    {
        Task CreateAsync(CoursePermission coursePermission);
    }
}
