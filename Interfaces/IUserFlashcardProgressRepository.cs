using SmartCards.DTOs.Flashcard;

namespace SmartCards.Interfaces
{
    public interface IUserFlashcardProgressRepository
    {
        Task SaveProgressAsync(string userId, FlashcardProgressUpdateDTO progressDTO);
    }
}
