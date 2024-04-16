var eventId = 2;

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

// This will probably get a response from the server
// fetch(url, requestOptions)
//     .then((response) => response.json())
//     .then((data) => {
//     console.log(data);
//     });

// Fetch API for data
// const data = fetch("https://localhost:7201/api/Event");
// console.log(data);
