﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.CodeAnalysis.Operations;
using QuizletClone.DTOs.Folder;
using QuizletClone.Helpers;
using QuizletClone.Interfaces;
using QuizletClone.Mappers;

namespace QuizletClone.Controllers
{
    [Authorize]
    [Route("folders")]
    public class FoldersController : BaseController
    {
        private readonly IFolderRepository _folderRepo;

        public FoldersController(IFolderRepository folderRepo)
        {
            _folderRepo = folderRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateFolderRequestDTO folderDTO)
        {
            folderDTO.UserId = this.UserId;
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var folder = folderDTO.ToFolderFromCreateDTO();
            await _folderRepo.CreateAsync(folder);
            return RedirectToAction(nameof(Details), new { slug = folder.Slug });
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            // Lấy folder id dựa vào slug
            int id = SlugHelper.GetIdBySlug(slug);

            var folder = await _folderRepo.GetByIdAsync(id);
            if (folder == null) return NotFound();
            
            return View(folder.ToFolderDTO());
        }

        [HttpPost("update/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateFolderRequestDTO folderDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _folderRepo.UpdateAsync(id , folderDTO);

            return Ok();
		}

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var folder = await _folderRepo.DeleteAsync(id);
            if (folder == null) return NotFound();
			return RedirectToAction("Index", "Home");
        }
    }
}
