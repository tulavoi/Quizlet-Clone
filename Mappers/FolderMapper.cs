using Microsoft.EntityFrameworkCore;
using QuizletClone.DTOs.Course;
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

		public static Folder ToFolderFromAddFolderToLibraryRequestDTO(this AddFolderToLibraryRequestDTO folderDTO)
		{
			return new Folder
			{
				Title = folderDTO.Title,
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				UserId = folderDTO.UserId,
                CourseFolders = folderDTO.CourseIds
                                .Select(courseId => new CourseFolder { CourseId = courseId })
                                .ToList()
			};
		}

        public static FolderDTO ToFolderDTO(this Folder folder)
        {
            return new FolderDTO
            {
                Id = folder.Id,
                Title = folder.Title,
                Slug = folder.Slug,
                CreatedAt = folder.CreatedAt
            };
        }

		public static FolderDetailDTO ToFolderDetailDTO(this Folder folder, List<UserCourseProgress>? courseProgress, 
            List<CourseFolder>? coursesInFolder)
        {
            var coursesAccessed = courseProgress?
                    .Select(c =>
                    {
                        var dto = c.Course!.ToCoursesAccessedDTO();
                        dto.IsInFolder = coursesInFolder?.Any(cf => cf.CourseId == dto.Id) ?? false;
                        return dto;
                    })
                    .ToList();

            return new FolderDetailDTO
            {
                Id = folder.Id,
                Title = folder.Title,
                CreatedAt = folder.CreatedAt.ToString("d/M/yy"),
                UpdatedAt = folder.UpdatedAt.ToString("d/M/yy"),
                Owner = folder.User!.ToUserDTO(),
				CoursesInFolder = coursesInFolder?.Select(cf => cf.ToCourseInFolderDTO()).ToList(),
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
