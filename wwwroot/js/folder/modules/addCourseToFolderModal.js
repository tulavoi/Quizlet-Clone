
document.addEventListener('DOMContentLoaded', function () {
    const modal = document.querySelector('#add-course-to-folder-modal');

    if (modal) {
        modal.addEventListener("hidden.bs.modal", function () {
            location.reload();
        })
    }
});