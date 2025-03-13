using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizletClone.Models;

namespace QuizletClone.Areas.Identity.Data.EntityConfigurations
{
	public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
	{
		public void Configure(EntityTypeBuilder<Permission> builder)
		{
			// Seed dữ liệu cho table Permissions
			builder.HasData(
				new Permission { Id = 1, Type = PermissionType.Everyone, Name = "Mọi người", Description = "Mọi người đều có thể sử dụng học phần này", IsEdit = false },
				new Permission { Id = 2, Type = PermissionType.WithPassword, Name = "Người có mật khẩu", Description = "Chỉ những người có mật khẩu mới có thể sử dụng học phần này", IsEdit = false },
				new Permission { Id = 3, Type = PermissionType.OnlyMe, Name = "Chỉ tôi", Description = "Chỉ tôi mới có thể sử dụng học phần này", IsEdit = false },
				new Permission { Id = 4, Type = PermissionType.OnlyMe, Name = "Chỉ tôi", Description = "Chỉ tôi mới có thể chỉnh sửa học phần này", IsEdit = true },
				new Permission { Id = 5, Type = PermissionType.WithPassword, Name = "Người có mật khẩu", Description = "Chỉ những người có mật khẩu mới có thể chỉnh sửa học phần này", IsEdit = true }
			);
        }
	}
}
