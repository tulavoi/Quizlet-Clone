using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCards.DTOs.Course;
using SmartCards.DTOs.Flashcard;
using SmartCards.Interfaces;

namespace SmartCards.Controllers
{
    [Authorize]
    [Route("flashcard")]
    public class FlashcardController : BaseController
    {
		private readonly IFlashcardRepository _flashcardRepo;
        public FlashcardController(IFlashcardRepository flashcardRepo)
        {
            _flashcardRepo = flashcardRepo;
        }

        [HttpPost("update")] 
        public async Task<IActionResult> Update([FromBody] UpdateFlashcardRequestDTO flashcardDTO) {
            if (flashcardDTO.Id <= 0) return NotFound();
            await _flashcardRepo.UpdateAsync(flashcardDTO);
            return Ok();
        }
    }
}
