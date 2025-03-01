// login.js
document.getElementById('loginForm').addEventListener('submit', async function(event) {
    event.preventDefault();
    
    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;
    
    try {
        const response = await fetch('/api/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ email, password })
        });

        const result = await response.json();

        if (response.ok) {
            // Redirect to dashboard or another page on successful login
            window.location.href = '/dashboard';
        } else {
            // Display error message
            document.getElementById('loginError').innerText = result.message;
        }
    } catch (error) {
        console.error('Error:', error);
        document.getElementById('loginError').innerText = 'An error occurred. Please try again.';
    }
});
