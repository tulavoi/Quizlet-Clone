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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourseRepository _courseRepo;

        public HomeController(ILogger<HomeController> logger, ICourseRepository courseRepo)
        {
            _logger = logger;
            _courseRepo = courseRepo;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _courseRepo.GetAllAsync(new CourseQueryObject
            {
                SortBy = "CreatedAt",
                IsDecsending = true,
                MaxItem = 4
            });
            //var coursesDTO = courses.Select(c => c.ToCourseDTO()).ToList();
            var recentCoursesDTO = courses.Select(x => x.ToRecentCourseDTO()).ToList();
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
