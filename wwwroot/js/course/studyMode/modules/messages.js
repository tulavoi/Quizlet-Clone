export const correctMessages = [
    "Xuất sắc!",
    "Tuyệt vời!",
    "Rất tốt, bạn đã trả lời đúng!",
    "Bạn sẽ làm được!",
    "Bạn đang làm rất tuyệt",
    "Làm tốt lắm!"
];

export const incorrectMessages = [
    "Đừng lo, bạn vẫn đang học mà!",
    "Chưa đúng, hãy cố gắng nhé!",
    "Đừng nản chí, học là một quá trình!"
];

export function getMessage(messages) {
    var randomIndex = Math.floor(Math.random() * messages.length);
    return messages[randomIndex];
}