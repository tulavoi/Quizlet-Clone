
export function checkAnswer(selectedOption) {
    const isCorrect = selectedOption.dataset.correct === 'true';
    const options = document.querySelectorAll('.quiz-option');

    updateOptionState(selectedOption, options);
}
window.checkAnswer = checkAnswer;

function updateOptionState(selectedOption, options) {
    options.forEach(option => {
        option.onclick = null;

        const isCorrect = option.dataset.correct === 'true';

        if (option === selectedOption) {
            option.classList.add(isCorrect ? 'is-correct' : 'is-incorrect');
        }
        else if (isCorrect){
            hightlightCorrectAnswer(option);
        }
        else {
            option.classList.add('is-disabled');
        }
    });
}

function hightlightCorrectAnswer(option) {
    option.classList.add('is-correct-2');
    option.classList.add('clickable');

    option.addEventListener('click', () => {
        console.log('next question');
    });
}