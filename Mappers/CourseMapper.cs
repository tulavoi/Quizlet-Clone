using Microsoft.Build.Graph;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using QuizletClone.DTOs.Course;
using QuizletClone.DTOs.Flashcard;
using QuizletClone.DTOs.LearningMode;
using QuizletClone.Extensions;
using QuizletClone.Models;

namespace QuizletClone.Mappers
{
    public static class CourseMapper
    {
        public static CourseInFolderDTO ToCourseInFolderDTO(this CourseFolder courseFolder)
        {
            return new CourseInFolderDTO
            {
                Id = courseFolder.Course!.Id,
                OwnerUserId = courseFolder.Course.UserId,
                OwnerUsername = courseFolder.Course.User?.UserName ?? string.Empty,
                Title = courseFolder.Course.Title,
                Slug = courseFolder.Course.Slug,
                FlashcardCount = courseFolder.Course.Flashcards.Count,
                ViewPermissionType = courseFolder.Course.CoursePermission.ViewPermission?.Type,
                UpdatedAt = courseFolder.UpdatedAt,
			};
		}
        
        public static CoursesAccessedDTO ToCoursesAccessedDTO(this Course course)
        {
            return new CoursesAccessedDTO
            {
                Id = course.Id,
				OwnerUserId = course.UserId,
				OwnerUsername = course.User?.UserName ?? string.Empty,
				Title = course.Title,
                FlashcardCount = course.Flashcards.Count,
            };
		}

        public static CourseDetailDTO ToCourseDetailDTO(this Course course,
            List<Flashcard> flashcards,
            Flashcard? lastLearnedCard = null,
            List<Flashcard>? learnedFlashcards = null,
            List<Flashcard>? notLearnedFlashcards = null,
            List<UserFlashcardProgress>? flashcardProcresses = null,
            int starredCardsCount = 0,
            bool isShuffle = false)
        {
            return new CourseDetailDTO
            {
                Id = course.Id,
                OwnerUserId = course.UserId,
                OwnerUsername = course.User?.UserName ?? string.Empty,
                Title = course.Title,
                Password = course.Password,
                Slug = course.Slug,
                Description = course.Description,
                RelativeTime = course.CreatedAt.ToRelativeTime(),

                Flashcards = flashcards.Select(x => {
                    var progress = flashcardProcresses?.FirstOrDefault(p => p. FlashcardId == x.Id);
                    return x.ToFlashcardDTO(progress);
                }).ToList(),

                LearnedFlashcards = learnedFlashcards?.Select(x => {
                    var progress = flashcardProcresses?.FirstOrDefault(p => p. FlashcardId == x.Id);
                    return x.ToFlashcardDTO(progress);
                }).ToList(),

                NotLearnedFlashcards = notLearnedFlashcards?.Select(x => {
                    var progress = flashcardProcresses?.FirstOrDefault(p => p. FlashcardId == x.Id);
                    return x.ToFlashcardDTO(progress);
                }).ToList(),

                LastLearnedFlashcard = lastLearnedCard?.ToFlashcardDTO(),
                StarredFlashcardCount = starredCardsCount,
                FlashcardCount = flashcards.Count,
                IsShuffle = isShuffle
            };
        }

        public static LearningModeDTO ToLearningModeDTO(this Course course, LearningQuestionDTO questionDTO, UserLearningProgress? progress)
        {
            return new LearningModeDTO
            {
                CourseId = course.Id,
                Title = course.Title,
                Slug = course.Slug,
                LearningQuestion = questionDTO,
                CorrectAnswerCount = progress?.CorrectAnswerCount ?? 0,
                CurrentQuestionIndex = progress?.CurrentQuestionIndex ?? 0
			};
        }

        public static RecentCourseDTO ToRecentCourseDTO(this UserCourseProgress courseProgress)
        {
            return new RecentCourseDTO
            {
                Id = courseProgress.Course!.Id,
                OwnerDTO = courseProgress.Course.User!.ToUserDTO(),
                Title = courseProgress.Course.Title,
                Password = courseProgress.Course.Password,
                Slug = courseProgress.Course.Slug,
                RelativeTime = courseProgress.Course.CreatedAt.ToRelativeTime(),
                FlashcardCount = courseProgress.Course.Flashcards.Count
            };
        }

        public static PopularCourseDTO ToPopularCourseDTO(this Course course)
        {
            return new PopularCourseDTO
            {
                Id = course!.Id,
                OwnerDTO = course.User!.ToUserDTO(),
                Title = course.Title,
                Password = course.Password,
                Slug = course.Slug,
                FlashcardCount = course.Flashcards.Count
            };
        }

        public static Course ToCourseFromCreateDTO(this CreateCourseRequestDTO courseDTO, string userId)
        {
            return new Course
            {
                Title = courseDTO.Title,
                Description = courseDTO.Description,
                Password = courseDTO.Password,
                UserId = userId,
                Flashcards = courseDTO.Flashcards.Select(fc => new Flashcard
                {
                    Term = fc.Term,
                    Definition = fc.Definition,
                    Term_LangId = fc.TermLanguageId,
                    Definition_LangId = fc.DefiLanguageId
                }).ToList(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CoursePermission = new CoursePermission
                {
                    ViewPermissionId = courseDTO.ViewPermissionId,
                    EditPermissionId = courseDTO.EditPermissionId
                }
            };
        }

        public static UserLibraryCoursesDTO ToUserLibraryCoursesDTO(this UserCourseProgress courseProgress)
        {
            return new UserLibraryCoursesDTO
            {
                Id = courseProgress.Course!.Id,
                OwnerUserId = courseProgress.Course.UserId,
                OwnerUsername = courseProgress.Course.User?.UserName ?? string.Empty,
                Title = courseProgress.Course.Title,
                Slug = courseProgress.Course.Slug,
                FlashcardCount = courseProgress.Course.Flashcards.Count,
                ViewPermissionType = courseProgress.Course.CoursePermission.ViewPermission?.Type,
                LastUpdated = courseProgress.LastUpdated
            };
        }

        public static UserLibraryCoursesDTO ToUserLibraryCoursesDTO(this Course course)
        {
            return new UserLibraryCoursesDTO
            {
                Id = course.Id,
                OwnerUserId = course.UserId,
                OwnerUsername = course.User?.UserName ?? string.Empty,
                Title = course.Title,
                Slug = course.Slug,
                FlashcardCount = course.Flashcards.Count,
                ViewPermissionType = course.CoursePermission.ViewPermission?.Type,
                CreatedAt = course.CreatedAt
            };
        }
    }
}
