﻿// flashcardsPartial.js
// ==============================================
// Mô tả: File JavaScript này chứa các hàm và logic dành riêng cho
// phần xử lý chức năng trong file _FlashcardsPartial.cshtml.
// Bao gồm: các sự kiện click cho lật thẻ, lưu lại thẻ đã học, lưu lại thẻ xem cuối cùng,... v.v.
// ==============================================

// Import functions from confetti.js
import { triggerConfetti } from './confetti.js';

const flashcardsContainer = document.querySelector('.flashcards-container');
const congratulationContainer = document.querySelector('.congratulation-container');

// Lấy danh sách các card
export const cards = document.querySelectorAll('.term-defi-cards');

// Lấy index của card đã xem cuối cùng
export let currIndexCard = parseInt(flashcardsContainer.getAttribute('data-curr-index-card'), 10);

// Lấy 2 btn prev next card
const btnPrev = document.getElementById('btn-prev-card');
const btnNext = document.getElementById('btn-next-card');

// Gắn sự kiện click cho từng thẻ để lật thẻ
export function setupClickEventForCard() {
    cards.forEach(function (card) {
        card.addEventListener('click', function () {
            flipCard(this);
        });
    });
}

// Lắng nghe sự kiện từ bàn phím
export function pressKeyToFlipCard() {
    document.addEventListener('keydown', function (event) {
        switch (event.code) {
            case 'Space':
            case 'ArrowUp':
            case 'ArrowDown':
                event.preventDefault(); // Ngăn hành vi mặc định của các nút vừa bấm
                console.log(currIndexCard);
                flipCurrentCard();
                break;
            case 'ArrowLeft':
                event.preventDefault();
                moveToPrevCard();
                break;
            case 'ArrowRight':
                event.preventDefault();
                moveToNextCard();
                break;
        }
    });
}

// Lật thẻ
function flipCard(card) {
    card.querySelector('.card-inner').classList.toggle('is-flipped');
}

// Reset lật thẻ (không lật)
function resetCard(card) {
    card.querySelector('.card-inner').classList.remove('is-flipped');
}

// Hàm thực hiện lật thẻ
function flipCurrentCard() {
    flipCard(cards[currIndexCard]);
}

// Hàm di chuyển về thẻ trước
function moveToPrevCard() {
    if (currIndexCard > 0) {
        currIndexCard--;
        resetCurrentCard();
    }
}

// Hàm di chuyển tới thẻ tiếp theo
function moveToNextCard() {
    currIndexCard++;

    if (currIndexCard <= cards.length - 1) {
        resetCurrentCard();

        // Lấy ra id của card hiện tại
        const currCardId = getCurrentFlashcardId();
        saveLastReviewedCard(currCardId);

        // Nếu currIndexCard k phải card đầu tiên, lưu card trước đó (là card đã học)
        if (currIndexCard != 0) {
            const learnedCardId = getLearnedFlashcardId();
            if (learnedCardId) {
                saveLearnedCard(learnedCardId);
            }
        }
    }

    // Khi bấm qua thẻ cuối cùng, lưu lại thẻ đó và trạng thái đã học
    if (currIndexCard > cards.length - 1) {
        const learnedCardId = getLearnedFlashcardId();
        saveLearnedCard(learnedCardId);

        flashcardsContainer.classList.add('d-none');
        congratulationContainer.classList.remove('d-none');

        // Kích hoạt confetti
        triggerConfetti();
    }
}

// Lưu flashcard đã xem cuối cùng
function saveLastReviewedCard(flashcardId) {
    postFlashcardProgress('/fc-progress/save-last-reviewed-card', flashcardId, 'Failed to save last reviewed card');
}

// Lưu flashcards đã học
function saveLearnedCard(flashcardId) {
    postFlashcardProgress('/fc-progress/save-learned-card', flashcardId, 'Failed to save learned card');
}

