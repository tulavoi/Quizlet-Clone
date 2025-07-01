using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using QuizletClone.DTOs.LearningMode;
using QuizletClone.DTOs.UserCourseProgress;
using QuizletClone.Helpers;
using QuizletClone.Interfaces;
using QuizletClone.Mappers;
using QuizletClone.Models;

namespace QuizletClone.Controllers
{
    [Authorize]
    [Route("learning")]
    public class LearningModeController : BaseController
    {
		private readonly ICourseRepository _courseRepo;
		private readonly IQuestionService _quizService;
        private readonly IUserLearningProgressRepository _learningProgressRepo;

		public LearningModeController(ICourseRepository courseRepo, IQuestionService quizService, IUserLearningProgressRepository learningProgressRepo)
        {
            _courseRepo = courseRepo;
            _quizService = quizService;
            _learningProgressRepo = learningProgressRepo;
		}

        [HttpGet("{slug}")]
        public async Task<IActionResult> Index(string slug, [FromQuery] LearningModeQueryObject queryObject)
        {
            int courseId = SlugHelper.GetIdBySlug(slug);

            var course = await _courseRepo.GetByIdAsync(courseId);
            if (course == null) return NotFound();
            
            var progress = await _learningProgressRepo.GetProgressAsync(this.UserId, course.Id);

            if (progress == null)
            {
                await _learningProgressRepo.CreateAsync(new UserLearningProgress
                {
                    UserId = this.UserId,
                    CourseId = course.Id,
                });
            }
            else
            {
                await _learningProgressRepo.UpdateAsync(progress);
				queryObject.QuestionType = progress.QuestionType; // Nếu như người dùng đã có tiến độ học, thì sử dụng loại câu hỏi đã lưu
			}

			// Tạo questions
			var questionDTO = await _quizService.GenerateQuestionDTOsAsync(this.UserId, course.Id, queryObject);
            if (questionDTO == null) return NotFound();
            
			return View(course.ToLearningModeDTO(questionDTO, progress));
        }

		[HttpPost("update-progress")]
		public async Task<IActionResult> UpdateProgress([FromBody] UpdateLearningProgressRequestDTO updateRequestDTO)
		{
            updateRequestDTO.UserId = this.UserId;
			if (updateRequestDTO.CourseId <= 0) return BadRequest("Invalid course ID.");
            var progress = updateRequestDTO.ToLearningProgressFromUpdateDTO();
			await _learningProgressRepo.UpdateAsync(progress);
            return Ok();
		}
	}
}
