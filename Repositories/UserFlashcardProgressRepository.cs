﻿using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using QuizletClone.Areas.Identity.Data;
using QuizletClone.DTOs.Flashcard;
using QuizletClone.Interfaces;
using QuizletClone.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace QuizletClone.Repositories
{
    public class UserFlashcardProgressRepository : IUserFlashcardProgressRepository
    {
        private readonly AppDbContext _context;
        public UserFlashcardProgressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserFlashcardProgress>> GetByCourseIdAsync(string userId, int courseId)
        {
            return await _context.UserFlashcardProgresses
                .Where(x => x.UserId == userId && x.Flashcard!.CourseId == courseId)
                .ToListAsync() ?? new List<UserFlashcardProgress>();
        }

		public async Task<UserFlashcardProgress?> GetByFlashcardIdAsync(string userId, int flashcardId)
		{
			return await _context.UserFlashcardProgresses
				.Where(x => x.UserId == userId && x.Flashcard!.Id == flashcardId)
				.FirstOrDefaultAsync();
		}

		// Lưu lại flashcard đã học
		public async Task SaveLearnedCardAsync(string userId, int flashcardId)
        {
            var progress = await GetProgressAsync(userId, flashcardId);

            if (progress == null)
            {
                progress = new UserFlashcardProgress
                {
                    FlashcardId = flashcardId,
                    UserId = userId,
                    IsLearned = true,
                    IsStarred = false,
                    LastReviewedAt = DateTime.Now
                };
                _context.UserFlashcardProgresses.Add(progress);
            }
            else progress.IsLearned = true;

            await _context.SaveChangesAsync();
        }

        // Lưu lại flashcard cuối cùng đã xem
        public async Task SaveLastReviewdCardAsync(string userId, int flashcardId)
        {
            var progress = await GetProgressAsync(userId, flashcardId);

            if (progress == null)
            {
                progress = new UserFlashcardProgress
                {
                    FlashcardId = flashcardId,
                    UserId = userId,
                    LastReviewedAt = DateTime.Now.AddMilliseconds(1) // Có thể bị trùng thời gian khi SaveLearnedCardAsync nên + thêm 1 millisecond 
                };
                _context.UserFlashcardProgresses.Add(progress);
            }
            else progress.LastReviewedAt = DateTime.Now.AddMilliseconds(1);

            await _context.SaveChangesAsync();
        }

        // Gắn sao cho flashcard
        public async Task StarredFlashcardAsync(string userId, StarredFlashcardRequestDTO request)
        {
            var progress = await GetProgressAsync(userId, request.FlashcardId);

            if (progress == null)
            {
                progress = new UserFlashcardProgress
                {
                    FlashcardId = request.FlashcardId,
                    UserId = userId,
                    IsLearned = false,
                    IsStarred = request.IsStarred,
                    LastReviewedAt = null
                };
                _context.UserFlashcardProgresses.Add(progress);
            }
            else progress.IsStarred = request.IsStarred;
            await _context.SaveChangesAsync();
        }

        private async Task<UserFlashcardProgress?> GetProgressAsync(string userId, int flashcardId)
        {
            return await _context.UserFlashcardProgresses
                .FirstOrDefaultAsync(x => x.UserId == userId && x.FlashcardId == flashcardId);
        }
    }
}
