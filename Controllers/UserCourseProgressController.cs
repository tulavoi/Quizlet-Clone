using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCards.DTOs.UserCourseProgress;
using SmartCards.Interfaces;

namespace SmartCards.Controllers
{
    [Authorize]
    [Route("course-progress")]
    public class UserCourseProgressController : BaseController
    {
        private readonly IUserCourseProgressRepository _progressRepo;

        public UserCourseProgressController(IUserCourseProgressRepository progressRepo)
        {
            _progressRepo = progressRepo;
        }

        [HttpPost("update-progress")]
        public async Task<IActionResult> UpdateProgress([FromBody] ChangeShuffleRequestDTO request)
        {
            if (request.CourseId <= 0) return BadRequest("Invalid course ID.");
            await _progressRepo.UpdateProgressAsync(this.UserId, request.CourseId, request.IsShuffle);
            return Ok();
        }
    }
}
