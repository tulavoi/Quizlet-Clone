﻿
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

    return `
            <article class="quiz-card">
                ${headerHtml}
                <div class="quiz-section essay-quiz" data-correct-answer="${question.CorrectAnswer}">
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
					    <div class="suggestion-container">
							<button class="suggestion-button" onclick="displaySuggestion()">Hiển thị gợi ý</button>
						</div>

					    <button class="quiz-help-button" onclick="helpButtonClickEvent(this)">Bạn không biết?</button>
					    <button class="quiz-answer-button" onclick="checkAnswer()">Trả lời</button>
				    </div>
			    </div>
            </article>
        `;
}