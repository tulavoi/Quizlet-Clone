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
		public async Task<LearningQuestionDTO> GenerateQuestionDTOsAsync(string userId, int courseId)
		{
			// Lấy các flashcard trong course
			var flashcards = await _flashcardRepo.GetAllCardsInCourseAsync(userId, courseId, new FlashcardQueryObject());

			if (flashcards == null) return new LearningQuestionDTO();

			var random = new Random();

			var multipleChoiceQuestions = new List<MultipleChoiceQuestionDTO>();
			var essayQuestions = new List<EssayQuestionDTO>();

			var charBank = this.CreateCharacterBank(flashcards, random);

			foreach (var flashcard in flashcards)
			{
				multipleChoiceQuestions.Add(this.CreateMultipleChoiceQuestion(flashcards, flashcard, random));
				essayQuestions.Add(this.CreateEssayQuestion(flashcard, charBank));
			}

			return new LearningQuestionDTO
			{
				MultipleChoiceQuestions = multipleChoiceQuestions,
				EssayQuestions = essayQuestions
			};
		}

		private EssayQuestionDTO CreateEssayQuestion(Flashcard flashcard, List<char> charBank)
		{
			return new EssayQuestionDTO
			{
				Question = flashcard.Definition!,
				CorrectAnswer = flashcard.Term!,
				CharacterBank = charBank
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
				Answers = answers!,
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
