using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizletClone.Models;

namespace QuizletClone.Areas.Identity.Data.EntityConfigurations
{
    public class UserCourseProgressConfiguration : IEntityTypeConfiguration<UserCourseProgress>
    {
        public void Configure(EntityTypeBuilder<UserCourseProgress> builder)
        {
            // Khai báo key cho UserCourseProgress
            builder.HasKey(x => new
            {
                x.UserId,
                x.CourseId,
            });

            builder.HasOne(x => x.User)
             .WithMany()
             .HasForeignKey(x => x.UserId)
             .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Course)
             .WithMany()
             .HasForeignKey(x => x.CourseId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
