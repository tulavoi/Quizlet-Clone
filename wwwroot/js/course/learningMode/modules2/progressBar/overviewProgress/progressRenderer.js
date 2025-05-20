
let proressOverview = document.querySelector('#progressOverview');

export function renderOverviewProgress() {
    displayOverviewProgress();
}

export function hideOverviewProgress() {
    document.querySelector('.progress-overview-container').classList.add('d-none');
}

export function displayOverviewProgress() {
    document.querySelector('.progress-overview-container').classList.remove('d-none');
}

