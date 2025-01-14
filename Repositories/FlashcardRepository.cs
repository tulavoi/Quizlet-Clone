﻿using Microsoft.EntityFrameworkCore;
using SmartCards.Areas.Identity.Data;
using SmartCards.DTOs.Flashcard;
using SmartCards.Helpers;
using SmartCards.Interfaces;
using SmartCards.Models;
using System.Net.Quic;
using System.Net.WebSockets;

namespace SmartCards.Repositories
{
    public class FlashcardRepository : IFlashcardRepository
    {
        private readonly AppDbContext _context;
        public FlashcardRepository(AppDbContext context)
        {
            _context = context;
        }

        // Lấy ra flashcard đang hiển thị ở lần truy cập trước
        public async Task<Flashcard> GetCurrentDisplayedAsync(string userId, int courseId)
        {
            return await _context.UserFlashcardProgresses
                .Where(x => x.UserId == userId && x.Flashcard.CourseId == courseId)
                .OrderByDescending(x => x.LastReviewedAt)
                .Select(x => x.Flashcard)
                .FirstOrDefaultAsync() ?? new Flashcard();
        }

        public async Task<List<Flashcard?>> GetAllInCourseAsync(string userId, int courseId, FlashcardQueryObject query)
        {
            // Lấy tất cả flashcard trong khóa học
            var allFlashcardsInCourse = _context.Flashcards
                .Where(x => x.CourseId == courseId);

            // Lấy thông tin UserFlashcardProgresses cho người dùng trong khóa học
            var userProgresses = _context.UserFlashcardProgresses
                .Where(up => up.UserId == userId && up.Flashcard.CourseId == courseId);

            // Kết hợp 2 nguồn dữ liệu
            var result = from flashcard in allFlashcardsInCourse
                         join progress in userProgresses
                         on flashcard.Id equals progress.FlashcardId into progressGroup
                         from progress in progressGroup.DefaultIfEmpty() // Left join
                         where (query.IsLearned && progress != null && progress.IsLearned) // Lấy flashcards đã học
                        || (!query.IsLearned && (progress == null || !progress.IsLearned)) // Lấy flashcards chưa học
                         select flashcard;

            return await result.ToListAsync();
        }
    }
}
