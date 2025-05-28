
const allQuestions = window.allQuestions;
let questionsLearnedInStep = [];

export function getAllQuestions() {
    return allQuestions;
}

export function saveQuestionsLearnedInStep(question) {
    if (!question) return;
    questionsLearnedInStep.push(question);
}

export function resetQuestionsLearnedInStep() {
    questionsLearnedInStep = [];
}

export function getQuestionsLearnedInStep() {
    return questionsLearnedInStep;
}