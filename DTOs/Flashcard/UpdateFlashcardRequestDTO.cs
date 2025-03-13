namespace QuizletClone.DTOs.Flashcard
{
    public class UpdateFlashcardRequestDTO
    {
        public int Id { get; set; }
        public string Term { get; set; } = string.Empty;
        public string Definition { get; set; } = string.Empty;
    }
}
