using api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.CodeAnalysis.Operations;
using QuizletClone.DTOs.Folder;
using QuizletClone.Helpers;
using QuizletClone.Interfaces;
using QuizletClone.Mappers;
using System.Globalization;

namespace QuizletClone.Controllers
{
    [Authorize]
    [Route("folders")]
    public class FoldersController : BaseController
    {
        private readonly IFolderRepository _folderRepo;
        private readonly IUserCourseProgressRepository _courseProgressRepo;

		public FoldersController(IFolderRepository folderRepo, IUserCourseProgressRepository courseProgressRepo)
        {
            _folderRepo = folderRepo;
            _courseProgressRepo = courseProgressRepo;
		}

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateFolderRequestDTO createRequestDTO)
        {
            createRequestDTO.UserId = this.UserId;
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var folder = createRequestDTO.ToFolderFromCreateDTO();
            await _folderRepo.CreateAsync(folder);
            return RedirectToAction(nameof(Details), new { slug = folder.Slug });
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            // Lấy folder folderId dựa vào slug
            int folderId = SlugHelper.GetIdBySlug(slug);

            var folder = await _folderRepo.GetByIdAsync(folderId);
            if (folder == null) return NotFound();

            var courseProgress = await _courseProgressRepo.GetAllByUserAsync(this.UserId, new CourseQueryObject
            {
                SortBy = "LastUpdated",
                IsDescending = true,
                GetAll = true
            });

            var coursesInFolder = await _folderRepo.GetCourseInFolderAsync(folderId);

            return View(folder.ToFolderDetailDTO(courseProgress, coursesInFolder));
        }

        [HttpPost("update/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateFolderRequestDTO folderDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var folder = folderDTO.ToFolderFromUpdateDTO();
            await _folderRepo.UpdateAsync(id , folder);
            return Ok();
		}

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var folder = await _folderRepo.DeleteAsync(id);
            if (folder == null) return NotFound();
			return RedirectToAction("Index", "Home"); // Quay về trang chủ
        }
    }
}
