﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizletClone.DTOs.Flashcard;
using QuizletClone.DTOs.UserFlashcardProgress;
using QuizletClone.Interfaces;

namespace QuizletClone.Controllers
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

        [HttpPost("save-learned-card")]
        public async Task<IActionResult> SaveLearnedCard([FromBody] UpdateFlashcardProgressRequestDTO progressDTO)
        {
            if (progressDTO.FlashcardId <= 0) return BadRequest("Invalid flashcard ID.");
            await _progressRepo.SaveLearnedCardAsync(this.UserId, progressDTO.FlashcardId);
            return Ok();
        }

        [HttpPost("save-last-reviewed-card")]
        public async Task<IActionResult> SaveLastReviewedCard([FromBody] UpdateFlashcardProgressRequestDTO progressDTO)
        {
            if (progressDTO.FlashcardId <= 0) return BadRequest("Invalid flashcard ID.");
            await _progressRepo.SaveLastReviewdCardAsync(this.UserId, progressDTO.FlashcardId);
            return Ok();
        }

        [HttpPost("starred-card")]
        public async Task<IActionResult> StarredCard([FromBody] StarredFlashcardRequestDTO request)
        {
            if (request.FlashcardId <= 0) return BadRequest("Invalid flashcard ID.");
            await _progressRepo.StarredFlashcardAsync(this.UserId, request);
            return Ok();
        }
    }
}
