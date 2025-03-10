using System.ComponentModel.DataAnnotations;

namespace SmartCards.DTOs.Folder
{
	public class UpdateFolderRequestDTO
	{
		[Required]
		[MaxLength(50)]
		public string Title { get; set; } = string.Empty;
	}
}
