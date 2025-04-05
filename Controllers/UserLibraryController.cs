using api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using QuizletClone.DTOs.Course;
using QuizletClone.DTOs.Folder;
using QuizletClone.Extensions;
using QuizletClone.Filters;
using QuizletClone.Helpers;
using QuizletClone.Interfaces;
using QuizletClone.Mappers;
using QuizletClone.Models;
using System.Text.Json;

namespace QuizletClone.Controllers
{
    [Authorize]
    [Route("user/{username}")]
    [SetUserLibraryData]
    public class UserLibraryController : BaseController
    {
        private readonly ICourseRepository _courseRepo;
        private readonly IFolderRepository _folderRepo;
		private readonly IUserCourseProgressRepository _courseProgressRepo;
        private readonly IUserRepository _userRepo;

        public UserLibraryController(ICourseRepository courseRepo, IUserRepository userRepo, 
            IUserCourseProgressRepository courseProgressRepo, IFolderRepository folderRepo)
        {
            _courseRepo = courseRepo;
            _folderRepo = folderRepo;
            _userRepo = userRepo;
            _courseProgressRepo = courseProgressRepo;
        }

        private void SetViewData(string viewData, string content)
        {
            ViewData[viewData] = content;
        }

        [Route("courses/{filter=recently}")]
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

                courseDTOs = courses?.Select(x => x.ToUserLibraryCoursesDTO()).ToList() ?? new();
            }
            else if (filter == "recently")
            {
                var courseProgress = await _courseProgressRepo.GetAllByUserAsync(userId, new CourseQueryObject
                {
                    SortBy = "LastUpdated",
                    IsDescending = true,
                    GetAll = true
                });

                courseDTOs = courseProgress?.Select(x => x.ToUserLibraryCoursesDTO()).ToList() ?? new();
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

            var username = RouteData.Values["username"]?.ToString();
            if (string.IsNullOrEmpty(username)) return NotFound();

            var userId = await _userRepo.GetUserIdAsync(username);
            if (string.IsNullOrEmpty(userId)) return NotFound();

            var folders = await _folderRepo.GetAllAsync(userId, new FolderQueryObject
            {
                SortBy = "CreatedAt",
                IsDescending = true,
            });

            var foldersDTO = folders?
                .Select(f => f.ToUserLibraryFolderDTO())
                .ToList()
                ?? new List<UserLibraryFolderDTO>();

            return View(foldersDTO);
        }

		[HttpPost("/add-folder-to-library")]
		public async Task<IActionResult> AddFolderToLibrary([FromBody] AddFolderToLibraryRequestDTO requestDTO)
		{
            requestDTO.UserId = this.UserId;
			if (!ModelState.IsValid) return BadRequest(ModelState);
            var folder = requestDTO.ToFolderFromAddFolderToLibraryRequestDTO();
            await _folderRepo.AddToLibrary(folder);

            var redirectUrl = Url.Action("Details", "Folders", new {slug = folder.Slug});
            return Ok(new { redirectUrl });
		}
	}
}
