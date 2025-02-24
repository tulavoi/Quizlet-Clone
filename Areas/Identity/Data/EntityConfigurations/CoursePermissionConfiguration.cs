using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCards.Models;
using System.Reflection.Emit;

namespace SmartCards.Areas.Identity.Data.EntityConfigurations
{
	public class CoursePermissionConfiguration : IEntityTypeConfiguration<CoursePermission>
	{
		public void Configure(EntityTypeBuilder<CoursePermission> builder)
		{
            builder.HasKey(cp => cp.CourseId);

            builder.HasOne(cp => cp.Course)
                .WithOne(c => c.CoursePermission)
                .HasForeignKey<CoursePermission>(cp => cp.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cp => cp.ViewPermission)
                .WithMany()
                .HasForeignKey(cp => cp.ViewPermissionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(cp => cp.EditPermission)
                .WithMany()
                .HasForeignKey(cp => cp.EditPermissionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
	}
}
