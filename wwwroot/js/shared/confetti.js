
// Bắn pháo bông
export function triggerConfetti() {
    confetti({
        particleCount: 100,                                 // Số hạt pháo bông
        angle: 90,                                          // Góc bắn 90 độ
        spread: 360,                                        // Độ lan tỏa (360: bung toàn diện)
        startVelocity: 45,                                  // Tốc độ bắn ban đầu
        origin: { x: 0.5, y: 0.5 },                         // Vị trí giữa screen
        colors: ['#ff0', '#ff6347', '#87ceeb', '#32cd32'],  // Màu sắc pháo bông
    });
}