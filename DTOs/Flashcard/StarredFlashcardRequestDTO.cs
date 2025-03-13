namespace QuizletClone.DTOs.Flashcard
{
    public class StarredFlashcardRequestDTO
    {
        public int FlashcardId { get; set; }
        public bool IsLearned { get; set; }
        public bool IsStarred { get; set; }
        public DateTime? LastReviewedAt { get; set; }
    }
}
