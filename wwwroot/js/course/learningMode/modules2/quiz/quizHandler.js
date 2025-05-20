import { getCurrentQuestion, nextQuestion, getCurrentQuestionIndex } from './quizState.js';
import { renderEssayQuestion } from './essayRenderer.js';
import { renderMultipleChoiceQuestion } from './multipleRenderer.js';
import { attachCharacterButtonsEvent, attachInputAnswerEvent } from './essayEvents.js';
import { } from './multipleEvents.js';
import { } from './quizHelp.js';
import { resetIncorrectState } from '../progressBar/learningProgress/progressUpdater.js';
import { renderUI } from '../uiHandler.js';

const QUESTION_TYPE = {
    MULTIPLE: "Multiple",
    ESSAY: "Essay"
};

export function renderQuiz() {
    const currQuestion = getCurrentQuestion();
    let quizContainer = document.querySelector('.quiz-container');
    quizContainer.innerHTML = "";

    // Tạo wrapper có animation
    const quizWrapper = document.createElement('div');
    quizWrapper.classList.add('quiz-wrapper', 'slide-in-right');

    // Gán nội dung câu hỏi
    const isEssay = currQuestion.QuestionType === QUESTION_TYPE.ESSAY;
    let content = isEssay
            ? renderEssayQuestion(currQuestion)
            : renderMultipleChoiceQuestion(currQuestion);

    quizWrapper.innerHTML = content;
    quizContainer.appendChild(quizWrapper);

    // Gắn event nếu là câu hỏi tự luận
    if (isEssay) {
        attachCharacterButtonsEvent();
        attachInputAnswerEvent();
    }
}

export function nextQuiz() {
    nextQuestion();
    renderUI(); // gọi renderUI sẽ gây ra lỗi số câu đúng bị reset = 0
    //renderQuiz();
    resetIncorrectState();
}

export function displayQuizContainer() {
    document.querySelector('.quiz-container').classList.remove('d-none');
}

export function hideQuizContainer() {
    document.querySelector('.quiz-container').classList.add('d-none');
}