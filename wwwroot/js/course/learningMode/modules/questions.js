
const allQuestions = window.quizData.allQuestions;

let questionsLearnedInStep = [];

export function getAllQuestions() {
    console.log(allQuestions);
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