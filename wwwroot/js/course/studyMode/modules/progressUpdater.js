
import { questions } from './questions.js';

export let steps = 0;
export let questionsPerStep = 0;
export let totalQuestions = questions.length;

// Tạo và hiển thị các steps dựa vào tổng số câu hỏi
export function generateProgressStep() {
    document.querySelector('.total-pill span').textContent = totalQuestions;

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

// Lấy ra số step dựa vào tổng câu hỏi
function getStepSize(totalQuestions) {
    if (totalQuestions <= 0 || !Number.isInteger(totalQuestions)) return null;

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

export function updateProgressBar(progress) {
    const current = incrementBadgeNumber(progress);
    const percentage = calculatePercentage(current, questionsPerStep);

    updateProgressStepColor(percentage, progress);
    
    updateBagdePosition(percentage, progress);
}

// Cập nhật vị trí của badge
export function updateBagdePosition(percentage, progress) {
    const progressIndicator = progress.querySelector('.progress-indicator');
    progressIndicator.style.setProperty('--progress-indicator-0', `${percentage}%`);
    progressIndicator.style.setProperty('--progress-indicator-1', `translateX(calc(-1% * ${percentage}))`);
}

// Cập nhật màu progress-step
export function updateProgressStepColor(percentage, progress) {
    const progressStep = progress.querySelectorAll('.progress-step')[0];
    progressStep.style.setProperty('--progress-fill', `calc(${percentage}% + .3rem)`);
}

// Tăng số trên badge
export function incrementBadgeNumber(progress) {
    const progressNumber = progress.querySelector('.progress-number');
    let current = parseInt(progressNumber.textContent, 10) + 1;
    progressNumber.textContent = current;
    return current;
}

export function calculatePercentage(current, numOfQuestions) {
    return Math.min((current / numOfQuestions) * 100, 100)
}