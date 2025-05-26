using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using QuizletClone.Helpers;
using QuizletClone.Interfaces;
using QuizletClone.Mappers;
using System.Net.Quic;

namespace QuizletClone.Controllers
{
    [Authorize]
    [Route("learn")]
    public class LearningModeController : BaseController
    {
		private readonly ICourseRepository _courseRepo;
		private readonly IQuestionService _quizService;

        public LearningModeController(ICourseRepository courseRepo, IQuestionService quizService)
        {
            _courseRepo = courseRepo;
            _quizService = quizService;
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> Index(string slug, [FromQuery] LearningModeQueryObject queryObject)
        {
            int courseId = SlugHelper.GetIdBySlug(slug);

            var course = await _courseRepo.GetByIdAsync(courseId);
            if (course == null) return NotFound();

            // Tạo questions
            //queryObject.QuestionType = QuestionType.Essay; // Lấy các essay question để thử nghiệm
			var question = await _quizService.GenerateQuestionDTOsAsync(this.UserId, course.Id, queryObject);
            if (question == null) return NotFound();
            
			return View(course.ToLearningModeDTO(question));
        }
    }
}
