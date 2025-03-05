namespace SmartCards.DTOs.Folder
{
	public class UserLibraryFolderDTO
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Slug { get; set; } = string.Empty;
		public int QuantityCourse { get; set; }
	}
}
