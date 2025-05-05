import { getQuestions } from '../questions.js';

const questions = getQuestions();
let currQuestionIndex = 0;

export function getCurrentQuestion() {
    return questions[currQuestionIndex];
}

export function nextQuestion() {
    currQuestionIndex++;
}

export function getCurrentIndex() {
    return currQuestionIndex;
}