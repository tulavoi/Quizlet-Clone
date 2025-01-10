using SmartCards.Models;

namespace SmartCards.Interfaces
{
    public interface IFlashcardRepository
    {
        Task<Flashcard> GetLastLearnedAsync(string userId, int courseId);
        Task SaveLastLearnedAsync(string userId, int flashcardId);
    }
}
