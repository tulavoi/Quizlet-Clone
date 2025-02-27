using api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCards.DTOs.Course;
using SmartCards.Interfaces;
using SmartCards.Mappers;
using SmartCards.Models;
using System.Diagnostics;

namespace SmartCards.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserCourseProgressRepository _courseProgressRepo;
        private readonly string _activePage = "Home";

        public HomeController(ILogger<HomeController> logger, IUserCourseProgressRepository courseProgressRepo)
        {
            _logger = logger;
            _courseProgressRepo = courseProgressRepo;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["ActivePage"] = this._activePage;

            var courses = await _courseProgressRepo.GetAllByUserAsync(this.UserId, new CourseQueryObject
            {
                SortBy = "LastUpdated",
                IsDescending = true,
                Quantity = 4
            });

            var recentCoursesDTO = courses?.Select(x => x.ToRecentCourseDTO()).ToList() 
                ?? new List<RecentCourseDTO>();

            return View(recentCoursesDTO);
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
