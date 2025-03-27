using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizletClone.DTOs.CourseFolder;
using QuizletClone.Interfaces;

namespace QuizletClone.Controllers
{
    [Authorize]
    [Route("course-folder")]
    public class CourseFolderController : BaseController
    {
        private readonly ICourseFolderRepository _courseFolderRepo;

        public CourseFolderController(ICourseFolderRepository courseFolderRepo)
        {
            _courseFolderRepo = courseFolderRepo;
        }

        [HttpPost("toggle-course-folder")]
        public async Task<IActionResult> ToggleCourseFolder([FromBody] ToggleCourseFolderRequestDTO requestDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _courseFolderRepo.ToggleCourseFolder(requestDTO);
            return Ok();
        }
    }
}
