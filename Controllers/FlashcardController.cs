using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCards.DTOs.Flashcard;
using SmartCards.Interfaces;

namespace SmartCards.Controllers
{
    [Authorize]
    [Route("/flashcard")]
    public class FlashcardController : BaseController
    {
		private readonly IFlashcardRepository _flashcardRepo;
        public FlashcardController(IFlashcardRepository flashcardRepo)
        {
            _flashcardRepo = flashcardRepo;
        }

        [HttpPost("save-last-learned")]
        public async Task<IActionResult> SaveLastLearned([FromBody] FlashcardLastLearnedDTO flashcardDTO)
        {
            try
            {
                if (flashcardDTO.Id <= 0)
                {
                    return BadRequest("Invalid flashcard id");
                }

                await _flashcardRepo.SaveLastLearnedAsync(this.UserId, flashcardDTO.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log lỗi
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
