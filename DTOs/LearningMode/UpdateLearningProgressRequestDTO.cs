using Newtonsoft.Json.Converters;
using QuizletClone.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace QuizletClone.DTOs.LearningMode
{
	public class UpdateLearningProgressRequestDTO
	{
		[Required]
		public int CourseId { get; set; }
		public int CorrectAnswerCount { get; set; }
		public int CurrentQuestionIndex { get; set; }
		public string CorrectAnswersPerStep { get; set; } = string.Empty;

		[Required]
		public string UserId { get; set; } = string.Empty;
		public DateTime LastAccessed { get; set; } = DateTime.Now;
		//[JsonConverter(typeof(StringEnumConverter))]
		public QuestionType QuestionType { get; set; } = QuestionType.Both;
	}
}
