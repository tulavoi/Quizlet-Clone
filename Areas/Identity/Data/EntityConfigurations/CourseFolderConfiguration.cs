using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizletClone.Models;
using System.Reflection.Emit;

namespace QuizletClone.Areas.Identity.Data.EntityConfigurations
{
	public class CourseFolderConfiguration : IEntityTypeConfiguration<CourseFolder>
	{
		public void Configure(EntityTypeBuilder<CourseFolder> builder)
		{
            builder.HasKey(cf => new { 
                cf.FolderId, 
                cf.CourseId 
            });

            //builder.HasOne(x => x.Course)
            // .WithMany(x => x.CourseFolders)
            // .HasForeignKey(x => x.CourseId)
            // .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(x => x.Folder)
            // .WithMany(x => x.CourseFolders)
            // .HasForeignKey(x => x.FolderId)
            // .OnDelete(DeleteBehavior.Cascade);
        }
	}
}
