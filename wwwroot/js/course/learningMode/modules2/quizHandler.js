
import { getQuestions } from './questions.js';
const questions = getQuestions();
let currQuestionIndex = 0;

const QUESTION_TYPE = {
    MULTIPLE: "Multiple",
    ESSAY: "Essay"
};

export function renderQuiz() {
    const question = questions[currQuestionIndex];
    const quizWrapper = document.querySelector('.quiz-wrapper');

    if (question.QuestionType === QUESTION_TYPE.ESSAY) {
        quizWrapper.innerHTML = renderEssayQuestion(question);
        attachCharacterButtonsEvent();
    } else {
        quizWrapper.innerHTML = renderMultipleChoiceQuestion(question);
    }
}

function renderEssayQuestion(question) {
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
                <div class="quiz-answer-section essay-quiz">
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
    attachCharacterButtonsEvent();
    return essayQuiz;
}

function attachCharacterButtonsEvent() {
    const buttons = document.querySelectorAll('.character-button');
    const input = document.querySelector('.answer-input');

    buttons.forEach(btn => {
        btn.addEventListener('click', () => {
            input.value += btn.textContent;
            input.focus();
        })
    });
}

function renderMultipleChoiceQuestion(question) {
    const optionsHtml = question.Options.map((option, index) => {
        const isCorrect = question.CorrectAnswer === option;
        return `
            <div class="quiz-answer" data-correct="${isCorrect}" onclick="checkAnswer(this)">
                <div class="quiz-answer-no">${index + 1}</div>
                <div class="quiz-answer-text">${option}</div>
            </div>
        `;
    }).join("");

    let headerHtml = generateQuizHeaderHtml(question.Question);

    return `
            <article class="quiz-card">
                ${headerHtml}
                <div class="quiz-answer-section multiple-choice-quiz">
			        <div class="quiz-card-title">
				        <span>Chọn thuật ngữ đúng</span>
			        </div>

			        <div class="quiz-card-answers">
				        ${optionsHtml}
			        </div>

			        <div class="quiz-card-help">
				        <i class="fa-regular fa-flag btn-report"></i>

				        <button class="quiz-help-button" onclick="showCorrectAnswer()">Bạn không biết?</button>
			        </div>
		        </div>
            </article>
        `;
}

export function generateQuizHeaderHtml(questionText, additionalClass = '') {
    return `
        <div class="quiz-header ${additionalClass}">
            <div class="quiz-card-header-top">
                <div class="quiz-card-title">
                    <span>Định nghĩa</span>
                </div>
            </div>
            <div class="quiz-definition-text">
                <span>${questionText}</span>
            </div>
        </div>
    `;
}