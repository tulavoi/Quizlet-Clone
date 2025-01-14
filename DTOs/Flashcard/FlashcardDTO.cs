using System.ComponentModel.DataAnnotations;

namespace SmartCards.DTOs.Flashcard
{
    public class FlashcardDTO
    {
		public int Id { get; set; }
        public string? Term { get; set; } = string.Empty;
        public string? Definition { get; set; } = string.Empty;
        [Required]
		public int TermLanguageId { get; set; }
        [Required]
		public int DefiLanguageId { get; set; }
        public string? TermLanguageCode { get; set; } = string.Empty;
        public string? DefiLanguageCode { get; set; } = string.Empty;
        public bool? IsStarred { get; set; } = false;
        public bool? IsLearned { get; set; } = false;
    }
}
