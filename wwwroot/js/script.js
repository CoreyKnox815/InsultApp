document.getElementById('generate-insult').addEventListener('click', () => {
    const name = document.getElementById('insult-type').value;
    console.log('Button clicked, name:', name); // Debugging log

    fetch(`http://localhost:5248/Insult/Random?name=${encodeURIComponent(name)}`)
        .then(response => {
            console.log('Fetch response:', response); // Debugging log
            if (!response.ok) {
                throw new Error(`Network response was not ok: ${response.statusText}`);
            }
            return response.json();
        })
        .then(data => {
            console.log('JSON data:', data); // Debugging log
            document.getElementById('insult').innerText = data.insult; // Use "insult" to match the JSON property name
        })
        .catch(error => {
            console.error('Fetch error:', error);
            document.getElementById('insult').innerText = 'Failed to fetch an insult. Please try again later.';
        });
});
