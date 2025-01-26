// importFlashcardPartial.js
// ==============================================
// Mô tả: File JavaScript này chứa các hàm và logic dành riêng cho các
// chức năng trong _ImportFlashcardPartial.cshtml.
// ==============================================

import { termsSection } from './sharedVariables.js';
import { toggleContainer } from './toggleContainer.js';
import { renderTermsSection } from './termSection.js';

const termDefiTextarea = document.querySelector(".term-defi-textarea");

const separatorInputs = document.querySelectorAll('input[name="separator"]');
const tagSeparatorInputs = document.querySelectorAll('input[name="tag-separator"]');
const customTagSeparator = document.getElementById("custom-tag-separator");
const customSeparator = document.getElementById("custom-separator");

const previewItems = document.getElementById("preview-items");
const nonePreviewItems = document.getElementById("none-preview-items");
const countCard = document.getElementById("count-card");

let termDefinitionMap = new Map();

// Lắng nghe sự kiện khi người dùng nhập vào customSeparator
customSeparator.addEventListener('input', function () {
    // Kiểm tra nếu có giá trị trong customSeparator
    if (this.value.trim() !== '') {
        document.getElementById('custom').checked = true;
    }
});

// Lắng nghe sự kiện khi người dùng nhập vào customTagSeparator
customTagSeparator.addEventListener('input', function () {
    // Kiểm tra nếu có giá trị trong customTagSeparator
    if (this.value.trim() !== '') {
        document.getElementById('custom-tags').checked = true;
    }
});

// Cho phép bấm nút Tab (/t)
termDefiTextarea.addEventListener("keydown", function (e) {
    if (e.key === "Tab") {
        e.preventDefault(); // Ngăn chặn hành động mặc định của phím Tab
        const start = this.selectionStart;
        const end = this.selectionEnd;

        // Chèn ký tự '\t' tại vị trí con trỏ
        this.value = this.value.substring(0, start) + "\t" + this.value.substring(end);

        // Di chuyển con trỏ sau ký tự '\t'
        this.selectionStart = this.selectionEnd = start + 1;
    }
});

// Cập nhật placeholder của termDefiTextarea dựa trên các giá trị separator và tag separator đã chọn
function updatePlaceholder() {
    // Lấy giá trị separator và tagSeparator từ các lựa chọn
    const separator = getSeparatorValue();
    const tagSeparator = getTagSeparatorValue();

    // Tạo mảng các terms và định nghĩa của chúng, sử dụng separator giữa thuật ngữ và định nghĩa
    const terms = [
        `Từ 1${separator}Định nghĩa 1`,
        `Từ 2${separator}Định nghĩa 2`,
        `Từ 3${separator}Định nghĩa 3`
    ];

    // Cập nhật placeholder của termDefiTextarea bằng cách nối các terms với tagSeparator
    termDefiTextarea.placeholder = terms.join(tagSeparator);

    // Cập nhật lại preview sau khi placeholder được cập nhật
    updatePreview();
}

function getSeparatorValue() {
    // Lấy giá trị của input đã được chọn trong nhóm "separator"
    const selectedSepaator = document.querySelector('input[name="separator"]:checked').id;
    if (selectedSepaator == "custom") return customSeparator?.value || "\t"
    if (selectedSepaator == "tab") return "\t"
    return ",";
}

function getTagSeparatorValue() {
    // Lấy giá trị của input đã được chọn trong nhóm "tag-separator"
    const selectedTagSepaator = document.querySelector('input[name="tag-separator"]:checked').id;
    if (selectedTagSepaator == "custom-tags") return customTagSeparator?.value || "\n"
    if (selectedTagSepaator == "newline") return "\n"
    return ";";
}

// Cập nhật preview (xem trước) dựa trên giá trị nhập vào trong termDefiTextarea
function updatePreview() {
    const input = termDefiTextarea.value.trim();

    if (!input) resetPreviewItems();

    const separator = getSeparatorValue();
    const tagSeparator = getTagSeparatorValue();
    const map = convertInputToMap(input, separator, tagSeparator);

    termDefinitionMap = map; // Lưu map vào biến termDefinitionMap để sử dụng ở hàm khác

    if (input) renderPreviewItems(map);
}

