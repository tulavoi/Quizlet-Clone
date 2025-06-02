using api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuizletClone.DTOs.Course;
using QuizletClone.DTOs.Flashcard;
using QuizletClone.Helpers;
using QuizletClone.Interfaces;
using QuizletClone.Mappers;
using QuizletClone.Models;
using QuizletClone.ViewModels.Course;

namespace QuizletClone.Controllers
{
	[Authorize]
    [Route("course")]
	public class CourseController : BaseController
	{
		private readonly IPermissionRepository _permissionRepo;
		private readonly ILanguageRepository _languageRepo;
		private readonly ICourseRepository _courseRepo;
		private readonly IFlashcardRepository _flashcardRepo;
        private readonly IUserFlashcardProgressRepository _flashcardProgressRepo;
        private readonly IUserCourseProgressRepository _courseProgressRepo;
        private readonly IFolderRepository _folderRepo;

        public CourseController(
            IPermissionRepository permissionRepo,
            ILanguageRepository languageRepo, 
            ICourseRepository courseRepo,
            IFlashcardRepository flashcardRepo,
            IUserFlashcardProgressRepository flashcardProgressRepo,
            IUserCourseProgressRepository courseProgressRepo,
            IFolderRepository folderRepo)
        {
            _permissionRepo = permissionRepo;
            _languageRepo = languageRepo;
            _courseRepo = courseRepo;
            _flashcardRepo = flashcardRepo;
            _flashcardProgressRepo = flashcardProgressRepo;
            _courseProgressRepo = courseProgressRepo;
            _folderRepo = folderRepo;
        }

        [Route("/create-course")]
        public async Task<IActionResult> Create()
		{
            await this.SetViewBagForCreateCourse();
			return View();
		}

        [HttpPost("/create-course")]
        public async Task<IActionResult> Create(CreateCourseRequestDTO courseDTO)
        {
            // Kiểm tra và trả vê lỗi nếu có
            string errorMessage = _courseRepo.GetErrorMessage(courseDTO);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                TempData["ErrorMessage"] = errorMessage;
                await this.SetViewBagForCreateCourse();
                return View(courseDTO);
            }

            // Tạo học phần mới
            var course = courseDTO.ToCourseFromCreateDTO(this.UserId);
            await _courseRepo.CreateAsync(course, courseDTO.ViewPermissionId, courseDTO.EditPermissionId);

            // Sau khi tạo học phần thì lưu vào course progress
            await _courseProgressRepo.UpdateProgressAsync(this.UserId, course.Id);

            return RedirectToAction(nameof(Details), new { slug = course.Slug });
        }

        [HttpGet("/{slug}")]
        public async Task<IActionResult> Details(string slug, [FromQuery] bool isStarred = false)
        {
            // Lấy course id dựa vào slug
            int id = SlugHelper.GetIdBySlug(slug);

            // Lấy ra course
            var course = await _courseRepo.GetByIdAsync(id);
            if (course == null) return NotFound();

            // Lấy ra course progress của user
            var courseProcress = await _courseProgressRepo.GetByIdAsync(this.UserId, course.Id);

            // Lưu lại course progress khi user truy cập vào course
            await _courseProgressRepo.UpdateProgressAsync(this.UserId, course.Id, courseProcress.IsShuffle);

            // Lấy ra flashcard đã xem gần nhất trong học phần của user
            var lastReviewedCard = await _flashcardRepo.GetMostRecentlyAsync(this.UserId, course.Id);

            // Lấy ra flashcards user đã học trong học phần
            var learnedFlashcards = await _flashcardRepo.GetAllCardsInCourseAsync(this.UserId, course.Id, 
                new FlashcardQueryObject { IsLearned = true });

            // Lấy ra flashcards user chưa học trong học phần
            var notLearnedFlashcards = await _flashcardRepo.GetAllCardsInCourseAsync(this.UserId, course.Id, 
                new FlashcardQueryObject { IsLearned = false });

            // Lấy ra flashcards user đã gắn sao
            var starredFlashcards = await _flashcardRepo.GetAllCardsInCourseAsync(this.UserId, course.Id,
                new FlashcardQueryObject { IsStarred = true });

            // Lấy ra danh sách flashcard progress của user trong học phần
            var flashcardProcresses = await _flashcardProgressRepo.GetByCourseIdAsync(this.UserId, course.Id);

            // Nếu isStarred = true thì lấy starredFlashcards, nếu = false thì lấy tất cả flashcard
            var flashcards = isStarred ? starredFlashcards : course.Flashcards.ToList();

            // Nếu isShuffle đều là true, trộn các flashcards
            if (courseProcress.IsShuffle)
            {
                flashcards = flashcards
                    .OrderBy(_ => Guid.NewGuid()) // Sử dụng Random để xáo trộn ngẫu nhiên
                    .ToList();
            }

            var courseDTO = course.ToCourseDetailDTO(
                flashcards, 
                lastReviewedCard, 
                learnedFlashcards, 
                notLearnedFlashcards, 
                flashcardProcresses,
                starredFlashcards.Count,
                courseProcress.IsShuffle
            );

            // Lấy các folder của user
            var folders = await _folderRepo.GetAllAsync(this.UserId, new FolderQueryObject
            {
                SortBy = "CreatedAt",
                IsDescending = true,
            });

            // Lấy các folder chứa course
            var foldersContainingCourse = await _folderRepo.GetFoldersContainingCourseAsync(courseDTO.Id, this.UserId);

            var viewModel = new CourseDetailViewModel
            {
                Course = courseDTO,
                Folders = folders!.Select(f => f.ToFolderDTO()).ToList(),
                FoldersContainingCourse = foldersContainingCourse!.Select(f => f.ToFolderDTO()).ToList()
            };

            return View(viewModel);
        }

        private async Task SetViewBagForCreateCourse()
        {
            ViewBag.EditPermissions = await _permissionRepo.GetAllAsync(new PermissionQueryObject { IsEdit = true });
            ViewBag.ViewPermissions = await _permissionRepo.GetAllAsync(new PermissionQueryObject { IsEdit = false });
            ViewBag.Languages = await _languageRepo.GetAllAsync(new LanguageQueryObject { SortBy = "Name" });
        }

        // Trả về Html của PartialView
        [HttpGet]
        [Route("GetTermDefinitionPartial")]
        public async Task<IActionResult> GetTermDefinitionPartial(
            [FromQuery] int count,
            [FromQuery] string termValue, 
            [FromQuery] string defiValue, 
            [FromQuery] int termLanguageId, 
            [FromQuery] int defiLanguageId)
        {
            ViewBag.Languages = await _languageRepo.GetAllAsync(new LanguageQueryObject { SortBy = "Name" });
            var model = new { 
                count, 
                termValue, 
                defiValue, 
                termLanguageId, 
                defiLanguageId,
            };
            return PartialView("~/Views/Course/ViewPartials/Create/_TermDefinitionPartial.cshtml", model);
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var course = await _courseRepo.DeleteAsync(id);
            if (course == null) return NotFound();
			return RedirectToAction("Index", "Home"); // Quay về trang chủ
        }
    }
}
