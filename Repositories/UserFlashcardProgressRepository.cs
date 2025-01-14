using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SmartCards.Areas.Identity.Data;
using SmartCards.DTOs.Flashcard;
using SmartCards.Interfaces;
using SmartCards.Models;

namespace SmartCards.Repositories
{
    public class UserFlashcardProgressRepository : IUserFlashcardProgressRepository
    {
        private readonly AppDbContext _context;
        public UserFlashcardProgressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserFlashcardProgress>> GetByIdAsync(string userId, int courseId)
        {
            return await _context.UserFlashcardProgresses
                .Where(x => x.UserId == userId && x.Flashcard.CourseId == courseId)
                .ToListAsync() ?? new List<UserFlashcardProgress>();
        }

        // Lưu lại flashcard đã học
        public async Task SaveLearnedCardAsync(string userId, int flashcardId)
        {
            var progress = await _context.UserFlashcardProgresses
                    .FirstOrDefaultAsync(x => x.UserId == userId && x.FlashcardId == flashcardId);

            if (progress == null)
            {
                progress = new UserFlashcardProgress
                {
                    FlashcardId = flashcardId,
                    UserId = userId,
                    IsLearned = true,
                    IsStarred = false,
                    LastReviewedAt = DateTime.Now
                };
                _context.UserFlashcardProgresses.Add(progress);
            }
            else
                progress.IsLearned = true;

            await _context.SaveChangesAsync();
        }

        // Lưu lại flashcard cuối cùng đã xem
        public async Task SaveLastReviewdCardAsync(string userId, int flashcardId)
        {
            var progress = await _context.UserFlashcardProgresses
                    .FirstOrDefaultAsync(x => x.UserId == userId && x.FlashcardId == flashcardId);

            if (progress == null)
            {
                progress = new UserFlashcardProgress
                {
                    FlashcardId = flashcardId,
                    UserId = userId,
                    IsLearned = false,
                    IsStarred = false,
                    LastReviewedAt = DateTime.Now
                };
                _context.UserFlashcardProgresses.Add(progress);
            }

            await _context.SaveChangesAsync();
        }
    }
}
