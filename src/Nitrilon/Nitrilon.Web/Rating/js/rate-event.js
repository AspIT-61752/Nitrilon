var eventId = -1;
const eventURL = "https://localhost:7201/api/Event/future";

var ratingContainer = document.querySelector("#ratingContainer");

var goodRating = document.querySelector("#goodRating");
var midRating = document.querySelector("#midRating");
var badRating = document.querySelector("#badRating");

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

  // Posts a rating to the DB (1 => bad; 2 => average; 3 => good)
  // A good rating
  goodRating.addEventListener("click", function (OnClick) {
    OnClick.preventDefault(); // Prevents default event propagation
    sendToServer(3); // Send rating to backend
  });

  // A mid rating
  midRating.addEventListener("click", function (OnClick) {
    OnClick.preventDefault(); // Prevents default event propagation
    sendToServer(2); // Send rating to backend
  });

  // A bad rating
  badRating.addEventListener("click", function (OnClick) {
    OnClick.preventDefault(); // Prevents default event propagation
    sendToServer(1); // Send rating to backend
  });
}

// POST a rating
function sendToServer(rating) {
  // URL parameters
  let url = `https://localhost:7201/api/EventRatings?eventId=${eventId}&ratingId=${rating}`;

  // Request options
  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
  };

  // Check if it's a number
  if (isNaN(rating)) {
    console.log("Not a number");
    return;
  } else {
    // If is a number, check if it's an integer
    if (!Number.isInteger(rating)) {
      console.log("Not an integer"); // If it's not an integer, return
      return;
    } else {
      // console.log("Rating is a number");
      // If it's a number, send to API endpoint
      fetch(url, requestOptions)
        .then((response) => {
          // If the response is OK, log to the console
          if (response.ok) {
            console.log("Rating sent to server");
          } else {
            console.log("Rating not sent to server");
          }
        })
        .then((data) => {
          //   console.log(data); // This returns an undefined object.
        })
        .catch((err) => {
          console.log("Error: ", err);
        });
    }
  }
}
