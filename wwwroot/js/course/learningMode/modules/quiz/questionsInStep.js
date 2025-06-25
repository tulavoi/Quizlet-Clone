import { getAllQuestions } from '../questions.js';
import {
    getStepIndex,
    getStepSize,
} from './quizState.js';

let questionsLearnedInStep = [];

export function addLearnedQuestions() {
    const allQuestions = getAllQuestions();
    const stepSizes = getStepSize();
    const stepIndex = getStepIndex();

    // Tính toán index bắt đầu của các câu hỏi trong step hiện tại
    let startIndex = 0;
    for (let i = 0; i < stepIndex; i++) {
        startIndex += stepSizes[i]; // Cộng dồn số câu hỏi của các step trước
    }

    // Tính toán chỉ số kết thúc: start + số câu trong step hiện tại
    const endIndex = startIndex + stepSizes[stepIndex];

    // Cắt ra mảng câu hỏi tương ứng với step hiện tại và gán vào questionsLearnedInStep
    questionsLearnedInStep = allQuestions.slice(startIndex, endIndex);
}

export function resetQuestionsLearnedInStep() {
    questionsLearnedInStep = [];
}

export function getQuestionsLearnedInStep() {
    return questionsLearnedInStep;
}