

export function attachCharacterButtonsEvent() {
    const buttons = document.querySelectorAll('.character-button');
    const input = document.querySelector('.answer-input');

    buttons.forEach(btn => {
        btn.addEventListener('click', () => {
            input.value += btn.textContent;
            input.focus();
        })
    });
}