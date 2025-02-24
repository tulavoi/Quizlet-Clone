using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCards.Models
{
	public enum PermissionType
	{
		OnlyMe = 1,
		Everyone = 2,
		WithPassword = 3
	}

	[Table("Permissions")]
	public class Permission
	{
		public int Id { get; set; }

		public PermissionType Type { get; set; }

		[MaxLength(50)]
		[Required]
        public string Name { get; set; } = string.Empty;
		[MaxLength(100)]
		public string Description { get; set; } = string.Empty;
		[MaxLength(50)]
		public bool IsEdit { get; set; }
	}
}
