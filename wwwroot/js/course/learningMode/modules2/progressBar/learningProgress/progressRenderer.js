
const learningProgress = document.querySelector('#learningProgress');
let totalQuestions = parseInt(learningProgress.querySelector('.total-pill').textContent, 10);

export let stepSize = getStepSize();

export function getQuestionPerStep(index) {
    return stepSize[index];
}

export function renderLearningProgess() {
    if (!stepSize) return;

    const track = learningProgress.querySelector('.progress-bar-track');
    if (!track) return;
    track.innerHTML = "";

    // Tạo HTML cho từng step
    track.innerHTML = buildProgressStepHtml(stepSize);
}

function buildProgressStepHtml(stepSize) {
    let html = '';
    for (let i = 0; i < stepSize.length; i++) {
        html += `
            <div class="progress-step" style="background: var(--border-button-color);">
                ${i === 0 ? `
                    <div class="progress-indicator">
                        <div class="progress-badge">
                            <p class="progress-number" id="correctAnswerCount">0</p>
                        </div>
                    </div>
                ` : ''}
            </div>
        `;
    }
    return html;
}

function getStepSize() {
    // Các số lượng question/step được ưu tiên thử nghiệm
    const preferredPerStep = [5, 6, 7];
    var stepDistribution = [];

    // Trường hợp nếu số câu hỏi <= 14, chia làm 2 phần gần bằng nhau
    if (totalQuestions <= 14) {
        // Chia đều thành 2 phần
        const part1 = Math.ceil(totalQuestions / 2);
        const part2 = totalQuestions - part1;
        stepDistribution = [part1, part2];
    } else {
        // Tìm giá trị chia đều nhất trong preferredPerStep (tức là dư ít nhất)
        let bestPerStep = preferredPerStep[0];
        let minRemainder = totalQuestions;

        for (let perStep of preferredPerStep) {
            const remainder = totalQuestions % perStep;
            if (remainder < minRemainder) {
                bestPerStep = perStep;
                minRemainder = remainder;
                if (remainder === 0) break; // Nếu chia hết thì không cần tìm tiếp
            }
        }

        const steps = Math.floor(totalQuestions / bestPerStep);     // Số step
        const remainder = totalQuestions % bestPerStep;             // Phần dư cần phân phối

        // Duyệt qua số bước, phân phối phần dư vào các bước đầu
        for (let i = 0; i < steps; i++) {
            // Các bước đầu sẽ được cộng thêm 1 nếu vẫn còn dư
            stepDistribution.push(bestPerStep + (i < remainder ? 1 : 0));
        }
    }
    return stepDistribution;
}

export function displayLearningProgress() {
    document.querySelector('.learning-progress-container').classList.remove('d-none');
}

export function hideLearningProgress() {
    document.querySelector('.learning-progress-container').classList.add('d-none');
}