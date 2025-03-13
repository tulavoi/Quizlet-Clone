﻿using api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuizletClone.DTOs.Course;
using QuizletClone.DTOs.Flashcard;
using QuizletClone.Helpers;
using QuizletClone.Interfaces;
using QuizletClone.Mappers;
using QuizletClone.Models;

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

        public CourseController(
            IPermissionRepository permissionRepo,
            ILanguageRepository languageRepo, 
            ICourseRepository courseRepo,
            IFlashcardRepository flashcardRepo,
            IUserFlashcardProgressRepository flashcardProgressRepo,
            IUserCourseProgressRepository courseProgressRepo)
        {
            _permissionRepo = permissionRepo;
            _languageRepo = languageRepo;
            _courseRepo = courseRepo;
            _flashcardRepo = flashcardRepo;
            _flashcardProgressRepo = flashcardProgressRepo;
            _courseProgressRepo = courseProgressRepo;
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

            // Lấy ra danh sách flashcard progress của user trong học phần
            var flashcardProcresses = await _flashcardProgressRepo.GetByIdAsync(this.UserId, course.Id);

            // Nếu isStarred = true thì lấy starredFlashcards, nếu = false thì lấy tất cả flashcard
            var flashcards = isStarred ? starredFlashcards : course.Flashcards.ToList();

            // Nếu isShuffle đều là true, trộn các flashcards
            if (courseProcress.IsShuffle)
            {
                var rand = new Random();
                flashcards = flashcards
                    .OrderBy(_ => rand.Next()) // Sử dụng Random để xáo trộn ngẫu nhiên
                    .ToList();
            }

            var courseDTO = course.ToCourseDTO(
                flashcards, 
                lastReviewedCard, 
                learnedFlashcards, 
                notLearnedFlashcards, 
                flashcardProcresses,
                starredFlashcards.Count,
                courseProcress.IsShuffle
            );

            return View(courseDTO);
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
