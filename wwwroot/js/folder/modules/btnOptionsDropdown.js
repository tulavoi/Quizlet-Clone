document.addEventListener("DOMContentLoaded", function () {
	const buttons = document.querySelectorAll(".btn-options");

	buttons.forEach((btn) => {
		btn.addEventListener("click", function (event) {
			// Đóng tất cả các dropdown khác trước khi mở cái mới
			buttons.forEach((b) => {
				if (b !== btn) b.classList.remove("active");
			});

			this.classList.toggle("active");
			event.preventDefault();  // Ngăn thẻ <a> chuyển hướng
			event.stopPropagation(); // Ngăn chặn sự kiện click lan ra ngoài
		});
	});

	// Đóng dropdown khi click ra ngoài
	document.addEventListener("click", function () {
		buttons.forEach((btn) => btn.classList.remove("active"));
	});
});