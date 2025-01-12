namespace SmartCards.DTOs.Flashcard
{
    public class FlashcardProgressUpdateDTO
    {
        public int FlashcardId { get; set; }
        public bool IsLearned { get; set; }
        public bool IsStarred { get; set; }
        public DateTime? LastReviewedAt { get; set; }
    }
}
