// sharedVariables.js
// ==============================================
// Mô tả: File JavaScript này chứa các biến dùng chung trong các view _FlashcardsPartial, _CongratulationPartial
// ==============================================

//export const flashcardsContainer = document.querySelector('.flashcards-container');
//export const congratulationContainer = document.querySelector('.congratulation-container');

// Lấy 2 btn prev next card
//export const btnPrev = document.getElementById('btn-prev-card');
//export const btnNext = document.getElementById('btn-next-card');

// Lấy danh sách các card
export const cards = document.querySelectorAll('.term-defi-cards');

export const sharedVariables = {
    flashcardsContainer: document.querySelector('.flashcards-container'),
    congratulationContainer: document.querySelector('.congratulation-container'),
    currIndexCard: parseInt(document.querySelector('.flashcards-container').getAttribute('data-curr-index-card'), 10),
    btnPrev: document.getElementById('btn-prev-card'),
    btnNext: document.getElementById('btn-next-card'),
};
