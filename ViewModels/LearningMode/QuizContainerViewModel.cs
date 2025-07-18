﻿using QuizletClone.DTOs.LearningMode;
using QuizletClone.Helpers;

namespace QuizletClone.ViewModels.LearningMode
{
	public class QuizContainerViewModel
	{
		public int CourseId { get; set; }
		public List<QuestionDTO> AllQuestions { get; set; } = new();
		public int CorrectAnswerCount { get; set; }
		public int CurrentQuestionIndex { get; set; }
		public string CorrectAnswersPerStep { get; set; } = string.Empty;
	}
}
