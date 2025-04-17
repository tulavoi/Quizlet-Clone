using QuizletClone.DTOs.Flashcard;

namespace QuizletClone.DTOs.Course
{
    public class StudyModeDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Slug { get; set; } = string.Empty;
        public List<FlashcardDTO> Flashcards { get; set; } = new();
    }
}
