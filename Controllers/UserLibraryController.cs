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

        private void SetViewData(string viewData, string content)
        {
            ViewData[viewData] = content;
        }

        // Route mặc định khi truy cập "user/{username}"
        public async Task<IActionResult> Index(string username)
        {
            return RedirectToAction(nameof(RecentlyCourses), new {username});
        }

        [Route("courses/created")]
        public async Task<IActionResult> CreatedCourses() 
        {
            this.SetViewData("ActiveTab", "Courses");
            this.SetViewData("FilterBy", "Đã tạo");

            var username = RouteData.Values["username"]?.ToString();
            if (string.IsNullOrEmpty(username)) return NotFound();

            var userId = await _userRepo.GetUserIdAsync(username);
            if (string.IsNullOrEmpty(userId)) return NotFound();

            var courses = await _courseRepo.GetAllByUserAsync(userId, new CourseQueryObject
            {
                SortBy = "CreatedAt",
                IsDescending = true,
                GetAll = true,
            });

            var courseDTOs = courses?.Select(x => x.ToCourseInUserLibraryDTO()).ToList()
                ?? new List<UserLibraryCoursesDTO>();

            var groupedCourseProgresses = courseDTOs
                .GroupBy(courseProgress => DatetimeExtensions.GetTimeCategory(
                    courseProgress.CreatedAt, DateTime.Now)
                )
                .ToDictionary(gr => gr.Key, gr => gr.ToList());

            return View("Courses", groupedCourseProgresses);
        }

        [Route("courses/recently")]
        public async Task<IActionResult> RecentlyCourses()
        {
            this.SetViewData("ActiveTab", "Courses");
            this.SetViewData("FilterBy", "Gần đây");

            var username = RouteData.Values["username"]?.ToString();
            if (string.IsNullOrEmpty(username)) return NotFound();

            var userId = await _userRepo.GetUserIdAsync(username);
            if (string.IsNullOrEmpty(userId)) return NotFound();

            var courses = await _courseProgressRepo.GetAllByUserAsync(userId, new CourseQueryObject
            {
                SortBy = "LastUpdated",
                IsDescending = true,
                GetAll = true,
            });

            var courseDTOs = courses?.Select(x => x.ToCourseInUserLibraryDTO()).ToList()
                ?? new List<UserLibraryCoursesDTO>();

            var groupedCourses = courseDTOs
                .GroupBy(course => DatetimeExtensions.GetTimeCategory(
                    course.LastUpdated, DateTime.Now)
                )
                .ToDictionary(gr => gr.Key, gr => gr.ToList());

            return View("Courses", groupedCourses);
        }

        //[Route("courses")]
        //public async Task<IActionResult> Courses(string filterBy)
        //{
        //    ViewData["ActiveTab"] = "Courses";
        //    ViewData["Filter"] = filterBy;

        //    var username = RouteData.Values["username"]?.ToString();
        //    if (string.IsNullOrEmpty(username)) return NotFound();

        //    var userId = await _userRepo.GetUserIdAsync(username);
        //    if (string.IsNullOrEmpty(userId)) return NotFound();

        //    var courses = await _courseProgressRepo.GetAllByUserAsync(userId, new CourseQueryObject
        //    {
        //        SortBy = "LastUpdated",
        //        IsDescending = true,
        //        GetAll = true,
        //        FilterBy = filterBy
        //    });

        //    var courseDTOs = courses?.Select(x => x.ToCourseInUserLibraryDTO()).ToList()
        //        ?? new List<UserLibraryCoursesDTO>();

        //    var groupedCourses = courseDTOs
        //        .GroupBy(course => DatetimeExtensions.GetTimeCategory(
        //            course.LastUpdated, DateTime.Now)
        //        )
        //        .ToDictionary(gr => gr.Key, gr => gr.ToList());

        //    return View(groupedCourses);
        //}

        [Route("folders")]
        public async Task<IActionResult> Folders()
        {
            this.SetViewData("ActiveTab", "Folders");
            return View();
        }
    }
}