function postFlashcardProgress(url, flashcardId, errorMessage) {
    fetch(url, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(flashcardId)
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

// Hàm reset thẻ hiện tại
function resetCurrentCard() {
    resetCard(cards[currIndexCard]);
    updateCardDisplay();
}

// Cập nhật hiển thị các card
function updateCardDisplay() {
    updateCardNumber();
    updateButtonState();

    // Ẩn tất cả các card
    cards.forEach((card, index) => {
        if (index === currIndexCard) {
            card.classList.remove('d-none'); // Hiển thị card hiện tại
        } else {
            card.classList.add('d-none'); // Ẩn các card khác
        }
    });
}

// Lấy id flashcard hiện tại (flashcard đang hiển thị)
function getCurrentFlashcardId() {
    const currCard = cards[currIndexCard];
    return currCard.getAttribute('data-flashcard-id');
}

// Lấy id flashcard đã học (flashcard vừa bấm qua là flashcard đã học)
function getLearnedFlashcardId() {
    if (currIndexCard > 0) {
        const prevCard = cards[currIndexCard - 1];
        return prevCard.getAttribute('data-flashcard-id');
    }
    return null;
}

// Cập nhật số thứ tự hiển thị (1/total)
const updateCardNumber = () => {
    document.getElementById('card-number').textContent = `${currIndexCard + 1} / ${cards.length}`;
};

// Cập nhật trang thái của 2 btn prev/next card
function updateButtonState() {
    const iconPrev = btnPrev.querySelector('i');  // Lấy thẻ <i> bên trong nút
    const isFirstCard = currIndexCard === 0;

    btnPrev.disabled = isFirstCard;
    btnPrev.style.pointerEvents = isFirstCard ? "none" : "";
    iconPrev.style.color = isFirstCard ? "#282e3e1a" : "#6c757d";
}

// Sự kiện click button thẻ trước đó
btnPrev.addEventListener('click', moveToPrevCard);

// Sự kiện click button thẻ tiếp theo
btnNext.addEventListener('click', moveToNextCard);

updateCardDisplay();

const btnPlayCards = document.getElementById('btn-play-cards');
const icon = btnPlayCards.querySelector('i');
let isPlaying = false; // Trạng thái đang chạy hay không
let timeoutId; // Lưu trữ ID của timeout

// Hàm xử lý logic lật và chuyển thẻ
function processCard() {
    if (!isPlaying) return; // Nếu đã pause, dừng ngay

    const currCard = cards[currIndexCard];
    const isFlipped = currCard.querySelector('.card-inner').classList.contains('is-flipped');

    // Nếu như là thẻ cuối và đã đc lật thì dừng cuộn thẻ
    if (currIndexCard === cards.length - 1 && isFlipped) {
        // Khi hoàn thành tất cả thẻ
        stopPlaying();
        return;
    }

    if (isFlipped) {
        // Nếu thẻ đang ở mặt sau, reset và chuyển sang thẻ tiếp theo
        timeoutId = setTimeout(moveToNextCard, 1500);
        timeoutId = setTimeout(processCard, 1500); // Gọi lại hàm sau 1.5 giây
    } else {
        // Nếu thẻ đang ở mặt trước, chờ 1.5 giây, lật ra mặt sau
        timeoutId = setTimeout(() => {
            flipCard(currCard);
            timeoutId = setTimeout(() => {
                moveToNextCard();
                processCard(); // Chuyển sang thẻ tiếp theo
            }, 1500); // Đợi thêm 1.5 giây trước khi reset và chuyển
        }, 1500);
    }
}

// Hàm bắt đầu chạy lật thẻ
function startPlaying() {
    isPlaying = true;
    icon.classList.replace('fa-play', 'fa-pause');
    icon.title = 'Tạm dừng';

    processCard(); // Bắt đầu hoặc tiếp tục xử lý từ vị trí hiện tại
}

// Hàm dừng lật thẻ
function stopPlaying() {
    isPlaying = false;
    icon.classList.replace('fa-pause', 'fa-play');
    icon.title = 'Bắt đầu';

    clearTimeout(timeoutId); // Hủy bất kỳ timeout nào đang chờ
}

// Xử lý sự kiện click nút play/pause
btnPlayCards.addEventListener('click', function () {
    if (isPlaying) {
        stopPlaying();
    } else {
        startPlaying();
    }
});

// Bật tắt trộn thẻ
export function toggleShuffle(courseId, isShuffle) {
    isShuffle = isShuffle.toLowerCase() === 'true';
    isShuffle = !isShuffle;

    fetch("/course-progress/update-progress", {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            courseId: courseId,
            isShuffle: isShuffle
        })
    })
    .then(response => {
        if (!response.ok) {
            console.error('failed to update shuffle mode');
        } else {
            // Lưu trạng thái isShuffle vào localStorage trước khi refresh
            localStorage.setItem('shuffleState', isShuffle ? 'Bật' : 'Tắt');

            window.location.reload(); // Refresh lại trang hiện tại sau khi cập nhật thành công
        }
    })
    .catch(error => {
        console.error('Error:', error);
    });
}
window.toggleShuffle = toggleShuffle;

document.addEventListener('DOMContentLoaded', function () {
    showShuffleNotify();
    
    updateShuffleButtonState();
});

// Hiển thị shuffle notify 
function showShuffleNotify() {
    const shuffleState = localStorage.getItem('shuffleState');

    if (shuffleState) {
        const shuffleNotifies = document.querySelectorAll('.shuffle-notify');

        shuffleNotifies.forEach(shuffleNotify => {
            shuffleNotify.textContent = `Trộn thẻ đang ${shuffleState}`;
            shuffleNotify.classList.remove('d-none');

            setTimeout(() => {
                shuffleNotify.classList.add('d-none');
            }, 3000); // Ẩn shuffleNotify sau 3 giây
        });

        // Xóa trạng thái sau khi hiển thị
        localStorage.removeItem('shuffleState');
    }
}

// Cập nhật trạng thái của button shuffle 
function updateShuffleButtonState() {
    const btnShuffle = document.querySelector('#btn-shuffle');
    const isShuffle = btnShuffle.getAttribute('data-is-shuffle').toLowerCase() === 'true';
    // Cập nhật class của nút btn-shuffle
    if (isShuffle) {
        btnShuffle.classList.add('border-1');
    } else {
        btnShuffle.classList.remove('border-1');
    }
}