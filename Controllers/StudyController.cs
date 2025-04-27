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
    [Route("study")]
    public class StudyController : BaseController
    {
		private readonly ICourseRepository _courseRepo;
		private readonly IQuizService _quizService;

        public StudyController(ICourseRepository courseRepo, IQuizService quizService)
        {
            _courseRepo = courseRepo;
            _quizService = quizService;
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> Index(string slug)
        {
            int courseId = SlugHelper.GetIdBySlug(slug);

            var course = await _courseRepo.GetByIdAsync(courseId);
            if (course == null) return NotFound();

            // Tạo Quiz
            var questions = await _quizService.GenerateQuestionDTOsAsync(this.UserId, course.Id);
            if (questions == null) return NotFound();

			return View(course.ToStudyModeDTO());
        }
    }
}
