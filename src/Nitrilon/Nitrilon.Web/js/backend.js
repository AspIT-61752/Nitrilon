// All variables and DOM element variable
var eventId;
const eventURL = `https://localhost:7201/api/Event/future`;
// const eventURL = `https://localhost:7201/api/Event`; // Get all events
var cardsContainer = document.querySelector("#cardsContainer");
var titleName = document.querySelector("#eventSelection");

var ratingContainer = document.querySelector("#ratingContainer");

var goodRating = document.querySelector("#goodRating");
var midRating = document.querySelector("#midRating");
var badRating = document.querySelector("#badRating");

// Fetches API for data
// fetch("https://localhost:7201/api/Event")

// Fetch API for data
fetch(eventURL)
  .then((response) => response.json()) // Gets the response and converts it to JSON
  .then((data) => {
    // Then converts the data to a JSON object
    console.log(data); // Logs the data to the console, so we're sure it's working

    // For each event in the received data object, we make a card for every event in the data object
    data.forEach((event) => {
      // console.log(event.id); // Logs the event ID to the console

      // Starts with creating the card DOM elements
      var card = document.createElement("div"); // The card itself
      var dateH3 = document.createElement("h3"); // Then the element that holds the date
      var nameH3 = document.createElement("h3"); // Then the element that holds the name of the event
      var desc = document.createElement("p"); // And the element that holds the description of the event
      desc.setAttribute("class", "card-desc"); // Sets the class of the description element

      // The container that holds the name and date of the event
      var divContainer = document.createElement("div");
      divContainer.setAttribute("class", "card-header");
      divContainer.appendChild(nameH3);
      divContainer.appendChild(dateH3);

      // Sets the text content of the elements
      nameH3.textContent = event.name;
      dateH3.textContent = new Date(event.date).toLocaleDateString();
      desc.textContent = event.description;

      // Sets the class of the card and appends the child elements to the container
      card.setAttribute("class", "card");
      card.appendChild(divContainer);
      card.appendChild(desc);

      // Adds an event listener to the card (click event)
      card.addEventListener(
        "click",

        // When the card is clicked, the event ID is set to the ID of the event
        // The title of the event is set to the name of the event so the user knows what event they're rating
        // The cards container is emptied (All the cards are removed)
        // And the ratings "menu" is vissible (The user can rate the event)
        function (e) {
          eventId = event.id;
          titleName.textContent = `Rate ${event.name}`;
          cardsContainer.innerHTML = ""; // Deletes all cards
          ratingContainer.classList.toggle("hide");
        },
        false
      );

      // Appends the card(s) to the cards container
      cardsContainer.appendChild(card);
    });
  });

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
