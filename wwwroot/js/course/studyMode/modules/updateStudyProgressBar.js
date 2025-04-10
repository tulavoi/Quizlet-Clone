
export function updateStudyProgressBar(correctAnswer, pendingAswner ,totalAnswers){
    const correctBar = document.querySelector('.progress-bar-correct');
    const pendingBar = document.querySelector('.progress-bar-pending');

    const correctPercent = (correctAnswer / totalAnswers) * 100;
    const pendingPercent = ((correctAnswer + pendingAswner) / totalAnswers) * 100;

    correctBar.style.width = correctPercent > 0 ? `${correctPercent}%` : '1%';
    pendingBar.style.width = `${pendingPercent}%`;
}