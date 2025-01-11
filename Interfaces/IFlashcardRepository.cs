using SmartCards.Helpers;
using SmartCards.Models;

namespace SmartCards.Interfaces
{
    public interface IFlashcardRepository
    {
        Task<Flashcard> GetLastLearnedAsync(FlashcardQueryObject query);
        Task<List<Flashcard>> GetAllInCourseAsync(FlashcardQueryObject query); 
        Task SaveLastLearnedAsync(string userId, int flashcardId);
    }
}
