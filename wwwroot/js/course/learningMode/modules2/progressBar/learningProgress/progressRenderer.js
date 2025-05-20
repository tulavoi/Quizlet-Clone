
import { getStepSize } from '../../quiz/quizState.js';

//let numberOfQuestions = getNumberOfQuestions();

let stepSize = getStepSize();

const learningProgress = document.querySelector('#learningProgress');

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

export function displayLearningProgress() {
    document.querySelector('.learning-progress-container').classList.remove('d-none');
}

export function hideLearningProgress() {
    document.querySelector('.learning-progress-container').classList.add('d-none');
}