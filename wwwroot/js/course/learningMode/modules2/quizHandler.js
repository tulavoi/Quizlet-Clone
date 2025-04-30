
import { getQuestions } from './questions.js';
const questions = getQuestions();
let currQuestionIndex = 0;

export function renderQuiz() {
    console.log(questions);
    let currQuestion = questions[currQuestionIndex];

    let quizWrapper = document.querySelector('.quiz-wrapper');

    // Thêm quiz-card vào wrapper
    quizWrapper.innerHTML = createQuizCard(currQuestion);
}

function createQuizCard(currQuestion) {
    let answerNo = 1;
    console.log(currQuestion.QuestionType);
    return;
    const answersHtml = currQuestion.Options.map(option => {
        var isCorrect = option.CorrectAnswer == option.text;
        return `
            <div class="quiz-answer" data-correct="${isCorrect}" onclick="checkAnswer(this)">
                <div class="quiz-answer-no">${answerNo++}</div>
                <div class="quiz-answer-text">
                    ${option.text}
                </div>
            </div>
        `;
    }).join("");

    return `
        <article class="quiz-card">
            <div class="quiz-header">
			    <div class="quiz-card-header-top">
				    <div class="quiz-card-title">
					    <span>Định nghĩa</span>
				    </div>
			    </div>

			    <div class="quiz-definition-text">
				    <span>${currQuestion.Question}</span>
			    </div>
		    </div>

            <div class="quiz-answer-section multiple-choice-quiz">
			    <div class="quiz-card-title">
				    <span>Chọn thuật ngữ đúng</span>
			    </div>

			    <div class="quiz-card-answers">
				    ${answersHtml}
			    </div>

			    <div class="quiz-card-help">
				    <i class="fa-regular fa-flag btn-report"></i>

				    <button class="quiz-help-button" onclick="showCorrectAnswer()">Bạn không biết?</button>
			    </div>
		    </div>
        </article>
    `;
}