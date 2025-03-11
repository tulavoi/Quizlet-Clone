using SmartCards.DTOs.Flashcard;
using System.ComponentModel.DataAnnotations;

namespace SmartCards.DTOs.Folder
{
    public class CreateFolderRequestDTO
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Tối đa 50 ký tự")]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string UserId { get; set; } = string.Empty;
    }
}
