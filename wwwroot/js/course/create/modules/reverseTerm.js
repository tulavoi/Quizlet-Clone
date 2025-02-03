document.getElementById('btn-reverse-term').addEventListener('click', function () {
    // Lấy tất cả các .term-def-input-row đang hiển thị
    const visibleTermDefiRows = Array.from(document.querySelectorAll('.term-def-input-row')).filter(item => {
        return item.offsetParent !== null; // Kiểm tra xem phần tử có đang hiển thị không
    });

    // Duyệt qua từng hàng và hoán đổi giá trị
    visibleTermDefiRows.forEach(row => {
        // Lấy các input trong row hiện tại, có name bắt đầu = Flashcard và kết thúc = Term/Definition
        const termInput = row.querySelector('input[name^="Flashcards"][name$=".Term"]');
        const definitionInput = row.querySelector('input[name^="Flashcards"][name$=".Definition"]');

        // Hoán đổi giá trị của input
        if (termInput && definitionInput) {
            const tempInputValue = termInput.value;
            termInput.value = definitionInput.value;
            definitionInput.value = tempInputValue;
        }

        // Lấy các select trong row hiện tại, có name bắt đầu = TermLanguageId/DefiLanguageId
        const termLanguageSelect = row.querySelector('select[name$=".TermLanguageId"]');
        const definitionLanguageSelect = row.querySelector('select[name$=".DefiLanguageId"]');

        // Hoán đổi giá trị của select
        if (termLanguageSelect && definitionLanguageSelect) {
            const tempSelectValue = termLanguageSelect.value;
            termLanguageSelect.value = definitionLanguageSelect.value;
            definitionLanguageSelect.value = tempSelectValue;
        }
    });
});