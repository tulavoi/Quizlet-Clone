
function updateDescription(selectId, descriptionId, passwordInputClass) {
    const select = document.getElementById(selectId);

    // Lấy option đc chọn
    const selectedOption = select.options[select.selectedIndex];

    if (selectedOption.innerText.trim() == "Người có mật khẩu") {
        document.querySelector(passwordInputClass).style.display = 'block';
    } else {
        document.querySelector(passwordInputClass).style.display = 'none';
    }

    // Lấy description từ selectId
    const des = selectedOption.getAttribute("data-description");

    // Gán description vào thẻ <p>
    const perDescription = document.getElementById(descriptionId);
    perDescription.innerText = des;
}

document.getElementById('view-per-select').addEventListener("change", function () {
    updateDescription('view-per-select', 'view-per-description', '#view-per-course-password-input');
});

document.getElementById('edit-per-select').addEventListener("change", function () {
    updateDescription('edit-per-select', 'edit-per-description', '#edit-per-course-password-input');
})

// Gán sẵn description vào thẻ <p> khi trang vừa tải
window.addEventListener('DOMContentLoaded', () => {
    updateDescription('view-per-select', 'view-per-description', '#view-per-course-password-input');
    updateDescription('edit-per-select', 'edit-per-description', '#edit-per-course-password-input');
});

function syncPasswordInputs() {
    const viewPasswordInput = document.getElementById('view-per-course-password-input');
    const editPasswordInput = document.getElementById('edit-per-course-password-input');

    // Lắng nghe sự kiện 'input' trên ô view
    viewPasswordInput.addEventListener('input', function () {
        editPasswordInput.value = viewPasswordInput.value;
    });

    // Lắng nghe sự kiện 'input' trên ô edit
    editPasswordInput.addEventListener('input', function () {
        viewPasswordInput.value = editPasswordInput.value;
    });
}

//Đồng bộ giá trị trong 2 input password
syncPasswordInputs();