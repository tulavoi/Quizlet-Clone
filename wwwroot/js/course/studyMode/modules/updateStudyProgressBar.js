
var steps = 0;
var questionsPerStep = 0;

// Tạo và hiển thị các steps dựa vào tổng số câu hỏi
export function generateProgressStep() {
    const totalQuestions = parseInt(document.querySelector('.total-pill span').textContent, 10);

    const result = getStepSize(totalQuestions);
    if (!result) return;

    questionsPerStep = result.questionsPerStep;
    steps = result.steps;

    // Tìm phần tử bao progress-bar để render nội dung vào
    const track = document.querySelector('.progress-bar-track');
    if (!track) return;
    track.innerHTML = ''; // Xóa các progress-step cũ

    // Tạo HTML cho từng bước
    let html = '';
    for (let i = 0; i < steps; i++) {
        html += `
            <div class="progress-step" style="background: var(--border-button-color);">
                ${i === 0 ? `
                    <div class="progress-indicator">
                        <div class="progress-badge">
                            <p class="progress-number">0</p>
                        </div>
                    </div>
                ` : ''}
            </div>
        `;
    }
    track.innerHTML = html;
}

function getStepSize(totalQuestions) {
    if (totalQuestions <= 0 || !Number.isInteger(totalQuestions)) {
        return null;
    }

    // Các số lượng question/step được ưu tiên thử nghiệm
    const preferredPerStep = [5, 6, 7];
    let bestPlan = null;

    for (let perStep of preferredPerStep) {
        // Tính số step cần thiết (làm tròn lên)
        let steps = Math.ceil(totalQuestions / perStep);

        // Tính lại số câu hỏi mỗi step sao cho đều (dựa trên số step)
        let questionsPerStep = Math.ceil(totalQuestions / steps);

        // Tổng số câu hỏi thực tế sẽ được tạo (có thể dư)
        let totalGenerated = steps * questionsPerStep;

        const currPlan = { steps, questionsPerStep, totalGenerated };

        // Nếu currPlan tốt hơn kế hoạch hiện tại thì thay thế
        if (isBetterPlan(bestPlan, currPlan)) {
            bestPlan = currPlan;
        }
    }

    // Return best plan
    return {
        questionsPerStep: bestPlan.questionsPerStep,
        steps: bestPlan.steps
    };
}

function isBetterPlan(bestPlan, currPlan) {
    if (!bestPlan) return true;

    // Destructuring để lấy các giá trị cần so sánh
    const { totalGenerated: currTotal, steps: currSteps } = currPlan;
    const { totalGenerated: bestTotal, steps: bestSteps } = bestPlan;

    // Ưu tiên kế hoạch có ít câu dư hơn, nếu = nhau, chọn kế hoạch có ít step hơn
    return (
        currTotal < bestTotal || (currTotal == bestTotal && currSteps < bestSteps)
    );
}

// Xử lý khi user chọn đáp án đúng
export function checkAnswer(selectedAnswer) {
    if (!selectedAnswer) return;

    let isCorrect = selectedAnswer.dataset.correct === 'true';
    updateQuizUI(isCorrect, selectedAnswer);

    // Nếu chọn đúng đáp án thì cập nhật progress bar
    if (isCorrect) updateProgressBar();
}
window.checkAnswer = checkAnswer;

// Cập nhật giao diện câu hỏi khi user chọn đúng đáp án
function updateQuizUI(isCorrect, selectedAnswer) {
    const answers = document.querySelectorAll('.quiz-answer');
    const helpBtn = document.querySelector('.quiz-help-button');

    // Tìm đáp án đúng nếu như đã chọn đáp án sai
    let correctAnswer = null;
    if (!isCorrect) {
        correctAnswer = Array.from(answers).find(answer =>
            answer.dataset.correct === 'true'
        );
    }

    // Vô hiệu hóa các đáp án và help btn, trừ đáp án đúng
    answers.forEach(answer => {
        if (answer === selectedAnswer) {
            answer.classList.add(isCorrect ? 'is-correct' : 'is-incorrect');
        } else {
            answer.classList.add('is-disabled');
        }
    });

    helpBtn?.classList.add('is-disabled');

    // Nếu chọn sai, highlight đáp án đúng
    if (!isCorrect && correctAnswer) {
        correctAnswer.classList.remove('is-disabled');
        correctAnswer.classList.add('is-correct-2');
    }

    // Cập nhật tiêu đề và đổi màu chữ dựa vào câu hỏi đúng hay sai
    const quizCardTitle = document.querySelector('.quiz-answer-section .quiz-card-title span');
    if (quizCardTitle) {
        quizCardTitle.textContent = isCorrect ? "Xuất sắc!" : "Đừng lo, bạn vẫn đang học mà!";
        quizCardTitle.style.color = isCorrect ? "var(--green-deep)" : "var(--orange-deep)";
    }

    if (!isCorrect) showNotificationBar();
}

// Hiển thị thanh thông báo tiếp tục
function showNotificationBar() {
    const notification = document.querySelector('.notification-bar-container');
    const continueBtn = document.querySelector('.btn-continue');

    notification.classList.remove('d-none');
    requestAnimationFrame(() => {
        notification.classList.add('show'); // kích hoạt hiệu ứng
    });

    document.addEventListener('keydown', handleContinue);
    continueBtn.addEventListener('click', handleContinue);
}


// Xử lý khi bấm tiếp tục or phím bất kỳ
function handleContinue(){
    nextQuestion();
    hideNotificationBar();
}

// Ẩn thông báo tiếp tục
function hideNotificationBar() {
    const notification = document.querySelector('.notification-bar-container');
    notification.classList.add('d-none');
}

// Thực hiện chuyển sang câu hỏi tiếp theo
function nextQuestion() {
    console.log('next question');
}

function updateProgressBar() {
    const current = incrementBadgeNumber();
    const percentage = calculatePercentage(current);

    updateProgressStepColor(percentage);
    
    updateBagdePosition(percentage);
}

// Cập nhật vị trí của badge
function updateBagdePosition(percentage) {
    const progressIndicator = document.querySelector('.progress-indicator');
    progressIndicator.style.setProperty('--progress-indicator-0', `${percentage}%`);
    progressIndicator.style.setProperty('--progress-indicator-1', `translateX(calc(-1% * ${percentage}))`);
}

// Cập nhật màu progress-step
function updateProgressStepColor(percentage) {
    const progressStep = document.querySelectorAll('.progress-step')[0];
    progressStep.style.setProperty('--progress-fill', `calc(${percentage}% + .3rem)`);
}

// Tăng số trên badge
function incrementBadgeNumber() {
    const progressNumber = document.querySelector('.progress-number');
    let current = parseInt(progressNumber.textContent, 10) + 1;
    progressNumber.textContent = current;
    return current;
}

function calculatePercentage(current) {
    return Math.min((current / questionsPerStep) * 100, 100)
}