using Microsoft.AspNetCore.Connections.Features;
using QuizletClone.DTOs.LearningMode;
using QuizletClone.Helpers;
using QuizletClone.Interfaces;
using QuizletClone.Models;
using System;

namespace QuizletClone.Services
{
	public class QuestionService : IQuestionService
	{
		private readonly ICourseRepository _courseRepo;
		private readonly IFlashcardRepository _flashcardRepo;
		private readonly IUserLearningProgressRepository _learningProgress;

		public QuestionService(ICourseRepository courseRepo, IFlashcardRepository flashcardRepo, IUserLearningProgressRepository learningProgress)
		{
			_courseRepo = courseRepo;
			_flashcardRepo = flashcardRepo;
			_learningProgress = learningProgress;
		}

		// Update hàm: tạo ra thêm các câu hỏi tự luận
		public async Task<LearningQuestionDTO> GenerateQuestionDTOsAsync(string userId, int courseId, LearningModeQueryObject queryObject)
		{
			// Lấy các flashcard trong course
			var flashcards = await _flashcardRepo.GetAllCardsInCourseAsync(userId, courseId, new FlashcardQueryObject());

			if (flashcards == null) return new LearningQuestionDTO();

			var random = new Random();
			var orderedQuestions = new List<QuestionDTO>();
			var charBank = this.CreateCharacterBank(flashcards, random);

			int batchSize = 5;

			// Vòng lặp qua tất cả flashcards, bước nhảy là 5 (vì mỗi batch có tối đa 5 phần tử)
			for (int i = 0; i < flashcards.Count; i += batchSize)
			{
				// Lấy ra batch từ vị trí i và có tối đa batchSize phần tử
				var batch = flashcards.Skip(i).Take(batchSize);
				if (queryObject.QuestionType == QuestionType.Multiple || queryObject.QuestionType == QuestionType.Both)
				{
					foreach (var flashcard in batch)
						orderedQuestions.Add(CreateMultipleChoiceQuestion(flashcards, flashcard, random));
				}

				if (queryObject.QuestionType == QuestionType.Essay || queryObject.QuestionType == QuestionType.Both)
				{
					foreach (var flashcard in batch)
						orderedQuestions.Add(CreateEssayQuestion(flashcard, charBank));
				}
			}

			return new LearningQuestionDTO
			{
				AllQuestions = orderedQuestions,
			};
		}

		private EssayQuestionDTO CreateEssayQuestion(Flashcard flashcard, List<char> charBank)
		{
			return new EssayQuestionDTO
			{
				Question = flashcard.Definition!,
				QuestionType = QuestionType.Essay,
				CorrectAnswer = flashcard.Term!,
				CharacterBank = charBank,
			};
		}

		private MultipleChoiceQuestionDTO CreateMultipleChoiceQuestion(List<Flashcard> flashcards, Flashcard flashcard, Random random)
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
				.Append(flashcard.Term)
				.OrderBy(_ => random.Next())
				.ToList();

			// Tạo câu hỏi trắc nghiệm và thêm vào multipleChoiceQuestions
			return new MultipleChoiceQuestionDTO
			{
				Question = flashcard.Definition!,
				QuestionType = QuestionType.Multiple,
				Options = answers!,
				CorrectAnswer = flashcard.Term!
			};
		}

		private List<char> CreateCharacterBank(List<Flashcard> flashcards, Random random)
		{
			return flashcards
				.SelectMany(fc => fc.Term ?? string.Empty)
				.Where(c => c != '\'' && c != '(' && c != ')') // Không lấy ký tự rỗng, '(' và ')'
				.Distinct()
				.OrderBy(_ => random.Next())
				.ToList();
		}
	}
}
