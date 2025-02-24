using api.Helpers;
using Microsoft.EntityFrameworkCore;
using SmartCards.Models;

namespace SmartCards.Interfaces
{
    public interface IUserCourseProgressRepository
    {
        Task<UserCourseProgress> GetByIdAsync(string userId, int courseId);
        Task UpdateProgressAsync(string userId, int courseId, bool isShuffle = false);

        Task<List<UserCourseProgress>?> GetAllByUserAsync(string userId, CourseQueryObject query);
    }
}
