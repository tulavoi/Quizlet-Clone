using Newtonsoft.Json;

namespace QuizletClone.Helpers
{
	[JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
	public enum QuestionType
	{
		Both = 0,
		Multiple = 1,
		Essay = 2 
	}

	public class LearningModeQueryObject
	{
		public QuestionType QuestionType { get; set; } = QuestionType.Both;
		public bool IsStarred { get; set; } = false;
	}
}
