// addNewCard.js
// ==============================================
// Mô tả: File JavaScript này chứa các hàm và logic dành riêng cho
// chức năng thêm thẻ mới trong Create.cshtml.
// ==============================================

import { termsSection } from './sharedVariables.js';

export async function addNewCard(){
    // Lấy tất cả các .term-item đang hiển thị
    const visibleTermItems = Array.from(document.querySelectorAll('.term-item')).filter(item => {
        return item.offsetParent !== null; // Kiểm tra xem phần tử có đang hiển thị không
    });

    let count = visibleTermItems.length; // Lấy count dựa trên số lượng term-item hiển thị
    count += 1; // Tăng count thêm 1 vì khi thêm một thẻ mới, tổng số lượng thẻ trên giao diện sẽ tăng lên

    const termLanguageId = document.querySelector('#btn-choose-language[data-type="term"]').value;
    const defiLanguageId = document.querySelector('#btn-choose-language[data-type="definition"]').value;

    try {
        const respone = await fetch(`/course/GetTermDefinitionPartial?count=${count}&termValue=&defiValue=
                                         &termLanguageId=${termLanguageId}&defiLanguageId=${defiLanguageId}`);

        const newCard = await respone.text();

        // Thêm card mới vào khu vực termsSection
        termsSection.insertAdjacentHTML('beforeend', newCard);

        // Cập nhật lại số thứ tự cho tất cả các term-item
        const updatedTermItems = document.querySelectorAll('.term-item-count');
        updatedTermItems.forEach((item, index) => {
            item.innerText = index + 1; // Số thứ tự bắt đầu từ 1
        });
    }
    catch (error) {
        console.error('Error loading menu languages: ', error);
    }
}
window.addNewCard = addNewCard;

function updateIndex() {

}