// sharedVariables.js
// ==============================================
// Mô tả: File JavaScript này chứa các biến dùng chung trong các view _FlashcardsPartial, _CongratulationPartial
// ==============================================

// Lấy danh sách các card
export const cards = document.querySelectorAll('.term-defi-cards');

export const sharedVariables = {
    flashcardsContainer: document.querySelector('.flashcards-container'),
    congratulationContainer: document.querySelector('.congratulation-container'),
    currIndexCard: parseInt(document.querySelector('.flashcards-container').getAttribute('data-curr-index-card'), 10),
    btnPrev: document.getElementById('btn-prev-card'),
    btnNext: document.getElementById('btn-next-card'),
};

export async function postData(url, data, errorMessage) {
    fetch(url, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data)
    })
    .then(response => {
        if (!response.ok) {
            console.error(errorMessage);
        }
    })
    .catch(error => {
        console.error('Error:', error);
    });
}