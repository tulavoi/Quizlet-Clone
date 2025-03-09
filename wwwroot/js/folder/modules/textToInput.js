const folderTitle = document.getElementById('folderTitle');
if (folderTitle) {

	folderTitle.addEventListener("click", editTitle);

	function editTitle() {
		let titleText = this.innerText;
		let textarea = document.createElement("textarea");
		textarea.value = titleText;
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
				saveTitle(textarea);
			}
		});

		// Khi mất focus, lưu lại tiêu đề
		textarea.addEventListener("blur", function () {
			saveTitle(textarea);
		});
	}

	function saveTitle(textarea) {
		let newTitle = textarea.value.trim();
		let h1 = document.createElement("h1");
		h1.id = "folderTitle";
		h1.innerText = newTitle.replace(/\n/g, " ");

		textarea.replaceWith(h1);
		console.log(newTitle);
		h1.addEventListener("click", editTitle); // Gán lại sự kiện click
	}
}