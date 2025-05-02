
import { generateQuizHeaderHtml } from './headerGenerator.js';

export function renderEssayQuestion(question) {
    let headerHtml = generateQuizHeaderHtml(question.Question, 'quiz-header-height');

    const characterButtons = question.CharacterBank.map(char => {
        return `
            <span class="character-button-wrapper">
				<button class="character-button">${char}</button>
			</span>
        `;
    }).join("");

    let essayQuiz = `
            <article class="quiz-card">
                ${headerHtml}
                <div class="quiz-section essay-quiz">
				    <div class="quiz-card-title">
					    <span>Đáp án của bạn</span>
				    </div>

                    <div class="character-bank-container">
				        ${characterButtons}
                    </div>

				    <div class="">
					    <input type="text" class="answer-input" autocomplete="off" spellcheck="false" placeholder="Nhập đáp án" />
				    </div>

				    <div class="quiz-card-help">
					    <button class="quiz-help-button">Bạn không biết?</button>
					    <button class="quiz-answer-button">Trả lời</button>
				    </div>
			    </div>
            </article>
        `;
    return essayQuiz;
}