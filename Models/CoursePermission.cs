using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizletClone.Models
{
	[Table("CoursePermissions")]
	public class CoursePermission
	{
		[Required]
        public int CourseId { get; set; }
		public Course? Course { get; set; }

		[Required]
		public int ViewPermissionId { get; set; }
		public Permission? ViewPermission { get; set; }

		[Required]
		public int EditPermissionId { get; set; }
		public Permission? EditPermission { get; set; }
	}
}
