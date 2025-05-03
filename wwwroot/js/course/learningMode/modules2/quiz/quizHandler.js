import { getCurrentQuestion, nextQuestion } from './quizState.js';
import { renderEssayQuestion } from './renderEssay.js';
import { renderMultipleChoiceQuestion } from './renderMultiple.js';
import { attachCharacterButtonsEvent } from './essayEvents.js';
import { } from './multipleEvents.js';
import { } from './quizHelp.js';

const QUESTION_TYPE = {
    MULTIPLE: "Multiple",
    ESSAY: "Essay"
};

export function renderQuiz() {
    const question = getCurrentQuestion();
    let quizContainer = document.querySelector('.quiz-container');
    quizContainer.innerHTML = "";

    // Tạo wrapper có animation
    const quizWrapper = document.createElement('div');
    quizWrapper.classList.add('quiz-wrapper', 'slide-in-right');

    // Gán nội dung câu hỏi
    const isEssay = question.QuestionType === QUESTION_TYPE.ESSAY;
    let content = isEssay
            ? renderEssayQuestion(question)
            : renderMultipleChoiceQuestion(question);

    quizWrapper.innerHTML = content;
    quizContainer.appendChild(quizWrapper);

    // Gắn event nếu là câu hỏi tự luận
    if (isEssay) {
        attachCharacterButtonsEvent();
    }
}

export function nextQuiz() {
    nextQuestion();
    renderQuiz();
}