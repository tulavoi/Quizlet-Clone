
//// Lấy danh sách các card
//const cards = document.querySelectorAll('.term-defi-cards');

//// Lấy 2 btnCreateFolder prev next card
//const btnPrev = document.getElementById('btn-prev-card');
//const btnNext = document.getElementById('btn-next-card');

//// currIndexCard là biến theo dõi index đang hiển thị được truyền từ view Details.cshtml sang

//// Gắn sự kiện click cho từng thẻ để lật thẻ
//cards.forEach(function (card) {
//    card.addEventListener('click', function () {
//        flipCard(this);
//    });
//});

//// Lắng nghe sự kiện từ bàn phím
//document.addEventListener('keydown', function (event) {
//    switch (event.code) {
//        case 'Space':
//        case 'ArrowUp':
//        case 'ArrowDown':
//            event.preventDefault(); // Ngăn hành vi mặc định của các nút vừa bấm
//            flipCurrentCard();
//            break;
//        case 'ArrowLeft':
//            event.preventDefault();
//            moveToPrevCard();
//            break;
//        case 'ArrowRight':
//            event.preventDefault();
//            moveToNextCard();
//            break;
//    }
//});

//// Lật thẻ
//function flipCard(card) {
//    card.querySelector('.card-inner').classList.toggle('is-flipped');
//}

//// Reset lật thẻ (không lật)
//function resetCard(card) {
//    card.querySelector('.card-inner').classList.remove('is-flipped');
//}

//// Hàm thực hiện lật thẻ
//function flipCurrentCard() {
//    flipCard(cards[currIndexCard]);
//}

//// Hàm reset thẻ hiện tại
//function resetCurrentCard() {
//    resetCard(cards[currIndexCard]);
//    updateCardDisplay();
//}

//// Hàm di chuyển về thẻ trước
//function moveToPrevCard() {
//    if (currIndexCard > 0) {
//        currIndexCard--;
//        resetCurrentCard();
//    }
//}

//// Lấy id flashcard đã học (flashcard vừa bấm qua là flashcard đã học)
//function getLearnedFlashcardId() {
//    if (currIndexCard > 0) {
//        const prevCard = cards[currIndexCard - 1];
//        return prevCard.getAttribute('data-flashcard-id');
//    }
//    return null;
//}

//// Lấy id flashcard hiện tại (flashcard đang hiển thị)
//function getCurrentFlashcardId() {
//    const currCard = cards[currIndexCard];
//    return currCard.getAttribute('data-flashcard-id');
//}

//// Hàm di chuyển tới thẻ tiếp theo
//function moveToNextCard() {
//    if (currIndexCard < cards.length - 1) {
//        // Di chuyển tới card tiếp theo
//        currIndexCard++;
//        resetCurrentCard();

//        // Lấy ra id của card hiện tại
//        const currCardId = getCurrentFlashcardId();

//        // Nếu currIndexCard k phải card đầu tiên, lưu card trước đó (là card đã học)
//        if (currIndexCard != 0) {
//            const learnedCardId = getLearnedFlashcardId();
//            if (learnedCardId) {
//                saveLearnedCard(learnedCardId);
//            }
//        }

//        saveLastReviewedCard(currCardId);
//    }
//}

//// Lưu flashcard đã xem cuối cùng
//function saveLastReviewedCard(flashcardId) {
//    postFlashcardProgress('/fc-progress/save-last-reviewed-card', flashcardId, 'Failed to save last reviewed card');
//}

//// Lưu flashcards đã học
//function saveLearnedCard(flashcardId) {
//    postFlashcardProgress('/fc-progress/save-learned-card', flashcardId, 'Failed to save learned card');
//}

//function postFlashcardProgress(url, flashcardId, errorMessage) {
//    fetch(url, {
//        method: 'POST',
//        headers: { 'Content-Type': 'application/json' },
//        body: JSON.stringify(flashcardId)
//    })
//    .then(response => {
//        if (!response.ok) {
//            console.error(errorMessage);
//        }
//    })
//    .catch(error => {
//        console.error('Error:', error);
//    });
//}

//// Cập nhật số thứ tự hiển thị (1/total)
//const updateCardNumber = () => {
//    document.getElementById('card-number').textContent = `${currIndexCard + 1} / ${cards.length}`;
//};

