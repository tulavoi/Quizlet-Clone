using QuizletClone.DTOs.LearningMode;
using QuizletClone.Helpers;
using QuizletClone.Interfaces;
using QuizletClone.Models;
using System;

namespace QuizletClone.Services
{
	public class QuizService : IQuizService
	{
		private readonly ICourseRepository _courseRepo;
		private readonly IFlashcardRepository _flashcardRepo;
		private readonly IUserLearningProgressRepository _learningProgress;

		public QuizService(ICourseRepository courseRepo, IFlashcardRepository flashcardRepo, IUserLearningProgressRepository learningProgress)
		{
			_courseRepo = courseRepo;
			_flashcardRepo = flashcardRepo;
			_learningProgress = learningProgress;
		}

		// Update hàm: tạo ra thêm các câu hỏi tự luận
		public async Task<List<LearningQuestionDTO>> GenerateQuestionDTOsAsync(string userId, int courseId)
		{
			// Lấy các flashcard trong course
			var flashcards = await _flashcardRepo.GetAllCardsInCourseAsync(userId, courseId, new FlashcardQueryObject());

			var questions = new List<LearningQuestionDTO>();
			var random = new Random();

			foreach (var flashcard in flashcards)
			{
				// Tạo ra các đáp án sai
				var wrongAnswers = flashcards
					.Where(fc => fc.Id != flashcard.Id)
					.OrderBy(_ => random.Next())
					.Take(3)
					.Select(fc => fc.Term)
					.ToList();

				// Tạo ra các đáp án
				var answers = wrongAnswers
					.Append(flashcard.Definition)
					.OrderBy(_ => random.Next())
					.ToList();

				// Tạo câu hỏi và thêm vào questions
				questions.Add(new LearningQuestionDTO
				{
					Question = flashcard.Definition ?? string.Empty,
					Answers = wrongAnswers!,
					CorrectAnswer = flashcard.Term ?? string.Empty
				});
			}

			return questions;
		}
	}
}
