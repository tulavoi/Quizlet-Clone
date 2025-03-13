﻿using Microsoft.EntityFrameworkCore;
using QuizletClone.Areas.Identity.Data;
using QuizletClone.DTOs.Folder;
using QuizletClone.Helpers;
using QuizletClone.Interfaces;
using QuizletClone.Models;
using System.Runtime.InteropServices;

namespace QuizletClone.Repositories
{
	public class FolderRepository : IFolderRepository
    {
        private readonly AppDbContext _context;

        public FolderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Folder> CreateAsync(Folder folder)
        {
            await _context.Folders.AddAsync(folder);
            await _context.SaveChangesAsync();

            // Tạo slug sau khi đã có ID
            folder.Slug = SlugHelper.GenerateSlug(folder.Title, folder.Id, folder.CreatedAt);
            _context.Folders.Update(folder);
            await _context.SaveChangesAsync();

            return folder;
        }

		public async Task<Folder?> DeleteAsync(int id)
		{
            var existingFolder = await _context.Folders
                .Include(f => f.CourseFolders)
                .FirstOrDefaultAsync(f => f.Id == id);

			if (existingFolder == null) return null;

            _context.CourseFolders.RemoveRange(existingFolder.CourseFolders);
            _context.Folders.Remove(existingFolder);
            await _context.SaveChangesAsync();
            return existingFolder;
		}

		public async Task<List<Folder>?> GetAllAsync(string userId, FolderQueryObject query)
		{
            var folders = _context.Folders
				.Include(c => c.CourseFolders)
					.ThenInclude(cf => cf.Course)
				.Where(f => f.UserId == userId)
                .AsQueryable();

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                if (query.SortBy.Equals("CreatedAt", StringComparison.OrdinalIgnoreCase))
                {
                    folders = query.IsDescending ? folders.OrderByDescending(ucp => ucp.CreatedAt)
                        : folders.OrderBy(ucp => ucp.CreatedAt);
                }
            }

            return await folders.ToListAsync();
        }

		public async Task<Folder?> GetByIdAsync(int id)
        {
            var folder = await _context.Folders
                .Include(cf => cf.CourseFolders)
                    .ThenInclude(c => c.Course)
                        .ThenInclude(fc => fc!.Flashcards)
                .FirstOrDefaultAsync(x => x.Id == id);
            return folder;
        }

		public async Task UpdateAsync(int id, UpdateFolderRequestDTO folderDTO)
		{
            var existingFolder = await _context.Folders.FirstOrDefaultAsync(f => f.Id == id);
            if (existingFolder == null) return;

            existingFolder.Title = folderDTO.Title;
            existingFolder.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
		}
	}
}
