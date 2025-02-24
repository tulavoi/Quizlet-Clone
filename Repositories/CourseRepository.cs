using api.Helpers;
using Microsoft.EntityFrameworkCore;
using SmartCards.Areas.Identity.Data;
using SmartCards.DTOs.Course;
using SmartCards.Interfaces;
using SmartCards.Models;

namespace SmartCards.Repositories
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

        public async Task CreateAsync(Course course, int viewPerId, int ediPerId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Courses.AddAsync(course);
                await _context.SaveChangesAsync();

                // Tạo slug sau khi đã có ID
                course.Slug = this.GenerateSlug(course.Title, course.Id, course.CreatedAt);
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();

                var coursePermission = new CoursePermission
                {
                    CourseId = course.Id,
                    ViewPermissionId = viewPerId,
                    EditPermissionId = ediPerId,
                };

                await _coursePerRepo.CreateAsync(coursePermission); // Tạo course permission

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private string GenerateSlug(string title, int id, DateTime createdAt)
        {
            // Bỏ dấu tiếng Việt
            var noDiacritics = RemoveDiacritics(title);

            // Chuyển thành slug
            var slug = string.Join("-", noDiacritics.ToLower()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            // Xóa các dấu '-' dư thừa
            slug = System.Text.RegularExpressions.Regex.Replace(slug, "-{2,}", "-").Trim('-');

            var createdAtString = createdAt.ToString("yyyyMMddhhmmssfff");

            return $"{slug}-{createdAtString}-{id}";
        }

        private string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(System.Text.NormalizationForm.FormD);
            var stringBuilder = new System.Text.StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC);
        }

        // Lấy các học phần của user
        public async Task<List<Course>?> GetAllByUserAsync(string userId, CourseQueryObject query)
        {
            var courseProgresses = _context.UserCourseProgresses
                        .Where(ucp => ucp.UserId == userId)
                        .Include(ucp => ucp.Course)
                            .ThenInclude(c => c.User)
                        .Include(ucp => ucp.Course)
                            .ThenInclude(c => c.Flashcards)
                                .ThenInclude(fc => fc.Term_Lang)
                        .Include(ucp => ucp.Course)
                            .ThenInclude(c => c.Flashcards)
                                .ThenInclude(fc => fc.Definition_Lang)
                        //.Include(ucp => ucp.Course)
                        //    .ThenInclude(c => c.CoursePermission)
                        //        .ThenInclude(cp => cp.ViewPermission)
                        .AsQueryable();

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                courseProgresses = query.IsDescending ? courseProgresses.OrderByDescending(ucp => ucp.LastUpdated)
                    : courseProgresses.OrderBy(ucp => ucp.LastUpdated);
            }

            if (!query.GetAll && query.Quantity > 0)
                courseProgresses = courseProgresses.Take(query.Quantity);

            var result = await courseProgresses
                        .Select(ucp => ucp.Course!)
                        .Where(c => c != null)
                        .ToListAsync();

            return result.Any() ? result : null;
        }

        public async Task<Course?> GetByIdAsync(int id, CourseQueryObject? query)
        {
            var course = await _context.Courses
                .Include(x => x.User)
                .Include(x => x.Flashcards)
                    .ThenInclude(f => f.Term_Lang)
                .Include(x => x.Flashcards)
                    .ThenInclude(f => f.Definition_Lang)
                .FirstOrDefaultAsync(x => x.Id == id);

            return course;
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
    }
}
