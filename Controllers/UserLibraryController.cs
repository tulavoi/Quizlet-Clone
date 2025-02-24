using api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SmartCards.DTOs.Course;
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
        private readonly IUserRepository _userRepo;

        public UserLibraryController(ICourseRepository courseRepo, IUserRepository userRepo)
        {
            _courseRepo = courseRepo;
            _userRepo = userRepo;
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

            var courses = await _courseRepo.GetAllByUserAsync(userId, new CourseQueryObject
            {
                SortBy = "LastUpdated",
                IsDescending = true,
                GetAll = true
            });

            var courseInUserLibraryDTOs = courses?.Select(x => x.ToCourseInUserLibraryDTO()).ToList()
                ?? new List<UserLibraryCoursesDTO>();

            return View(courseInUserLibraryDTOs);
        }

        [Route("folders")]
        public async Task<IActionResult> Folders()
        {
            ViewData["ActiveTab"] = "Folders";
            return View();
        }
    }
}