//// Cập nhật trang thái của 2 btnCreateFolder prev/next card
//function updateButtonState() {
//    const iconPrev = btnPrev.querySelector('i');  // Lấy thẻ <i> bên trong nút
//    const isFirstCard = currIndexCard === 0;

//    btnPrev.disabled = isFirstCard;
//    btnPrev.style.pointerEvents = isFirstCard ? "none" : "";
//    iconPrev.style.color = isFirstCard ? "#282e3e1a" : "#6c757d";
//}

//// Cập nhật hiển thị các card
//function updateCardDisplay() {
//    updateCardNumber();
//    updateButtonState();

//    // Ẩn tất cả các card
//    cards.forEach((card, index) => {
//        if (index === currIndexCard) {
//            card.classList.remove('d-none'); // Hiển thị card hiện tại
//        } else {
//            card.classList.add('d-none'); // Ẩn các card khác
//        }
//    });
//}

//// Sự kiện click button thẻ trước đó
//btnPrev.addEventListener('click', moveToPrevCard);

//// Sự kiện click button thẻ tiếp theo
//btnNext.addEventListener('click', moveToNextCard);

//updateCardDisplay();

//// Gắn sự kiện click cho các button trong card-actions để ngăn lật thẻ
//const actionButtons = document.querySelectorAll('.card-actions button');
//actionButtons.forEach(function (button) {
//    button.addEventListener('click', function (event) {
//        event.stopPropagation(); // Ngừng lan truyền sự kiện lên các phần tử cha
//    });
//});

//// Phát âm thanh
//function textToSpeech(text, lang) {
//    const utterance = new SpeechSynthesisUtterance(text);
//    utterance.lang = lang; // Set language code (e.g., "en-US", "vi-VN")
//    window.speechSynthesis.speak(utterance);
//}

//const btnPlayCards = document.getElementById('btn-play-cards');
//const icon = btnPlayCards.querySelector('i');
//let isPlaying = false; // Trạng thái đang chạy hay không
//let timeoutId; // Lưu trữ ID của timeout

//// Hàm xử lý logic lật và chuyển thẻ
//function processCard() {
//    if (!isPlaying) return; // Nếu đã pause, dừng ngay

//    const currCard = cards[currIndexCard];
//    const isFlipped = currCard.querySelector('.card-inner').classList.contains('is-flipped');

//    // Nếu như là thẻ cuối và đã đc lật thì dừng cuộn thẻ
//    if (currIndexCard === cards.length - 1 && isFlipped) {
//        // Khi hoàn thành tất cả thẻ
//        stopPlaying();
//        return;
//    }

//    if (isFlipped) {
//        // Nếu thẻ đang ở mặt sau, reset và chuyển sang thẻ tiếp theo
//        timeoutId = setTimeout(moveToNextCard, 1500);
//        timeoutId = setTimeout(processCard, 1500); // Gọi lại hàm sau 1.5 giây
//    } else {
//        // Nếu thẻ đang ở mặt trước, chờ 1.5 giây, lật ra mặt sau
//        timeoutId = setTimeout(() => {
//            flipCard(currCard);
//            timeoutId = setTimeout(() => {
//                moveToNextCard();
//                processCard(); // Chuyển sang thẻ tiếp theo
//            }, 1500); // Đợi thêm 1.5 giây trước khi reset và chuyển
//        }, 1500);
//    }
//}

//// Hàm bắt đầu chạy lật thẻ
//function startPlaying() {
//    isPlaying = true;
//    icon.classList.replace('fa-play', 'fa-pause');
//    icon.title = 'Tạm dừng';

//    processCard(); // Bắt đầu hoặc tiếp tục xử lý từ vị trí hiện tại
//}

//// Hàm dừng lật thẻ
//function stopPlaying() {
//    isPlaying = false;
//    icon.classList.replace('fa-pause', 'fa-play');
//    icon.title = 'Bắt đầu';

//    clearTimeout(timeoutId); // Hủy bất kỳ timeout nào đang chờ
//}

//// Xử lý sự kiện click nút play/pause
//btnPlayCards.addEventListener('click', function () {
//    if (isPlaying) {
//        stopPlaying();
//    } else {
//        startPlaying();
//    }
//});

