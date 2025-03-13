using api.Helpers;
using Microsoft.EntityFrameworkCore;
using QuizletClone.Models;

namespace QuizletClone.Interfaces
{
    public interface IUserCourseProgressRepository
    {
        Task<UserCourseProgress> GetByIdAsync(string userId, int courseId);
        Task UpdateProgressAsync(string userId, int courseId, bool isShuffle = false);
        Task<List<UserCourseProgress>?> GetAllByUserAsync(string userId, CourseQueryObject query);
    }
}
