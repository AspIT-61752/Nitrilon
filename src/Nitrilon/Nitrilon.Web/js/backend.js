var eventId;
const eventURL = `https://localhost:7201/api/Event/future`;
// const eventURL = `https://localhost:7201/api/Event`; // Get all events
var cardsContainer = document.querySelector("#cardsContainer");
var titleName = document.querySelector("#eventSelection");

var goodRating = document.querySelector("#goodRating");
var midRating = document.querySelector("#midRating");
var badRating = document.querySelector("#badRating");

/*
goodRating.addEventListener("click", function () {
  console.log("Good rating");
  // Fetch API for data
  fetch("https://localhost:7201/api/Event")
    .then((response) => response.json())
    .then((data) => {
      console.log(data);
    });
});*/

// Fetches API for data
// fetch("https://localhost:7201/api/Event")

// Fetch API for data
fetch(eventURL)
  .then((response) => response.json())
  .then((data) => {
    console.log(data);
    data.forEach((event) => {
      console.log(event.id);
      var card = document.createElement("div");
      // var idH3 = document.createElement("h3"); // Not relevant
      var dateH3 = document.createElement("h3");
      var nameH3 = document.createElement("h3");
      var desc = document.createElement("p");
      desc.setAttribute("class", "card-desc");

      var divContainer = document.createElement("div");
      divContainer.setAttribute("class", "card-header");
      divContainer.appendChild(nameH3);
      divContainer.appendChild(dateH3);

      nameH3.textContent = event.name;
      dateH3.textContent = new Date(event.date).toLocaleDateString();
      desc.textContent = event.description;

      // idH3.textContent = event.id; // Not relevant
      // idH3.innerHTML = ""; // Deletes HTML elements

      card.setAttribute("class", "card");
      // card.appendChild(idH3); // Not relevant
      // card.appendChild(nameH3);
      card.appendChild(divContainer);
      card.appendChild(desc);
      // card.appendChild(dateH3);\

      // idH3.innerText = event.id;

      card.addEventListener(
        "click",
        function (e) {
          // console.log(event);
          eventId = event.id;
          console.log(event.name);
          titleName.textContent = `Rate ${event.name}`;
          // console.log(event.id);
          // console.log("eventId: " + eventId);
          cardsContainer.innerHTML = ""; // Deletes all cards
        },
        false
      );

      cardsContainer.appendChild(card);
    });
  });
// for each event in data

// Create a card for each event

// Posts a rating to the DB
// A good rating
goodRating.addEventListener("click", function (OnClick) {
  OnClick.preventDefault(); // Prevents default event propagation
  sendToServer(1); // Send rating to server
});

// A mid rating
midRating.addEventListener("click", function (OnClick) {
  OnClick.preventDefault(); // Prevents default event propagation
  sendToServer(2); // Send rating to server
});

// A bad rating
badRating.addEventListener("click", function (OnClick) {
  OnClick.preventDefault(); // Prevents default event propagation
  sendToServer(3); // Send rating to server
});

function sendToServer(rating) {
  // let url = "http://localhost";
  // let url = `http://localhost${eventId}`;
  let url = `https://localhost:7201/api/EventRatings?eventId=${eventId}&ratingId=${rating}`;

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
    if (!Number.isInteger(rating)) {
      console.log("Not an integer");
      return;
    } else {
      console.log("Rating is a number");
      // If it's a number, send to API endpoint
      fetch(url, requestOptions)
        .then((response) => {
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
