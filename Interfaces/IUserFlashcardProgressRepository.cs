using QuizletClone.DTOs.Flashcard;
using QuizletClone.Models;

namespace QuizletClone.Interfaces
{
    public interface IUserFlashcardProgressRepository
    {
        Task<List<UserFlashcardProgress>> GetByCourseIdAsync(string userId, int courseId);
        Task<UserFlashcardProgress?> GetByFlashcardIdAsync(string userId, int flashcardId);
        Task SaveLearnedCardAsync(string userId, int flashcardId);
        Task SaveLastReviewdCardAsync(string userId, int flashcardId);
        Task StarredFlashcardAsync(string userId, StarredFlashcardRequestDTO request);
    }
}
