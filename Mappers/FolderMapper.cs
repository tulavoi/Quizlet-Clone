using SmartCards.DTOs.Folder;
using SmartCards.Models;

namespace SmartCards.Mappers
{
    public static class FolderMapper
    {
        public static Folder ToFolderFromCreateDTO(this CreateFolderRequestDTO folderDTO)
        {
            return new Folder
            {
                Title = folderDTO.Title,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = folderDTO.UserId,
            };
        }

        public static FolderDTO ToFolderDTO(this Folder folder)
        {
            return new FolderDTO
            {
                Id = folder.Id,
                Title = folder.Title,
                CreatedAt = folder.CreatedAt,
                UpdatedAt = folder.UpdatedAt.ToString("d/M/yy"),
				Courses = folder.CourseFolders
                    .Select(c => c.Course!.ToCoursesInFolderDTO())
                    .ToList()
			};
        }

        public static UserLibraryFolderDTO ToUserLibraryFolderDTO(this Folder folder)
        {
            return new UserLibraryFolderDTO
            {
                Id = folder.Id,
                Title = folder.Title,
                Slug = folder.Slug,
                QuantityCourse = folder.CourseFolders.Count(),
            };
        }

	}
}
