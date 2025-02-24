using api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.IdentityModel.Tokens;
using SmartCards.DTOs.Course;
using SmartCards.Extensions;
using SmartCards.Filters;
using SmartCards.Interfaces;
using SmartCards.Mappers;

namespace SmartCards.Controllers
{
    [Authorize]
    [Route("user/{username}")]
    [SetUserLibraryData]
    public class UserLibraryController : BaseController
    {
        private readonly ICourseRepository _courseRepo;
        private readonly IUserCourseProgressRepository _courseProgressRepo;
        private readonly IUserRepository _userRepo;

        public UserLibraryController(ICourseRepository courseRepo, IUserRepository userRepo, IUserCourseProgressRepository courseProgressRepo)
        {
            _courseRepo = courseRepo;
            _userRepo = userRepo;
            _courseProgressRepo = courseProgressRepo;
        }

        // Route mặc định khi truy cập "user/{username}"
        //[Route("")]
        public async Task<IActionResult> Index(string username)
        {
            return RedirectToAction(nameof(Courses), new {username});
        }

        [Route("courses")]
        public async Task<IActionResult> Courses()
        {
            ViewData["ActiveTab"] = "Courses";

            var username = RouteData.Values["username"]?.ToString();
            if (string.IsNullOrEmpty(username)) return NotFound();

            var userId = await _userRepo.GetUserIdAsync(username);
            if (string.IsNullOrEmpty(userId)) return NotFound();

            var courses = await _courseProgressRepo.GetAllByUserAsync(userId, new CourseQueryObject
            {
                SortBy = "LastUpdated",
                IsDescending = true,
                GetAll = true
            });

            var courseDTOs = courses?.Select(x => x.ToCourseInUserLibraryDTO()).ToList()
                ?? new List<UserLibraryCoursesDTO>();

            var groupedCourses = courseDTOs
                .GroupBy(course => DatetimeExtensions.GetTimeCategory(course.LastUpdated, DateTime.Now))
                .ToDictionary(gr => gr.Key, gr => gr.ToList());

            return View(groupedCourses);
        }

        [Route("folders")]
        public async Task<IActionResult> Folders()
        {
            ViewData["ActiveTab"] = "Folders";
            return View();
        }
    }
}
