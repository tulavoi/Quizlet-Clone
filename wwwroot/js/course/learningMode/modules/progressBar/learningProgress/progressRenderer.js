
import { getStepSize, getTotalCorrectAnswers, getStepIndex } from '../../quiz/quizState.js';

const learningProgress = document.querySelector('#learningProgress');

export function renderLearningProgess() {
    let stepSize = getStepSize();
    if (!stepSize) return;

    const track = learningProgress.querySelector('.progress-bar-track');
    if (!track) return;
    track.innerHTML = "";

    // Tạo HTML cho từng step
    track.innerHTML = buildProgressStepHtml(stepSize);
}

function buildProgressStepHtml(stepSize) {
    let stepIndex = getStepIndex();
    let html = '';
    for (let i = 0; i < stepSize.length; i++) {
        html += `
            <div class="progress-step" style="background: ${i < stepIndex ? 'var(--primary-green -color)' : 'var(--border-button-color)'};">
                ${i === stepIndex ? `
                    <div class="progress-indicator">
                        <div class="progress-badge">
                            <p class="progress-number" id="totalCorrectAnswers">${getTotalCorrectAnswers()}</p>
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