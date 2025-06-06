using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizletClone.Models;

namespace QuizletClone.Areas.Identity.Data.EntityConfigurations
{
	public class UserLearningProgressConfiguration : IEntityTypeConfiguration<UserLearningProgress>
	{
		public void Configure(EntityTypeBuilder<UserLearningProgress> builder)
		{
			// Khai báo key cho UserLearningProgress
			builder.HasKey(x => new
			{
				x.UserId,
				x.CourseId,
			});

			builder.HasOne(u => u.User)
				.WithMany(u => u.UserLearningProgresses)
				.HasForeignKey(u => u.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(c => c.Course)
				.WithMany()
				.HasForeignKey(c => c.CourseId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
