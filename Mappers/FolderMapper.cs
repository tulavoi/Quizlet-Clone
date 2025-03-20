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
                    .Select(cf =>
                    {
                        // Lọc danh sách courseProgress có cùng CourseId với cf
                        var progress = courseProgress?.Where(cp => cp.CourseId == cf.CourseId) 
                            ?? Enumerable.Empty<UserCourseProgress>();

                        // Lấy LastUpdated, nếu không có thì dùng DateTime.MinValue
                        var lastUpdated = progress.OrderByDescending(cp => cp.LastUpdated)
                                                  .FirstOrDefault()?.LastUpdated ?? DateTime.MinValue;
                        return new
                        {
                            CourseDTO = cf.Course!.ToCoursesInFolderDTO(),
                            LastUpdated = lastUpdated
                        };
                    })
                    .OrderByDescending(x => x.LastUpdated)
                    .Select(x => x.CourseDTO)
                    .ToList();

            var coursesAccessed = courseProgress?
                    .Select(c =>
                    {
                        var dto = c.Course!.ToCoursesAccessedDTO();
                        dto.IsInFolder = coursesInFolder.Any(c => c.Id == dto.Id);
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
