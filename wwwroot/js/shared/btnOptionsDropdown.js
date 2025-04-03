document.addEventListener("DOMContentLoaded", function () {
	const buttons = document.querySelectorAll(".btn-options");

	buttons.forEach((btn) => {
		btn.addEventListener("click", function (event) {
			// Ngăn chặn việc mở link khi click vào btn (chỉ khi btn nằm trong thẻ <a>)
			if (btn.closest("a")) {
				event.preventDefault();
			}

			// Đóng tất cả các dropdown khác trước khi mở cái mới
			buttons.forEach((b) => {
				if (b !== btn) b.classList.remove("active");
			});

			this.classList.toggle("active");
			event.stopPropagation(); // Ngăn chặn sự kiện click lan ra ngoài
		});
	});

	// Đóng dropdown khi click ra ngoài
	document.addEventListener("click", function () {
		buttons.forEach((btn) => btn.classList.remove("active"));
	});
});