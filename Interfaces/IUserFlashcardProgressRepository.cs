using SmartCards.DTOs.Flashcard;
using SmartCards.Models;

namespace SmartCards.Interfaces
{
    public interface IUserFlashcardProgressRepository
    {
        Task<List<UserFlashcardProgress>> GetByIdAsync(string userId, int courseId);
        Task SaveLearnedCardAsync(string userId, int flashcardId);
        Task SaveLastReviewdCardAsync(string userId, int flashcardId);
    }
}
