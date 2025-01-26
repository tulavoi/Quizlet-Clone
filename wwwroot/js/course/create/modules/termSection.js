// termSection.js
// ==============================================
// Mô tả: File JavaScript này chứa các hàm và logic dành riêng cho 
// chức năng render ra term section trong Create.cshtml.
// ==============================================

import { termsSection } from './sharedVariables.js';
import { bindTrashButtonEvent } from './trashButtonEvent.js';

export async function renderTermsSection(map) {
    var fullHtml = "";
    var count = 0;

    for (const [key, value] of map) {
        fullHtml += await createTermsSectionHtml(key, value, count);
        count++;
    }

    termsSection.innerHTML = fullHtml;
    bindTrashButtonEvent();
}

async function createTermsSectionHtml(key, value, count) {
    // Mã hóa key và value để tránh mất các dấu (+,...)
    const encodedKey = encodeURIComponent(key);
    const encodedValue = encodeURIComponent(value);

    // Lấy ra partialview
    const respone = await fetch(`/course/GetTermDefinitionPartial?count=${count + 1}
            &termValue=${encodedKey}&defiValue=${encodedValue}`);
    const newCard = await respone.text();

    return newCard;
}