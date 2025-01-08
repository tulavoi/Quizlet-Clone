// Lấy danh sách các card
const cards = document.querySelectorAll('.term-defi-cards');

// Lấy 2 btn prev next card
const btnPrev = document.getElementById('btn-prev-card');
const btnNext = document.getElementById('btn-next-card');

// Biến theo dõi index đang hiển thị
let currIndexCard = 0;

// Gắn sự kiện click cho từng thẻ để lật thẻ
cards.forEach(function (card) {
    card.addEventListener('click', function () {
        flipCard(this);
    });
});

// Lắng nghe sự kiện từ bàn phím
document.addEventListener('keydown', function (event) {
    switch (event.code) {
        case 'Space':
        case 'ArrowUp':
        case 'ArrowDown':
            event.preventDefault(); // Ngăn hành vi mặc định của các nút vừa bấm
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

// Hàm reset thẻ hiện tại
function resetCurrentCard() {
    resetCard(cards[currIndexCard]);
    updateCardDisplay();
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
    if (currIndexCard < cards.length - 1) {
        currIndexCard++;
        resetCurrentCard();
    }
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

// Sự kiện click button thẻ trước đó
btnPrev.addEventListener('click', moveToPrevCard);

// Sự kiện click button thẻ tiếp theo
btnNext.addEventListener('click', moveToNextCard);

updateCardDisplay();

// Gắn sự kiện click cho các button trong card-actions để ngăn lật thẻ
const actionButtons = document.querySelectorAll('.card-actions button');
actionButtons.forEach(function (button) {
    button.addEventListener('click', function (event) {
        event.stopPropagation(); // Ngừng lan truyền sự kiện lên các phần tử cha
    });
});

function playTextToSpeech(text, lang) {
    const utterance = new SpeechSynthesisUtterance(text);
    utterance.lang = lang; // Set language code (e.g., "en-US", "vi-VN")
    window.speechSynthesis.speak(utterance);
}

cards.forEach(card => {
    // Chọn các phần tử trong card hiện tại
    const btnSoundFront = card.querySelector('#btn-sound-front');
    const btnSoundBack = card.querySelector('#btn-sound-back');

    const textFront = card.querySelector('#text-front').innerText;
    const langFront = card.querySelector('input[name="termLangCode"]').value;

    const textBack = card.querySelector('#text-back').innerText;
    const langBack = card.querySelector('input[name="defiLangCode"]').value;

    // Gắn sự kiện cho nút btnSoundFront trong card hiện tại
    if (btnSoundFront) {
        btnSoundFront.addEventListener('click', function () {
            playTextToSpeech(textFront, langFront);
        });
    }

    // Gắn sự kiện cho nút btnSoundBack trong card hiện tại
    if (btnSoundBack) {
        btnSoundBack.addEventListener('click', function () {
            playTextToSpeech(textBack, langBack);
        });
    }
});

// Bật tắt trộn thẻ
function toggleShuffle() {
    // Lấy giá trị hiện tại của isShuffle từ URL hiện tại
    var urlParams = new URLSearchParams(window.location.search);
    const isShuffle = urlParams.get('isShuffle') === 'true'; // Kiểm tra isShuffle có = true hay k

    const newIsShuffle = !isShuffle;

    // Lấy slug từ URL hiện tại
    const slug = window.location.pathname.split('/').pop();

    // Chuyển tới url mới
    window.location.href = `/${slug}?isShuffle=${newIsShuffle}`;
}

// Sự kiện khi click vào play/pause (tự động cuộn thẻ)
document.getElementById('btn-enable-play-cards').addEventListener('click', function () {
    var iconPlay = this.querySelector('i'); // Lấy thẻ <i> trong btnEnable

    if (iconPlay.classList.contains("fa-play")) {
        iconPlay.classList.replace("fa-play", "fa-pause");
        this.title = "Tạm dừng";

        let timeDelay = 1500; // Thời gian delay thực hiện các hành động

        cards.forEach(function (card) {
            // Lật thẻ sau 1.5s
            setTimeout(() => flipCard(card), timeDelay);

            // Reset lại thẻ và chuyển tới thẻ tiếp theo 
            setTimeout(() => moveToNextCard(), timeDelay + 1500);

            timeDelay += 3000;
        });
    } else {
        iconPlay.classList.replace("fa-pause", "fa-play");
        this.title = "Bắt đầu";
    }
});