//// Bật tắt trộn thẻ
//function toggleShuffle() {
//    //Lấy giá trị hiện tại của isShuffle từ URL hiện tại
//    var urlParams = new URLSearchParams(window.location.search);
//    const isShuffle = urlParams.get('isShuffle') === 'true';
//    const isStarred = urlParams.get('isStarred') === 'true';

//    const newIsShuffle = !isShuffle;

//    // Lấy slug từ URL hiện tại
//    const slug = window.location.pathname.split('/').pop();

//    // Chuyển tới url mới
//    window.location.href = `/${slug}?isStarred=${isStarred}&isShuffle=${newIsShuffle}`;
//}

//// Bắt đầu quy trình gắn sao flashcard
//function starredFlashcard(btn) {
//    let isStarred = getDataIsStarredValue(btn);
//    const flashcardId = btn.getAttribute('data-flashcard-id');

//    // Đảo ngược trạng thái gắn sao
//    isStarred = !isStarred;

//    // Cập  nhật lại màu icon
//    updateBtnIconColor(btn, isStarred);

//    // Cập nhật giá trị trạng thái gắn sao của flashcard
//    updateFlashcardState(flashcardId, isStarred);

//    btn.setAttribute('data-is-starred', isStarred.toString());
//}

//// Lấy giá trị data-is-starred trong button
//function getDataIsStarredValue(btn) {
//    return btn.getAttribute('data-is-starred').toLowerCase() === 'true';
//}

//// Cập nhật màu icon của btnCreateFolder
//function updateBtnIconColor(btn, isStarred) {
//    const icon = btn.querySelector('i');
//    icon.style.color = isStarred ? '#FFCD1F' : '#6C757D';
//}

//// Lưu trạng thái gắn sao của flashcard
//function updateFlashcardState(flashcardId, isStarred) {
//    fetch('/fc-progress/starred-card', {
//        method: 'POST',
//        headers: { 'Content-Type': 'application/json' },
//        body: JSON.stringify({
//            flashcardId,
//            isStarred
//        })
//    })
//    .then(response => {
//        if (!response.ok) {
//            console.error(errorMessage);
//        } else {
//            // Cập nhật biến đếm starredCardCount(được khai báo và gán giá trị ở Details.cshtml)
//            // Tăng nếu gắn sao, giảm nếu gắn sao
//            starredCardCount = isStarred ? starredCardCount + 1 : starredCardCount - 1;

//            changeStateToggleStarred();
//        }
//    })
//    .catch(error => {
//        console.error('Error:', error);
//    });
//}

//// Bật/tắt toggleStarred 
//function changeStateToggleStarred() {
//    const switchElement = toggleStarred.closest('.switch');

//    if (starredCardCount > 0) {
//        toggleStarred.removeAttribute('disabled');
//        switchElement.removeAttribute('disabled'); 
//    } else {
//        toggleStarred.checked = false;
//        toggleStarred.setAttribute('disabled', 'true');
//        switchElement.setAttribute('disabled', 'true');
//    }

//    // Lấy giá trị hiện tại của isShuffle từ URL hiện tại
//    var urlParams = new URLSearchParams(window.location.search);
//    const isStarred = urlParams.get('isStarred') === 'true'; 
//    if (isStarred) {
//        toggleStarred.checked = true;
//    }
//}

//// Hàm chạy khi trang được load
//window.addEventListener('DOMContentLoaded', () => {
//    // Lặp qua tất cả các button để cập nhật màu sắc ban đầu
//    const buttons = document.querySelectorAll('[data-is-starred]');

//    buttons.forEach(btn => {
//        let isStarred = getDataIsStarredValue(btn);
//        updateBtnIconColor(btn, isStarred);
//    });

//    // Gọi lại hàm để kiểm tra có flashcard nào đc gắn sao k và cập nhật trạng thái
//    changeStateToggleStarred();
//});

//const toggleStarred = document.getElementById('toggleStarred');
//// Hàm khởi động lại flashcards
//function resetCards() {
//    let isStarred = toggleStarred.checked;

//    // Lấy slug từ URL hiện tại
//    const slug = window.location.pathname.split('/').pop();

//    if (isStarred) {
//        // Chuyển tới url mới
//        window.location.href = `/${slug}?isStarred=${isStarred}`;
//    } else {
//        window.location.href = `/${slug}`;
//    }
//}