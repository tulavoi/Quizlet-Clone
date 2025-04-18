
// Cập nhật giao diện câu hỏi khi user chọn đúng đáp án
export function updateQuizUI(isCorrect, selectedAnswer) {
    const answers = document.querySelectorAll('.quiz-answer');
    const helpBtn = document.querySelector('.quiz-help-button');

    // Tìm đáp án đúng nếu như đã chọn đáp án sai
    let correctAnswer = isCorrect ? null : findCorrectAnswer(answers);

    // Vô hiệu hóa các đáp án và help btn, trừ đáp án đúng
    disableAnswers(answers, selectedAnswer, isCorrect);
    disableHelpButon(helpBtn);

    // Nếu chọn sai, highlight đáp án đúng
    if (!isCorrect && correctAnswer) highlightCorrectAnswer(correctAnswer);

    updateQuizTitle(isCorrect);
}

function highlightCorrectAnswer(correctAnswer) {
    correctAnswer.classList.remove('is-disabled');
    correctAnswer.classList.add('is-correct-2');
}

function updateQuizTitle(isCorrect) {
    // Cập nhật tiêu đề và đổi màu chữ dựa vào câu hỏi đúng hay sai
    const quizCardTitle = document.querySelector('.quiz-answer-section .quiz-card-title span');
    if (quizCardTitle) {
        quizCardTitle.textContent = isCorrect ? "Xuất sắc!" : "Đừng lo, bạn vẫn đang học mà!";
        quizCardTitle.style.color = isCorrect ? "var(--green-deep)" : "var(--orange-deep)";
    }
}

function disableHelpButon(helpBtn) {
    helpBtn?.classList.add('is-disabled');
}

function disableAnswers(answers, selectedAnswer, isCorrect) {
    answers.forEach(answer => {
        if (answer === selectedAnswer) {
            answer.classList.add(isCorrect ? 'is-correct' : 'is-incorrect');
        } else {
            answer.classList.add('is-disabled');
        }
    });
}

function findCorrectAnswer(answers) {
    return Array.from(answers).find(answer =>
        answer.dataset.correct === 'true'
    );
}