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
        private readonly ICourseRepository _courseRepo;
        private readonly string _activePage = "Home";

        public HomeController(ILogger<HomeController> logger, ICourseRepository courseRepo)
        {
            _logger = logger;
            _courseRepo = courseRepo;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["ActivePage"] = this._activePage;

            var courses = await _courseRepo.GetAllByUserAsync(this.UserId, new CourseQueryObject
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
