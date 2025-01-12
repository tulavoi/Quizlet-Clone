using Microsoft.EntityFrameworkCore;
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

        public async Task SaveProgressAsync(string userId, FlashcardProgressUpdateDTO progressDTO)
        {
            var progress = await _context.UserFlashcardProgresses
                .FirstOrDefaultAsync(x => x.UserId == userId && x.FlashcardId == progressDTO.FlashcardId);

            if (progress == null)
            {
                // Nếu chưa tồn tại, tạo mới
                progress = new UserFlashcardProgress
                {
                    UserId = userId,
                    FlashcardId = progressDTO.FlashcardId,
                    IsLearned = false,
                    IsStarred = false,
                    LastReviewedAt = DateTime.Now
                };
                _context.UserFlashcardProgresses.Add(progress);
            }
            else
            {
                // Nếu tồn tại, cập nhật dữ liệu
                progress.IsLearned = progressDTO.IsLearned;
                progress.IsStarred = progressDTO.IsStarred;
                progress.LastReviewedAt = progressDTO.LastReviewedAt;
            }

            await _context.SaveChangesAsync();
        }
    }
}
