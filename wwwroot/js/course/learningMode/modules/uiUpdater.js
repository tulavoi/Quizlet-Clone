import { enableCorrectAnswerForNext } from './answerHandler.js';
import { correctMessages, incorrectMessages, getMessage } from './messages.js';

// Cập nhật giao diện câu hỏi khi user chọn đúng đáp án
export function updateQuizUI(isCorrect, selectedAnswer) {
    const answers = document.querySelectorAll('.quiz-answer');

    // Tìm đáp án đúng nếu như đã chọn đáp án sai
    let correctAnswer = isCorrect ? null : findCorrectAnswer(answers);

    // Vô hiệu hóa các đáp án khác và đánh dấu đáp án đã chọn
    markAnswers(answers, selectedAnswer, isCorrect);
    disableHelpButon();

    // Nếu chọn sai, highlight đáp án đúng
    if (!isCorrect && correctAnswer) highlightCorrectAnswer(correctAnswer);

    updateQuizTitle(isCorrect);

    enableCorrectAnswerForNext(correctAnswer);
}

function highlightCorrectAnswer(correctAnswer) {
    correctAnswer.classList.remove('is-disabled');
    correctAnswer.classList.add('is-correct-2');
}

// Cập nhật tiêu đề của quiz theo kết quả
function updateQuizTitle(isCorrect) {
    const quizCardTitle = document.querySelector('.quiz-answer-section .quiz-card-title span');
    if (quizCardTitle) {
        quizCardTitle.textContent = isCorrect ? getMessage(correctMessages) : getMessage(incorrectMessages);
        quizCardTitle.style.color = isCorrect ? "var(--green-deep)" : "var(--orange-deep)";
    }
}

function disableHelpButon() {
    const helpBtn = document.querySelector('.quiz-help-button');
    helpBtn?.classList.add('is-disabled');
}

export function markAnswers(answers, selectedAnswer, isCorrect = false, skipMarking = false) {
    answers.forEach(answer => {
        if (answer === selectedAnswer) {
            // Chỉ thêm class nếu không bỏ qua việc đánh dấu đúng/sai
            if (!skipMarking) answer.classList.add(isCorrect ? 'is-correct' : 'is-incorrect');
        } else {
            // Vô hiệu hóa các đáp án còn lại
            answer.classList.add('is-disabled');
        }
    });
}

export function findCorrectAnswer(answers) {
    return Array.from(answers).find(answer =>
        answer.dataset.correct === 'true'
    );
}