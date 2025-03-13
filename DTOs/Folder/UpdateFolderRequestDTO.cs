using System.ComponentModel.DataAnnotations;

namespace QuizletClone.DTOs.Folder
{
	public class UpdateFolderRequestDTO
	{
		[Required]
		[MaxLength(50)]
		public string Title { get; set; } = string.Empty;
	}
}
