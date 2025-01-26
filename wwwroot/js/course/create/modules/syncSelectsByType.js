import { termsSection } from './sharedVariables.js';

// Đồng bộ giá trị trong btn-choose-language
function syncSelectsByType(dataType) {
    termsSection.addEventListener('change', event => {
        const target = event.target;

        // Kiểm tra nếu thẻ bị thay đổi là một <select> và có data-type phù hợp
        if (target.tagName === 'SELECT' && target.getAttribute('data-type') === dataType) {
            const selectedValue = target.value; // Lấy giá trị được chọn

            // Chỉ cập nhật các select có cùng data-type
            const selects = document.querySelectorAll(`select[data-type="${dataType}"]`);
            selects.forEach(otherSelect => {
                otherSelect.value = selectedValue;
            });
        }
    });
}

syncSelectsByType("term");
syncSelectsByType("definition");