namespace SmartCards.Helpers
{
    public class FlashcardQueryObject
    {
        public int Id { get; set; }
        public string UserId { get; set; }  = string.Empty;
        public int CourseId { get; set; }
        public bool IsLearned { get; set; }
    }
}
