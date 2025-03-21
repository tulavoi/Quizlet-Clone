using QuizletClone.DTOs.Folder;
using QuizletClone.DTOs.User;
using QuizletClone.Models;

namespace QuizletClone.Mappers
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

        public static FolderDTO ToFolderDTO(this Folder folder, List<UserCourseProgress>? courseProgress)
        {
            var coursesInFolder = folder.CourseFolders
                .Where(cf => cf.FolderId == folder.Id)
                .Select(c => c.Course!.ToCoursesInFolderDTO())
                .ToList();

			var coursesAccessed = courseProgress?
                    .Select(c =>
                    {
                        var dto = c.Course!.ToCoursesAccessedDTO();
                        dto.IsInFolder = coursesInFolder!.Any(c => c.Id == dto.Id);
                        return dto;
                    })
                    .ToList();

            return new FolderDTO
            {
                Id = folder.Id,
                Title = folder.Title,
                CreatedAt = folder.CreatedAt.ToString("d/M/yy"),
                UpdatedAt = folder.UpdatedAt.ToString("d/M/yy"),
                Owner = folder.User!.ToUserDTO(),
				CoursesInFolder = coursesInFolder,
                CoursesAccessed = coursesAccessed
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
