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
            Flashcard? lastLearnedCard = null,
            List<Flashcard>? learnedFlashcards = null,
            List<Flashcard>? notLearnedFlashcards = null,
            List<UserFlashcardProgress>? progresses = null)
        {
            return new CourseDTO
            {
                Id = course.Id,
                UserId = course.UserId,
                Username = course.User?.UserName ?? string.Empty,
                Title = course.Title,
                Password = course.Password,
                Slug = course.Slug,
                Description = course.Description,
                RelativeTime = course.CreatedAt.ToRelativeTime(),

                Flashcards = course.Flashcards.Select(x => {
                    var progress = progresses?.FirstOrDefault(p => p.FlashcardId == x.Id);
                    return x.ToFlashcardDTO(progress);
                }).ToList(),

                LearnedFlashcards = learnedFlashcards?.Select(x => {
                    var progress = progresses?.FirstOrDefault(p => p.FlashcardId == x.Id);
                    return x.ToFlashcardDTO(progress);
                }).ToList(),

                NotLearnedFlashcards = notLearnedFlashcards?.Select(x => {
                    var progress = progresses?.FirstOrDefault(p => p.FlashcardId == x.Id);
                    return x.ToFlashcardDTO(progress);
                }).ToList(),

                LastLearnedFlashcard = lastLearnedCard?.ToFlashcardDTO()
            };
        }

        public static RecentCourseDTO ToRecentCourseDTO(this Course course)
        {
            return new RecentCourseDTO
            {
                Id = course.Id,
                UserId = course.UserId,
                Username = course.User?.UserName ?? string.Empty,
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
    }
}
