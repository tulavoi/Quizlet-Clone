
let proressOverview = document.querySelector('#progressOverview');

export function renderOverviewProgress() {
    displayOverviewProgress();
}

export function hideOverviewProgress() {
    document.querySelector('.progress-overview-container').classList.add('d-none');
    document.querySelector('.flashcard-section').classList.add('d-none');
}

export function displayOverviewProgress() {
    const progress = document.querySelector('.progress-overview-container');
    const flashcardsSection = progress.querySelector('.flashcard-section');

    progress.classList.remove('d-none');

    setTimeout(() => {
        flashcardsSection.classList.remove('d-none');
    }, 300);
}

