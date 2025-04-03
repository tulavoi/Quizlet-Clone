
export async function postData(url, data) {
    try {
        const response = await fetch(url, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });

        if (!response.ok) {
            const errorText = await response.text(); // Lấy nội dung lỗi từ server
            console.error(errorText);
        }
    } catch (error) {
        console.error('Error:', error);
    }
}