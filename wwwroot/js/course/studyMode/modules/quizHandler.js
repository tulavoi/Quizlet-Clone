
const questions = [
    {
        question: "được gửi đến, được chuyển đến",
        answers: [
            { text: "ちょきんします (貯金します)", isCorrect: false },
            { text: "やせます (痩せます)", isCorrect: false },
            { text: "ふとります (太ります)", isCorrect: false },
            { text: "とどきます (届きます)", isCorrect: true },
        ]
    },

    {
        question: "rắc rối, khó xử, có vấn đề",
        answers: [
            { text: "付けます（つけます", isCorrect: false },
            { text: "咲きます（さきます)", isCorrect: false },
            { text: "困ります（こまります)", isCorrect: true },
            { text: "拾います（ひろいます)", isCorrect: false },
        ]
    },

    {
        question: "nở (hoa)",
        answers: [
            { text: "付けます（つけます", isCorrect: false },
            { text: "咲きます（さきます)", isCorrect: true },
            { text: "困ります（こまります)", isCorrect: false },
            { text: "拾います（ひろいます)", isCorrect: false },
        ]
    }
];

let currQuestionIndex = 0;

export function showQuestion() {
    let currQuestion = questions[currQuestionIndex];
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

    if (currQuestionIndex > questions.length) return;
    showQuestion();
}