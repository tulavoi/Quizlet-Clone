import { } from './modules/createModal.js';
import { } from './modules/textToInput.js';

document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".btn-other").forEach(button => {
        button.addEventListener("click", function (event) {
            const dropdown = this.closest(".dropdown");
            document.querySelectorAll(".dropdown.show").forEach(d => {
                if (d !== dropdown) d.classList.remove("show");
            });
            dropdown.classList.toggle("show");
            event.stopPropagation();
        });
    });

    document.addEventListener("click", function (event) {
        document.querySelectorAll(".dropdown.show").forEach(dropdown => {
            if (!dropdown.contains(event.target)) {
                dropdown.classList.remove("show");
            }
        });
    });
});