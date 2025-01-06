// Lấy danh sách các card
const cards = document.querySelectorAll('.term-defi-cards');

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
    // Kiểm tra nếu phím space, mũi tên lên xuóng được nhấn
    if (event.code === 'Space' || event.code === 'ArrowUp' || event.code === 'ArrowDown') { 
        event.preventDefault(); // Ngăn hành vi mặc định của Space (scroll trang)

        cards.forEach(function (card) {
            flipCard(card);
        });
    }
});

// Lấy 2 btn prev next card
const btnPrev = document.getElementById('btn-prev-card');
const btnNext = document.getElementById('btn-next-card');

// Biến theo dõi index đang hiển thị
let currIndexCard = 0;

// Cập nhật số thứ tự hiển thị (1/total)
const updateCardNumber = () => {
    document.getElementById('card-number').textContent = `${currIndexCard + 1} / ${cards.length}`;
};

// Cập nhật trang thái của 2 btn prev next card
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
