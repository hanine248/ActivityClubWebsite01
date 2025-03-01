// public/js/home.js

document.addEventListener('DOMContentLoaded', function() {
    // URL of the API endpoint
    const apiUrl = 'https://localhost:7265/api/Event'; // Adjust URL as needed

    // Fetch the events from the API
    fetch(apiUrl)
        .then(response => response.json())
        .then(events => {
            // Get the container where the events will be displayed
            const eventsContainer = document.getElementById('events-container');

            // Create HTML for each event
            events.forEach(event => {
                const eventElement = document.createElement('div');
                eventElement.className = 'event-item';
                eventElement.innerHTML = `
                    <img src="${event.imageUrl}" alt="${event.name}" />
                    <h3>${event.name}</h3>
                    <p>${event.description}</p>
                `;
                eventsContainer.appendChild(eventElement);
            });
        })
        .catch(error => console.error('Error fetching events:', error));
});
