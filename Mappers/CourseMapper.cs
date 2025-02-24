﻿using Microsoft.Build.Graph;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SmartCards.DTOs.Course;
using SmartCards.DTOs.Flashcard;
using SmartCards.Extensions;
using SmartCards.Models;

namespace SmartCards.Mappers
{
    public static class CourseMapper
    {
        public static CourseDTO ToCourseDTO(this Course course,
            List<Flashcard> flashcards,
            Flashcard? lastLearnedCard = null,
            List<Flashcard>? learnedFlashcards = null,
            List<Flashcard>? notLearnedFlashcards = null,
            List<UserFlashcardProgress>? flashcardProcresses = null,
            int starredCardsCount = 0,
            bool isShuffle = false,
            int flashcardCount = 0)
        {
            return new CourseDTO
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
                FlashcardCount = flashcardCount,
                IsShuffle = isShuffle
            };
        }

        public static LearnCourseDTO ToLearnCourseDTO(this Course course)
        {
            return new LearnCourseDTO
            {
                Id = course.Id,
                Title = course.Title,
                Slug = course.Slug,
                Flashcards = course.Flashcards.Select(x => x.ToFlashcardDTO()).ToList()
            };
        }

        public static RecentCourseDTO ToRecentCourseDTO(this Course course)
        {
            return new RecentCourseDTO
            {
                Id = course.Id,
                OwnerUserId = course.UserId,
                OwnerUsername = course.User?.UserName ?? string.Empty,
                Title = course.Title,
                Password = course.Password,
                Slug = course.Slug,
                RelativeTime = course.CreatedAt.ToRelativeTime(),
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
            };
        }

        public static UserLibraryCoursesDTO ToCourseInUserLibraryDTO(this Course course)
        {
            return new UserLibraryCoursesDTO
            {
                Id = course.Id,
                OwnerUserId = course.UserId,
                OwnerUsername = course.User?.UserName ?? string.Empty,
                Title = course.Title,
                Slug = course.Slug,
                FlashcardCount = course.Flashcards.Count,
                ViewPermissionType = course.CoursePermission.ViewPermission?.Type
            };
        }
    }
}
