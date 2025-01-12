using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCards.DTOs.Flashcard;
using SmartCards.Interfaces;

namespace SmartCards.Controllers
{
    [Authorize]
    [Route("fc-progress")]
    public class UserFlashcardProgressController : BaseController
    {
        private readonly IUserFlashcardProgressRepository _progressRepo;
        public UserFlashcardProgressController(IUserFlashcardProgressRepository progressRepo)
        {
            _progressRepo = progressRepo;
        }

        [HttpPost("update-progress")]
        public async Task<IActionResult> UpdateProgress([FromBody] FlashcardProgressUpdateDTO progressDTO)
        {
            if (progressDTO.FlashcardId <= 0) return BadRequest("Invalid flashcard ID.");
            await _progressRepo.SaveProgressAsync(this.UserId, progressDTO);
            return Ok();
        }
    }
}
