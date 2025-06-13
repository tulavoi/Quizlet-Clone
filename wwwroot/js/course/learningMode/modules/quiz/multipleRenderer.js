
import { generateQuizHeaderHtml } from './headerGenerator.js';

export function renderMultipleChoiceQuestion(question) {
    const optionsHtml = question.Options.map((option, index) => {
        const isCorrect = question.CorrectOption === option;
        return `
            <div class="quiz-option" data-correct="${isCorrect}" onclick="checkOption(this)">
                <div class="quiz-option-no">${index + 1}</div>
                <div class="quiz-option-text">${option}</div>
            </div>
        `;
    }).join("");

    let headerHtml = generateQuizHeaderHtml(question.Question);

    return `
            <article class="quiz-card">
                ${headerHtml}
                <div class="quiz-section multiple-choice-quiz">
			        <div class="quiz-card-title">
				        <span>Chọn thuật ngữ đúng</span>
			        </div>

			        <div class="quiz-card-options">
				        ${optionsHtml}
			        </div>

			        <div class="quiz-card-help">
				        <i class="fa-regular fa-flag btn-report"></i>

				        <button class="quiz-help-button" onclick="helpButtonClickEvent(this)">Bạn không biết?</button>
			        </div>
		        </div>
            </article>
        `;
}