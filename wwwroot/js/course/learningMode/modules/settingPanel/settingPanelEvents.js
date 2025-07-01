
import { updateLearningProgress } from '../services/apiHandler.js';
import { getCourseId } from '../quiz/quizState.js';

const btn = document.getElementById("learningModeSetting");
const panel = document.getElementById("settingsPanel");

btn.addEventListener("click", () => {
    panel.classList.toggle("hidden");
});

// Tùy chọn: đóng bảng nếu click ra ngoài
document.addEventListener("click", (e) => {
    if (!btn.contains(e.target) && !panel.contains(e.target)) {
        panel.classList.add("hidden");
    }
});

export function resetQuestions() {
    const multiple = document.querySelector("#multipleQuestion").checked;
    const essay = document.querySelector("#essayQuestion").checked;

    let type =
        multiple && essay ? 0 :     // Both: 0, Multiple: 1, Essay: 2
        multiple ? 1 :
        essay ? 2 :
        0;

    updateLearningProgress({
        courseId: getCourseId(),
        correctAnswerCount: 0,
        currentQuestionIndex: 0,
        correctAnswersPerStep: '',
        questionType: type
    });
    location.reload();
}
window.resetQuestions = resetQuestions;