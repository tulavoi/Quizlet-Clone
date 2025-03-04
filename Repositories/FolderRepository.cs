using Microsoft.EntityFrameworkCore;
using SmartCards.Areas.Identity.Data;
using SmartCards.Helpers;
using SmartCards.Interfaces;
using SmartCards.Models;

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

        public async Task<Folder?> GetByIdAsync(int id)
        {
            var folder = await _context.Folders
                .Include(c => c.CourseFolders)
                    .ThenInclude(cf => cf.Course)
                .FirstOrDefaultAsync(x => x.Id == id);
            return folder;
        }
    }
}