// Reset lại preview-items nếu như không có dữ liệu trong textarea
function resetPreviewItems() {
    previewItems.innerHTML = "";
    nonePreviewItems.style.display = "block";
    countCard.textContent = `0 thẻ`;
}

// Hiển thị preview-items
function renderPreviewItems(map) {
    var fullHtml = "";
    var count = 0;

    for (const [key, value] of map) {
        fullHtml += createPreviewItemsHtml(key, value, count);
        count++;
    }

    previewItems.innerHTML = fullHtml;
    nonePreviewItems.style.display = "none";
    countCard.textContent = `${map.size} thẻ`;
}

// Tạo ra preview-items
function createPreviewItemsHtml(key, value, count) {
    const tempHTML = `
                    <div class="term-item mb-3">
                        <div class="row align-items-center">
                            <div class="col-1" style="max-width: 50px;">
                                <span class="text-secondary fw-bold fs-6">${count + 1}</span>
                            </div>
                            <div class="col-5">
                                <input type="text" class="custom-input" id="term-input" value="${key}" readonly disabled>
                            </div>
                            <div class="col-5">
                                <input type="text" class="custom-input" id="defi-input" value="${value}" readonly disabled>
                            </div>
                        </div>
                        <div class="row align-items-center">
                            <div class="col-1" style="max-width: 50px;"></div>
                            <div class="col-5">
                                <span class="fw-bold text-secondary" style="font-size: 10px;">THUẬT NGỮ</span>
                            </div>
                            <div class="col-5">
                                <span class="fw-bold text-secondary" style="font-size: 10px;">ĐỊNH NGHĨA</span>
                            </div>
                        </div>
                    </div>`;
    return tempHTML;
}

function convertInputToMap(input, separator, tagSeparator) {
    const map = new Map();

    // Tách input thành các phần tử, mỗi phần tử là một cặp key-value
    const pairs = input.split(tagSeparator);

    for (let i = 0; i < pairs.length; i++) {
        const part = pairs[i].split(separator); // Tách mỗi cặp thành key-value dựa trên separator
        const key = part[0]?.trim() || "";
        const value = part[1]?.trim() || "";
        map.set(key, value);
    }
    return map;
}

// Lắng nghe sự kiện "input" trên termDefiTextarea và gọi hàm updatePreview khi nội dung thay đổi
termDefiTextarea.addEventListener("input", updatePreview);

// Lặp qua tất cả các input có tên 'separator' và lắng nghe sự kiện "change" để gọi hàm updatePlaceholder khi người dùng thay đổi lựa chọn phân tách
separatorInputs.forEach(input => input.addEventListener("change", updatePlaceholder));

// Lặp qua tất cả các input có tên 'tag-separator' và lắng nghe sự kiện "change" để gọi hàm updatePlaceholder khi người dùng thay đổi lựa chọn phân tách thẻ
tagSeparatorInputs.forEach(input => input.addEventListener("change", updatePlaceholder));

// Nếu có customTagSeparator, lắng nghe sự kiện "input" để gọi hàm updatePlaceholder khi người dùng thay đổi giá trị
if (customTagSeparator) customTagSeparator.addEventListener("input", updatePlaceholder);

// Nếu có customSeparator, lắng nghe sự kiện "input" để gọi hàm updatePlaceholder khi người dùng thay đổi giá trị
if (customSeparator) customSeparator.addEventListener("input", updatePlaceholder);

updatePlaceholder();
updatePreview();

// Xử lý event import-btn
document.getElementById('import-btn').addEventListener('click', () => {
    toggleContainer('.import-flashcards-container', '.create-course-container', '#f6f7fb');

    if (termDefinitionMap.size == 0 || ![...termDefinitionMap.keys()].length) return;

    // Xóa các term-item cũ trong terms-section 
    termsSection.innerHTML = '';

    renderTermsSection(termDefinitionMap);
});