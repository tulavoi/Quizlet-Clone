import { getAllQuestions } from '../questions.js';

const questions = getAllQuestions();
let currQuestionIndex = 0;

export function getCurrentQuestion() {
    return questions[currQuestionIndex];
}

export function nextQuestion() {
    currQuestionIndex++;
}

export function getCurrentQuestionIndex() {
    return currQuestionIndex;
}