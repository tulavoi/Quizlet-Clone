
import { questions, getQuestionsForStep } from './questions.js';
import { showNotificationBar } from './notificationHandler.js';
import { displayProgressOverview, updateProgressbar } from './progressOverview.js';

let currQuestionIndex = 0;
let questionsInStep = [];
let stepIndex = 0;

export function showQuestion() {
    questionsInStep = getQuestionsForStep(stepIndex);

    let currQuestion = questionsInStep[currQuestionIndex];
    let quizContainer = document.querySelector('.quiz-container');

    quizContainer.innerHTML = "";

    // Tạo wrapper có animation
    const wrapper = document.createElement('div');
    wrapper.classList.add('quiz-wrapper', 'slide-in-right');

    // Thêm quiz-card vào wrapper
    wrapper.innerHTML = createQuizCard(currQuestion);

    // Thêm wrapper vào container
    quizContainer.appendChild(wrapper);
}

function createQuizCard(currQuestion) {
    let answerNo = 1;

    const answersHtml = currQuestion.answers.map(answer => {
        return `
            <div class="quiz-answer" data-correct="${answer.isCorrect}" onclick="checkAnswer(this)">
                <div class="quiz-answer-no">${answerNo++}</div>
                <div class="quiz-answer-text">
                    ${answer.text}
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
				    <span>${currQuestion.question}</span>
			    </div>
		    </div>

            <div class="quiz-answer-section multiple-choice-quiz">
			    <div class="quiz-card-title">
				    <span>Chọn thuật ngữ đúng</span>
			    </div>

			    <div class="quiz-card-answers">
				    ${answersHtml }
			    </div>

			    <div class="quiz-card-help">
				    <i class="fa-regular fa-flag btn-report"></i>

				    <button class="quiz-help-button" onclick="showCorrectAnswer()">Bạn không biết?</button>
			    </div>
		    </div>
        </article>
    `;
}

// Thực hiện chuyển sang câu hỏi tiếp theo
export function nextQuestion() {
    currQuestionIndex += 1;
    if (currQuestionIndex > questionsInStep.length - 1) {
        const correctAnswer = parseInt(document.querySelector('#learnProgress .progress-number').textContent, 10);
        console.log(correctAnswer);
        displayProgressOverview();
        updateProgressbar(correctAnswer);
        showNotificationBar();
    } else showQuestion();
}