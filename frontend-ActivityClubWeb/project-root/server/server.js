const express = require('express');
const path = require('path');

const app = express();

// Serve static files from the "public" directory
app.use(express.static(path.join(__dirname, 'public')));

// Define routes for your views
app.get('/', (req, res) => {
    res.sendFile(path.join(__dirname, 'views/public/home.html'));
});

// Other routes as needed
app.get('/login', (req, res) => {
    res.sendFile(path.join(__dirname, 'views/public/login.html'));
});

app.get('/contact-us', (req, res) => {
    res.sendFile(path.join(__dirname, 'views/public/contact-us.html'));
});

app.listen(8080, () => {
    console.log('Server is running on http://localhost:8080');
});
