﻿
import { postData } from '../../shared/postData.js';

const folderTitle = document.getElementById('folderTitle');
if (folderTitle) {

	folderTitle.addEventListener("click", editTitle);

	function editTitle() {
		let currTitle = this.innerText;
		let textarea = document.createElement("textarea");
		textarea.value = currTitle;
		textarea.id = "titleFolderTextarea";
		textarea.maxLength = 60;
		textarea.minLength = 1;
		textarea.rows = 1;

		this.replaceWith(textarea);
		textarea.focus();

		// Khi nhấn Enter + Shift thì xuống dòng, còn Enter thì lưu
		textarea.addEventListener("keydown", function (event) {
			if (event.key === "Enter" && !event.shiftKey) {
				event.preventDefault(); // Ngăn xuống dòng
				saveTitle(textarea, currTitle);
			}
		});

		// Khi mất focus, lưu lại tiêu đề
		textarea.addEventListener("blur", function () {
			saveTitle(textarea, currTitle);
		});
	}

	function saveTitle(textarea, oldTitle) {
		let newTitle = textarea.value.trim();
		let h1 = document.createElement("h1");
		h1.id = "folderTitle";
		h1.innerText = newTitle.replace(/\n/g, " ");

		textarea.replaceWith(h1);
		h1.addEventListener("click", editTitle); // Gán lại sự kiện click

		// Nếu newTitle không trùng với oldTitle thì lưu vào database
		if (newTitle !== oldTitle) {
			const folderId = document.querySelector(".folder-title").getAttribute("data-folder-id"); // Lấy folderId
			postData(`update/${folderId}`, { title: newTitle });
		}
	}
}