using QuizletClone.DTOs.LearningMode;
using QuizletClone.Helpers;
using QuizletClone.Interfaces;
using QuizletClone.Mappers;
using QuizletClone.Models;

namespace QuizletClone.Services
{
	public class QuestionService : IQuestionService
	{
		private readonly ICourseRepository _courseRepo;
		private readonly IFlashcardRepository _flashcardRepo;
		private readonly IUserLearningProgressRepository _learningProgress;
		private readonly IUserFlashcardProgressRepository _flashcardProgressRepo;

		public QuestionService(ICourseRepository courseRepo, IFlashcardRepository flashcardRepo, IUserLearningProgressRepository learningProgress, IUserFlashcardProgressRepository flashcardProgressRepo)
		{
			_courseRepo = courseRepo;
			_flashcardRepo = flashcardRepo;
			_learningProgress = learningProgress;
			_flashcardProgressRepo = flashcardProgressRepo;
		}

		// Update hàm: tạo ra thêm các câu hỏi tự luận
		public async Task<LearningQuestionDTO> GenerateQuestionDTOsAsync(string userId, int courseId, LearningModeQueryObject queryObject)
		{
			// Lấy các flashcard trong course
			var flashcards = await _flashcardRepo.GetAllCardsInCourseAsync(userId, courseId, new FlashcardQueryObject());

			if (flashcards == null) return new LearningQuestionDTO();

			var random = new Random();
			var allQuestions = new List<QuestionDTO>();
			var charBank = this.CreateCharacterBank(flashcards, random);
			int batchSize = 5;

			// Vòng lặp qua tất cả flashcards, bước nhảy là 5 (vì mỗi batch có tối đa 5 phần tử)
			for (int i = 0; i < flashcards.Count; i += batchSize)
			{
				// Lấy ra batch từ vị trí i và có tối đa batchSize phần tử
				var batch = flashcards.Skip(i).Take(batchSize).ToList();
				var questions = await GenerateQuestionsForBatchAsync(userId, batch, flashcards, random, charBank, queryObject.QuestionType);
				allQuestions.AddRange(questions);
			}

			return new LearningQuestionDTO { AllQuestions = allQuestions };
		}

		private async Task<List<QuestionDTO>> GenerateQuestionsForBatchAsync(string userId, List<Flashcard> batch, List<Flashcard> flashcards, Random random, List<char> charBank, QuestionType questionType)
		{
			var questions = new List<QuestionDTO>();
			
			// Tạo 5 Multiple Questions sau đó tới 5 Essay Questions
			if (questionType is QuestionType.Multiple or QuestionType.Both)
			{
				foreach (var flashcard in batch)
				{
					var progress = await GetUserFlashcardProgress(userId, flashcard.Id);
					questions.Add(CreateMultipleChoiceQuestion(flashcards, flashcard, random, progress));
				}
			}

			if (questionType is QuestionType.Essay or QuestionType.Both)
			{
				foreach (var flashcard in batch)
				{
					var progress = await GetUserFlashcardProgress(userId, flashcard.Id);
					questions.Add(CreateEssayQuestion(flashcard, charBank, progress));
				}
			}

			return questions;
		}

		private async Task<UserFlashcardProgress> GetUserFlashcardProgress(string userId, int flashcardId)
		{
			return await _flashcardProgressRepo.GetByFlashcardIdAsync(userId, flashcardId) ?? new();
		}

		private EssayQuestionDTO CreateEssayQuestion(Flashcard flashcard, List<char> charBank, UserFlashcardProgress userFlashcardProgress)
		{
			return new EssayQuestionDTO
			{
				Flashcard = flashcard.ToFlashcardDTO(userFlashcardProgress),
				Question = flashcard.Definition!,
				QuestionType = QuestionType.Essay,
				CorrectAnswer = flashcard.Term!,
				CharacterBank = charBank,
			};
		}

		private MultipleChoiceQuestionDTO CreateMultipleChoiceQuestion(List<Flashcard> flashcards, Flashcard flashcard, Random random, UserFlashcardProgress userFlashcardProgress)
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
				Flashcard = flashcard.ToFlashcardDTO(userFlashcardProgress),
				Question = flashcard.Definition!,
				QuestionType = QuestionType.Multiple,
				Options = answers!,
				CorrectOption = flashcard.Term!
			};
		}

		private List<char> CreateCharacterBank(List<Flashcard> flashcards, Random random)
		{
			return flashcards
				.SelectMany(fc => fc.Term!.ToLower() ?? string.Empty)
				.Where(c => c != ' ' && c != '(' && c != ')') // Không lấy ký tự rỗng, '(' và ')'
				.Distinct()
				.OrderBy(_ => random.Next())
				.ToList();
		}
	}
}
