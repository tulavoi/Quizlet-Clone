
import { resetQuestionsLearnedInStep } from '../../quiz/questionsInStep.js';
import { getQuestionsLearnedInStep } from '../../quiz/questionsInStep.js';
import { } from '../../../../detail/modules/flashcardAction.js'; // import để thực hiện chức năng text to speech
import { updateStarredButtonsColor } from '../../../../detail/modules/starredFlashcard.js'; // import để thực hiện chức năng text to speech

import {
    updateProgressIndicator,
    calculatePercentage,
    updateProgressStep,
} from '../learningProgress/progressUpdater.js';

import {
    getTotalCorrectAnswers,
    getTotalQuestionCount,
} from '../../quiz/quizState.js';

export function updateProgress(progress) {
    const progressIndicator = progress.querySelector('.progress-indicator');
    const progressNumber = progress.querySelector('#totalCorrectAnswers');
    const progressStep = progress.querySelector('.progress-step');

    const percentage = calculatePercentage(getTotalCorrectAnswers(), getTotalQuestionCount());
    updateOverviewProgressValue(percentage);

    setTimeout(() => {
        updateProgressIndicator(progressIndicator, progressNumber, percentage);
        updateProgressStep(progressStep, percentage);
    }, 1000);

    updateFlashcardsLearnedInStep();
}

function updateOverviewProgressValue(percentage) {
    const progressPercentage = document.querySelector('.progress-percentage');
    progressPercentage.textContent = percentage + "%";
}

function updateFlashcardsLearnedInStep() {
    const container = document.querySelector('#flashcardsLearnedInStep');
    container.innerHTML = '';

    const questions = getQuestionsLearnedInStep();
    console.log(questions);
    questions.forEach(question => {
        const flashcard = document.createElement('div');

        flashcard.className = 'flashcard-item';
        flashcard.innerHTML = `
            <div class="flashcard-content">
                <div class="t1xa5rl1">
                    <div class="term-label">${question.Flashcard.Term ?? "..."}</div>
                    <div class="definition-label">${question.Flashcard.Definition ?? "..."}</div>
                </div>
                <div class="flashcard-actions">
                    <button class="starred-btn" title="Gắn sao"
                            data-is-starred="${question.Flashcard.IsStarred}"
                            data-flashcard-id="${question.Flashcard.Id}"
                            onclick="starredFlashcard(this)">
                        <i class="fa-solid fa-star"></i>
                    </button>
                    <button class="audio-btn" title="Phát âm"
                            onclick="textToSpeech('${question.Flashcard.Term ?? ""}', '${question.Flashcard.TermLanguageCode}')">
                        <i class="fa-solid fa-volume-high text-secondary"></i>
                    </button>
                </div>
            </div>
        `;
        container.appendChild(flashcard);
    });
    updateStarredButtonsColor();
    resetQuestionsLearnedInStep(); // Reset lại array chứa các câu hỏi đã học trong step
}
