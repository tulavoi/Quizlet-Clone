
export function generateQuizHeaderHtml(questionText, additionalClass = '') {
    return `
        <div class="quiz-header ${additionalClass}">
            <div class="quiz-card-header-top">
                <div class="quiz-card-title">
                    <span>Định nghĩa</span>
                </div>
            </div>
            <div class="quiz-definition-text">
                <span>${questionText}</span>
            </div>
        </div>
    `;
}