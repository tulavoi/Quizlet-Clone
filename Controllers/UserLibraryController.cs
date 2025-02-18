using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCards.Filters;

namespace SmartCards.Controllers
{
    [Authorize]
    [Route("user/{username}")]
    [SetUserLibraryData]
    public class UserLibraryController : BaseController
    {
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
            return View();
        }

        [Route("folders")]
        public async Task<IActionResult> Folders()
        {
            ViewData["ActiveTab"] = "Folders";
            return View();
        }
    }
}
