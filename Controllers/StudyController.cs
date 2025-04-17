using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using QuizletClone.Helpers;
using QuizletClone.Interfaces;
using QuizletClone.Mappers;

namespace QuizletClone.Controllers
{
    [Authorize]
    [Route("study")]
    public class StudyController : BaseController
    {
		private readonly ICourseRepository _courseRepo;
        public StudyController(ICourseRepository courseRepo)
        {
            _courseRepo = courseRepo;
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> Index(string slug)
        {
            int courseId = SlugHelper.GetIdBySlug(slug);

            var course = await _courseRepo.GetByIdAsync(courseId);
            if (course == null) return NotFound();

            return View(course.ToStudyModeDTO());
        }
    }
}
