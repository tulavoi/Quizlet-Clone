﻿using Microsoft.EntityFrameworkCore;
using QuizletClone.Areas.Identity.Data;
using QuizletClone.DTOs.CourseFolder;
using QuizletClone.Interfaces;
using QuizletClone.Models;

namespace QuizletClone.Repositories
{
    public class CourseFolderRepository : ICourseFolderRepository
    {
        private readonly AppDbContext _context;

        public CourseFolderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task ToggleCourseFolder(ToggleCourseFolderRequestDTO requestDTO)
        {
            var existingRecord = await _context.CourseFolders
                .FirstOrDefaultAsync(cf => cf.FolderId == requestDTO.FolderId
                                          && cf.CourseId == requestDTO.CourseId);

            if (existingRecord != null) await this.Delete(existingRecord);
            else await this.Create(requestDTO);
        }

        private async Task Create(ToggleCourseFolderRequestDTO requestDTO)
        {
            var newRecord = new CourseFolder
            {
                FolderId = requestDTO.FolderId,
                CourseId = requestDTO.CourseId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            await _context.CourseFolders.AddAsync(newRecord);

            await this.UpdateFolderTimestamp(newRecord.FolderId);

			await _context.SaveChangesAsync();
        }

        private async Task Delete(CourseFolder existingRecord)
        {
            await this.UpdateFolderTimestamp(existingRecord.FolderId);

            _context.CourseFolders.Remove(existingRecord);
            await _context.SaveChangesAsync();
        }

        private async Task UpdateFolderTimestamp(int folderId)
        {
			var folder = await _context.Folders.FirstOrDefaultAsync(f => f.Id == folderId);
			if (folder != null)
            {
				folder.UpdatedAt = DateTime.Now; 
                await _context.SaveChangesAsync();
			}
		}
	}
}
