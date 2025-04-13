
var steps = 0;
var questionsPerStep = 0;

export function updateStudyProgressBar() {
    const totalQuestions = parseInt(document.querySelector('.total-pill span').textContent, 10);

    const result = getStepSize(totalQuestions);
    if (!result) return;

    questionsPerStep = result.questionsPerStep;
    steps = result.steps;

    const track = document.querySelector('.progress-bar-track');

    if (!track) return;

    // Xóa các progress-step cũ
    track.innerHTML = '';

    for (let i = 0; i < steps; i++) {
        const step = document.createElement('div');
        step.classList.add('progress-step');
        step.style.background = 'var(--border-button-color)';

        // Nếu là bước đầu tiên thì thêm badge và số thứ tự
        if (i === 0) {
            const indicator = document.createElement('div');
            indicator.classList.add('progress-indicator');

            const badge = document.createElement('div');
            badge.classList.add('progress-badge');

            const number = document.createElement('p');
            number.classList.add('progress-number');
            number.textContent = '0';

            badge.appendChild(number);
            indicator.appendChild(badge);
            step.appendChild(indicator);
        }

        track.appendChild(step);
    }
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

export function checkAnswer(isCorrect) {
    if (!isCorrect) return;

    updateBadge();
}
window.checkAnswer = checkAnswer;

function updateBadge() {
    // Tăng số trên badge
    let progressNumber = document.querySelector('.progress-number');
    let current = parseInt(progressNumber.textContent, 10) + 1;
    progressNumber.textContent = current;

    const progressSteps = document.querySelectorAll('.progress-step');
    const progressStep = progressSteps[0];
    const progressIndicator = document.querySelector('.progress-indicator');

    // Cập nhật màu progress-step
    const percentage = Math.min((current / questionsPerStep) * 100, 100).toFixed(2);
    progressStep.style.setProperty('--progress-fill', `${percentage}%`);

    // Chưa cập nhật đc vị trí của badge 
    //const stepIndex = Math.max(Math.floor(current / questionsPerStep), 0);
    //const maxIndex = steps - 1;
    //const left = Math.min((stepIndex / maxIndex) * 100, 100).toFixed(2);
    //progressIndicator.style.left = `${left}%`;
}