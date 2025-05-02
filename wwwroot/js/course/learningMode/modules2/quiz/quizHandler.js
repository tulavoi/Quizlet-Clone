import { getQuestions } from '../questions.js';
import { renderEssayQuestion } from './renderEssay.js';
import { renderMultipleChoiceQuestion } from './renderMultiple.js';
import { attachCharacterButtonsEvent } from './essayEvents.js';
import { } from './multipleEvents.js';

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