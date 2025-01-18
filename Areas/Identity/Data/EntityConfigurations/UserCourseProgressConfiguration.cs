using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCards.Models;

namespace SmartCards.Areas.Identity.Data.EntityConfigurations
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
             .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Course)
             .WithMany()
             .HasForeignKey(x => x.CourseId)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
