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
        [Route("courses")]
        public IActionResult Courses()
        {
            return View();
        }

        [Route("folders")]
        public IActionResult Folders()
        {
            return View();
        }
    }
}
