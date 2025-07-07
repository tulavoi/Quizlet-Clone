using api.Helpers;
using Microsoft.EntityFrameworkCore;
using QuizletClone.Areas.Identity.Data;
using QuizletClone.DTOs.Course;
using QuizletClone.Helpers;
using QuizletClone.Interfaces;
using QuizletClone.Models;

namespace QuizletClone.Repositories
{
	public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        private readonly ICoursePermissionRepository _coursePerRepo;

        public CourseRepository(AppDbContext context, ICoursePermissionRepository coursePerRepo)
        {
            _context = context;
            _coursePerRepo = coursePerRepo;
        }

        public async Task CreateAsync(Course course, int viewPerId, int editPerId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Courses.AddAsync(course);
                await _context.SaveChangesAsync();

                // Tạo slug sau khi đã có ID
                course.Slug = SlugHelper.GenerateSlug(course.Title, course.Id, course.CreatedAt);
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<Course?> GetByIdAsync(int id, CourseQueryObject? query)
        {
			return await _context.Courses
                .Include(x => x.User)
                .Include(x => x.Flashcards)
                    .ThenInclude(f => f.Term_Lang)
                .Include(x => x.Flashcards)
                    .ThenInclude(f => f.Definition_Lang)
                .Include(x => x.CoursePermission)
                    .ThenInclude(cp => cp.ViewPermission)
				.Include(x => x.CoursePermission)
					.ThenInclude(cp => cp.EditPermission)
				.FirstOrDefaultAsync(x => x.Id == id);
        }

        public string GetErrorMessage(CreateCourseRequestDTO courseDTO)
        {
            List<string> messages = new List<string>();
            if (string.IsNullOrEmpty(courseDTO.Title)) // Nếu không có tiêu đề học phần
                messages.Add("nhập tiêu đề ");

            if (courseDTO.Flashcards.Count < 3) // Nếu ít hơn 3 flashcard
                messages.Add("nhiều hơn hai thẻ ");

            if (courseDTO.Flashcards[0].TermLanguageId == 0 || courseDTO.Flashcards[0].DefiLanguageId == 0) // Nếu chưa chọn term or definition language
                messages.Add("một ngôn ngữ cho thuật ngữ và một ngôn ngữ cho định nghĩa ");

            // Nếu như messages không có phần tử nào thì combinedMessage là chuỗi rỗng
            string combinedMessage = messages.Count != 0 ? $"bạn cần {string.Join(", ", messages)} để tạo 1 học phần." : "";

            return combinedMessage;
        }

        public async Task<List<Course>?> GetAllByUserAsync(string userId, CourseQueryObject query)
        {
            var courses = _context.Courses
                .Where(c => c.UserId == userId)
                .Include(fc => fc.Flashcards)
                .Include(cp => cp.CoursePermission)
                .AsQueryable();

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                if (query.SortBy.Equals("CreatedAt", StringComparison.OrdinalIgnoreCase))
                {
                    courses = query.IsDescending ? courses.OrderByDescending(ucp => ucp.CreatedAt)
                        : courses.OrderBy(ucp => ucp.CreatedAt);
                }
            }

            // Giới hạn số lượng course nếu không lấy tất cả
            if (!query.GetAll && query.Quantity > 0)
                courses = courses.Take(query.Quantity);

            return await courses.ToListAsync();
        }

        public async Task<List<Course>?> GetPopularCoursesAsync(CourseQueryObject query)
        {
            var courses = _context.Courses
				.Include(fc => fc.Flashcards)
                .Include(u => u.User)
				.AsQueryable();

			if (!string.IsNullOrEmpty(query.FilterBy))
			{
                courses = courses.Where(c => c.Title.Contains(query.FilterBy) 
                    || c.Description.Contains(query.FilterBy));
			}

            courses = query.IsDescending ? courses.OrderByDescending(c => c.AccessCount)
                : courses.OrderBy(c => c.AccessCount);

			if (!query.GetAll)
				courses = courses.Take(query.Quantity);

            return await courses.ToListAsync();
		}

        public async Task<Course?> DeleteAsync(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return null;
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return course;
        }

		public async Task IncreaseAccessCount(string userId, int courseId)
		{
			var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId);
			if (course == null) return;

			// Nếu userId truy cập vào course này lần đầu tiên, tăng access count
			var userProgress = await _context.UserCourseProgresses
				.FirstOrDefaultAsync(ucp => ucp.UserId == userId && ucp.CourseId == courseId);
            if (userProgress == null)
            {
                course.AccessCount++;
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
			}
		}
	}
}
