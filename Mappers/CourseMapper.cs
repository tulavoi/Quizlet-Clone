﻿using SmartCards.DTOs.Course;
using SmartCards.DTOs.Flashcard;
using SmartCards.Models;

namespace SmartCards.Mappers
{
    public static class CourseMapper
    {
        public static CourseDTO ToCourseDTO(this Course course, Flashcard? lastLearnedCard = null)
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
                Flashcards = course.Flashcards.Select(x => x.ToFlashcardDTO()).ToList(),
                LastLearnedFlashcard = lastLearnedCard?.ToFlashcardDTO()
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
