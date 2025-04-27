using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizletClone.Models;

namespace QuizletClone.Areas.Identity.Data.EntityConfigurations
{
	public class LanguageConfiguration : IEntityTypeConfiguration<Language>
	{
		public void Configure(EntityTypeBuilder<Language> builder)
		{
			var defaultValue = new DateTime(2025, 1, 1, 0, 0, 0);
			
			builder.HasData(
				new Language { Id = 1, Code = "en", Name = "English", CreatedAt = defaultValue, UpdatedAt = defaultValue },
				new Language { Id = 2, Code = "fr", Name = "French", CreatedAt = defaultValue, UpdatedAt = defaultValue },
				new Language { Id = 3, Code = "de", Name = "German", CreatedAt = defaultValue, UpdatedAt = defaultValue },
				new Language { Id = 4, Code = "es", Name = "Spanish", CreatedAt = defaultValue, UpdatedAt = defaultValue },
				new Language { Id = 5, Code = "it", Name = "Italian", CreatedAt = defaultValue, UpdatedAt = defaultValue },
				new Language { Id = 6, Code = "pt", Name = "Portuguese", CreatedAt = defaultValue, UpdatedAt = defaultValue },
				new Language { Id = 7, Code = "zh", Name = "Chinese", CreatedAt = defaultValue, UpdatedAt = defaultValue },
				new Language { Id = 8, Code = "ja", Name = "Japanese", CreatedAt = defaultValue, UpdatedAt = defaultValue },
				new Language { Id = 9, Code = "ru", Name = "Russian", CreatedAt = defaultValue, UpdatedAt = defaultValue },
				new Language { Id = 10, Code = "ar", Name = "Arabic", CreatedAt = defaultValue, UpdatedAt = defaultValue },
				new Language { Id = 11, Code = "vn", Name = "Vietnamese", CreatedAt = defaultValue, UpdatedAt = defaultValue }
			);
		}
	}
}
