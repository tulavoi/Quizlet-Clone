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
            var courses = await _courseRepo.GetAllAsync(this.UserId, new CourseQueryObject
            {
                SortBy = "CreatedAt",
                IsDecsending = true,
                MaxItem = 4
            });
            var recentCoursesDTO = courses.Select(x => x.ToRecentCourseDTO()).ToList();

            ViewData["ActivePage"] = this._activePage;

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
