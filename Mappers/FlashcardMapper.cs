using QuizletClone.DTOs.Flashcard;
using QuizletClone.Models;

namespace QuizletClone.Mappers
{
    public static class FlashcardMapper
    {
        public static FlashcardDTO ToFlashcardDTO(this Flashcard flashcard, UserFlashcardProgress? progress = null)
        {
            return new FlashcardDTO
            {
                Id = flashcard.Id,
                Term = flashcard.Term,
                TermLanguageId = flashcard.Term_LangId,
                Definition = flashcard.Definition,
                DefiLanguageId = flashcard.Definition_LangId,
                TermLanguageCode = flashcard.Term_Lang?.Code ?? string.Empty,
                DefiLanguageCode = flashcard.Definition_Lang?.Code ?? string.Empty,
                IsStarred = progress?.IsStarred ?? false,
                IsLearned = progress?.IsLearned ?? false,
            };
        }
    }
}
