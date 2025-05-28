
import { getQuestionsLearnedInStep, resetQuestionsLearnedInStep } from '../../questions.js';
import { } from '../../../../detail/modules/flashcardAction.js'; // import để thực hiện chức năng text to speech
import { QUESTION_TYPE } from '../../quiz/quizHandler.js';
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

    const learnedQuestions = getQuestionsLearnedInStep();
    learnedQuestions.forEach(question => {
        let term = question.QuestionType == QUESTION_TYPE.ESSAY ? question.CorrectAnswer : question.CorrectOption;
        let definition = question.Question;
        const flashcard = document.createElement('div');

        flashcard.className = 'flashcard-item';
        flashcard.innerHTML = `
            <div class="flashcard-content">
                <div class="t1xa5rl1">
                    <div class="term-label">${term}</div>
                    <div class="definition-label">${definition}</div>
                </div>
                <div class="flashcard-actions">
                    <button class="starred-btn" title="Gắn sao"
                            data-is-starred="false"
                            data-flashcard-id="0"
                            onclick="starredFlashcard(this)">
                        <i class="fa-solid fa-star"></i>
                    </button>
                    <button class="audio-btn" title="Phát âm"
                            onclick="textToSpeech('${term}', 'JA')">
                        <i class="fa-solid fa-volume-high text-secondary"></i>
                    </button>
                </div>
            </div>
        `;
        container.appendChild(flashcard);
    });

    resetQuestionsLearnedInStep(); // Reset lại array chứa các câu hỏi đã học trong step
}
