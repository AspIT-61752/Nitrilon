var eventId = -1;
const eventURL = "https://localhost:7201/api/Event/future";

// Add an event listener that triggers when the DOM content is fully loaded.
document.addEventListener("DOMContentLoaded", function () {
  fetchData(); // Fetch initial event data from the API when the page loads.
});

// Fetches event data from the API.
function fetchData() {
  fetch(eventURL)
    .then((response) => {
      // Check if the HTTP response status is 'OK' (status code 200). If not, throw an error.
      if (!response.ok) {
        throw new Error("Netværksresponsen var ikke ok");
      }
      return response.json(); // Parse JSON data from the response body.
    })
    .then((data) => displayData(data)) // Handle the parsed data.
    .catch((error) => {
      // Log and display errors if the fetch operation fails.
      console.error("Fejl ved hentning af data:", error);
      const container = document.getElementById("card-container");
      container.innerHTML = `<p>Fejl ved hentning af data: ${error.message}</p>`;
    });
}

// Display each event's data in the DOM.
function displayData(data) {
  const container = document.getElementById("card-container");
  container.innerHTML = ""; // Clear previous contents before displaying new data.

  // Create and append a div for each event in the fetched data.
  data.forEach((item) => {
    const dataDiv = document.createElement("div");
    const date = new Date(item.date);
    dataDiv.classList.add("event"); // Add class for potential styling.
    dataDiv.innerHTML = `
            <h2>${item.name || "Intet navn angivet"}</h2>
            <p>Dato: ${date.toDateString()}</p>
            <p>Deltagere: ${item.attendees}</p>
            <p>Beskrivelse: ${item.description || "Ingen beskrivelse givet"}</p>
        `;
    // Add a click event listener to each event div to fetch and display its ratings.
    dataDiv.addEventListener("click", () => getRatingMenu(item));
    container.appendChild(dataDiv);
  });
}

// getRatingMenu(item.id)
function getRatingMenu(event) {
  // Set the event ID to the ID of the event
  // Set the title of the event to the name of the event so the user knows what event they're rating
  // Empty the cards container (All the cards are removed)
  // Make the ratings "menu" visible (The user can rate the event)

  let ratingContainer = document.getElementById("rating-container");
  let eventTitle = document.getElementById("event-selection");
  let container = document.getElementById("card-container");

  eventId = event.id;
  eventTitle.textContent = `Hvad syntes du om ${event.name}`;
  container.innerHTML = ""; // Deletes all cards
  ratingContainer.classList.toggle("hide");

  // TODO: Write the button functionality and add them to the smileys
}
