using api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizletClone.DTOs.Course;
using QuizletClone.Interfaces;
using QuizletClone.Mappers;
using QuizletClone.Models;
using QuizletClone.ViewModels.Home;
using System.Diagnostics;

namespace QuizletClone.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserCourseProgressRepository _courseProgressRepo;
        private readonly ICourseRepository _courseRepo;
        private readonly string _activePage = "Home";

        public HomeController(ILogger<HomeController> logger, IUserCourseProgressRepository courseProgressRepo, ICourseRepository courseRepo)
        {
            _logger = logger;
            _courseProgressRepo = courseProgressRepo;
            _courseRepo = courseRepo;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["ActivePage"] = this._activePage;

			List<RecentCourseDTO> recentCoursesDTO = new();
			List<PopularCourseDTO> popularCoursesDTO = new();

			var recentCourses = await _courseProgressRepo.GetAllByUserAsync(this.UserId, new CourseQueryObject
            {
                SortBy = "LastUpdated",
                IsDescending = true,
                Quantity = 6
            });

            var popularCourses = await _courseRepo.GetPopularCoursesAsync(new CourseQueryObject
            {
                IsDescending = true,
                Quantity = 3
            });

            if (recentCourses != null)
				recentCoursesDTO = recentCourses?.Select(x => x.ToRecentCourseDTO()).ToList() ?? new();

            if (popularCourses != null)
				popularCoursesDTO = popularCourses?.Select(x => x.ToPopularCourseDTO()).ToList() ?? new();

            var homeViewModel = new HomeViewModel
            {
                RecentCoursesDTO = recentCoursesDTO,
                PopularCoursesDTO = popularCoursesDTO
            };

            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
