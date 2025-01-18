using Microsoft.EntityFrameworkCore;
using SmartCards.Areas.Identity.Data;
using SmartCards.Interfaces;
using SmartCards.Models;

namespace SmartCards.Repositories
{
    public class UserCourseProgressRepository : IUserCourseProgressRepository
    {
        private readonly AppDbContext _context;
        public UserCourseProgressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserCourseProgress> GetByIdAsync(string userId, int courseId)
        {
            return await _context.UserCourseProgresses
                .FirstOrDefaultAsync(x => x.UserId == userId && x.CourseId == courseId) 
                ?? new UserCourseProgress();
        }

        public async Task UpdateProgressAsync(string userId, int courseId, bool isShuffle)
        {
            var progress = await _context.UserCourseProgresses
                .FirstOrDefaultAsync(x => x.UserId == userId && x.CourseId == courseId);

            if (progress != null) 
            {
                progress.IsShuffle = isShuffle;
                progress.LastUpdated = DateTime.Now;
            } 
            else
            {
                var newProgress = new UserCourseProgress
                {
                    UserId = userId,
                    CourseId = courseId,
                    IsShuffle = isShuffle,
                    LastUpdated = DateTime.Now
                };
                _context.UserCourseProgresses.Add(newProgress);
            }

            await _context.SaveChangesAsync();
        }
    }
}
