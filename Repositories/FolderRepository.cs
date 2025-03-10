using Microsoft.EntityFrameworkCore;
using SmartCards.Areas.Identity.Data;
using SmartCards.DTOs.Folder;
using SmartCards.Helpers;
using SmartCards.Interfaces;
using SmartCards.Models;
using System.Runtime.InteropServices;

namespace SmartCards.Repositories
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
