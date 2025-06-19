
export async function updateLearningProgress(data) {
    //console.log("Sending data:", JSON.stringify(data));
    //return;
    try {
        const response = await fetch('/learning/update-progress', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
        if (!response.ok) {
            const errorData = await response.json();
            console.error("Failed to update progress:", errorData);
        }
    } catch (error) {
        console.error("Error while calling API:", error);
    }
}