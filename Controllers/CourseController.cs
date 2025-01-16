using api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCards.DTOs.Course;
using SmartCards.Helpers;
using SmartCards.Interfaces;
using SmartCards.Mappers;

namespace SmartCards.Controllers
{
	[Authorize]
    [Route("/course")]
	public class CourseController : BaseController
	{
		private readonly IPermissionRepository _permissionRepo;
		private readonly ILanguageRepository _languageRepo;
		private readonly ICourseRepository _courseRepo;
		private readonly IFlashcardRepository _flashcardRepo;
        private readonly IUserFlashcardProgressRepository _progressRepo;

        public CourseController(
            IPermissionRepository permissionRepo,
            ILanguageRepository languageRepo, 
            ICourseRepository courseRepo,
            IFlashcardRepository flashcardRepo,
            IUserFlashcardProgressRepository progressRepo)
        {
            _permissionRepo = permissionRepo;
            _languageRepo = languageRepo;
            _courseRepo = courseRepo;
            _flashcardRepo = flashcardRepo;
            _progressRepo = progressRepo;
        }

        [Route("/create-course")]
        public async Task<IActionResult> Create()
		{
            await this.SetViewBagForCreatCourse();
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
                await this.SetViewBagForCreatCourse();
                return View(courseDTO);
            }

            // Tạo học phần mới
            var course = courseDTO.ToCourseFromCreateDTO(this.UserId);
            await _courseRepo.CreateAsync(course, courseDTO.ViewPermissionId, courseDTO.EditPermissionId);

            return RedirectToAction(nameof(Details), new { slug = course.Slug });
        }

        [HttpGet("/{slug}")]
        public async Task<IActionResult> Details(string slug, [FromQuery] bool isShuffle = false, [FromQuery] bool isStarred = false)
        {
            int id = this.GetIdBySlug(slug);

            var course = await _courseRepo.GetByIdAsync(id, new CourseQueryObject { IsShuffle = isShuffle });
            if (course == null) return NotFound();

            // Lấy ra flashcard đã xen gần nhất trong học phần của user
            var lastReviewedCard = await _flashcardRepo.GetCurrentDisplayedAsync(this.UserId, course.Id);

            // Lấy ra flashcards user đã học trong học phần
            var learnedFlashcards = await _flashcardRepo.GetAllCardsInCourseAsync(this.UserId, course.Id, 
                new FlashcardQueryObject { IsLearned = true });

            // Lấy ra flashcards user chưa học trong học phần
            var notLearnedFlashcards = await _flashcardRepo.GetAllCardsInCourseAsync(this.UserId, course.Id, 
                new FlashcardQueryObject { IsLearned = false });

            // Lấy ra flashcards user đã gắn sao
            var starredFlashcards = await _flashcardRepo.GetStarredCardsInCourseAsync(this.UserId, course.Id,
                new FlashcardQueryObject { IsStarred = true });

            var starredCardsCount = starredFlashcards.Count;

            // Lấy ra danh sách progress của user trong học phần
            var procresses = await _progressRepo.GetByIdAsync(this.UserId, course.Id);

            // Nếu isStarred = true thì lấy starredFlashcards, nếu = false thì lá
            var flashcards = isStarred ? starredFlashcards : course.Flashcards.ToList();

            var courseDTO = course.ToCourseDTO(flashcards, lastReviewedCard, learnedFlashcards, notLearnedFlashcards, procresses, starredCardsCount);
            return View(courseDTO);
        }

        private int GetIdBySlug(string slug)
        {
            var parts = slug.Split('-');
            return int.Parse(parts[parts.Length - 1]);
        }

        private async Task SetViewBagForCreatCourse()
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
                count = count, 
                termValue = termValue, 
                defiValue = defiValue, 
                termLanguageId = termLanguageId, 
                defiLanguageId = defiLanguageId,
            };
            return PartialView("~/Views/Course/ViewPartials/Create/_TermDefinitionPartial.cshtml", model);
        }
    }
}
