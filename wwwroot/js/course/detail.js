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

// Lật thẻ
function flipCard(card) {
    card.querySelector('.card-inner').classList.toggle('is-flipped');
}

// Lắng nghe sự kiện từ bàn phím
document.addEventListener('keydown', function (event) {
    // Kiểm tra nếu phím space or mũi tên lên xuóng được nhấn
    if (event.code === 'Space' || event.code === 'ArrowUp' || event.code === 'ArrowDown') { 
        event.preventDefault(); // Ngăn hành vi mặc định của Space (scroll trang)

        cards.forEach(function (card) {
            flipCard(card);
        });
    }

    if (event.code === 'ArrowLeft') { // Mũi tên trái
        if (currIndexCard > 0) {
            currIndexCard--;
            updateCardDisplay();
        }
    } else if (event.code === 'ArrowRight') { // Mũi tên phải
        if (currIndexCard < cards.length - 1) {
            currIndexCard++;
            updateCardDisplay();
        }
    }
});

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

btnPrev.addEventListener('click', () => {
    if (currIndexCard > 0) {
        currIndexCard--;
        updateCardDisplay();
    }
});

btnNext.addEventListener('click', () => {
    if (currIndexCard < cards.length - 1) {
        currIndexCard++;
        updateCardDisplay();
    }
});

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

    // Gắn sự kiện cho nút "Phát âm mặt trước" trong card hiện tại
    if (btnSoundFront) {
        btnSoundFront.addEventListener('click', function () {
            playTextToSpeech(textFront, langFront);
        });
    }

    // Gắn sự kiện cho nút "Phát âm mặt sau" trong card hiện tại
    if (btnSoundBack) {
        btnSoundBack.addEventListener('click', function () {
            playTextToSpeech(textBack, langBack);
        });
    }
});

//// Gắn sự kiện cho 2 button sound
//document.getElementById('btn-sound-front').addEventListener('click', function () {
//    const text = document.getElementById('text-front').innerText;
//    const lang = document.querySelector('input[name="termLangCode"]').value;
//    playTextToSpeech(text, lang);
//});

//document.getElementById('btn-sound-back').addEventListener('click', function () {
//    const text = document.getElementById('text-back').innerText;
//    const lang = document.querySelector('input[name="defiLangCode"]').value;
//    playTextToSpeech(text, lang);
//});