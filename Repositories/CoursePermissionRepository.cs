using api.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using QuizletClone.Areas.Identity.Data;
using QuizletClone.Interfaces;
using QuizletClone.Models;

namespace QuizletClone.Repositories
{
    public class CoursePermissionRepository : ICoursePermissionRepository
    {
        private readonly AppDbContext _context;

        public CoursePermissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CoursePermission coursePermission)
        {
            if (coursePermission == null) return;
            await _context.CoursePermissions.AddAsync(coursePermission);
            await _context.SaveChangesAsync();
        }
    }
}
