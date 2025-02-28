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
using SmartCards.Models;

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

        private void SetViewData(string viewData, string content)
        {
            ViewData[viewData] = content;
        }

        // Route mặc định khi truy cập "user/{username}"
        public async Task<IActionResult> Index(string username)
        {
            return RedirectToAction(nameof(Courses), new {username, filter = "recently"});
        }

        [Route("courses/{filter}")]
        public async Task<IActionResult> Courses(string filter)
        {
            this.SetViewData("ActiveTab", "Courses");
            this.SetViewData("FilterBy", filter);

            var username = RouteData.Values["username"]?.ToString();
            if (string.IsNullOrEmpty(username)) return NotFound();

            var userId = await _userRepo.GetUserIdAsync(username);
            if (string.IsNullOrEmpty(userId)) return NotFound();

            IEnumerable<UserLibraryCoursesDTO> courseDTOs = new List<UserLibraryCoursesDTO>();

            if (filter == "created")
            {
                var courses = await _courseRepo.GetAllByUserAsync(userId, new CourseQueryObject
                {
                    SortBy = "CreatedAt",
                    IsDescending = true,
                    GetAll = true
                });

                courseDTOs = courses?.Select(x => x.ToCourseInUserLibraryDTO()).ToList()
                                ?? new List<UserLibraryCoursesDTO>();
            }
            else if (filter == "recently")
            {
                var courseProgress = await _courseProgressRepo.GetAllByUserAsync(userId, new CourseQueryObject
                {
                    SortBy = "LastUpdated",
                    IsDescending = true,
                    GetAll = true
                });

                courseDTOs = courseProgress?.Select(x => x.ToCourseInUserLibraryDTO()).ToList()
                                ?? new List<UserLibraryCoursesDTO>();
            }

            var groupedCourses = courseDTOs
                .GroupBy(course => DatetimeExtensions.GetTimeCategory(
                    filter == "created" ? course.CreatedAt : course.LastUpdated, 
                    DateTime.Now)
                )
                .ToDictionary(gr => gr.Key, gr => gr.ToList());

            return View("Courses", groupedCourses);
        }

        [Route("folders")]
        public async Task<IActionResult> Folders()
        {
            this.SetViewData("ActiveTab", "Folders");
            return View();
        }
    }
}
