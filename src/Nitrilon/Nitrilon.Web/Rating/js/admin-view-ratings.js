// TODO: Use this to create a nice looking chart: https://www.chartjs.org/docs/latest/getting-started/
// This might be it: https://www.chartjs.org/docs/latest/charts/doughnut.html OR https://www.chartjs.org/docs/latest/charts/doughnut.html#pie

const eventURL = "https://localhost:7201/api/Event/future";
const getRatingDataURL =
	"https://localhost:7201/api/Event/GetEventRatingDataBy?eventId=";

// const eventURL = `https://localhost:7201/api/Event`;

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
			const container = document.getElementById("data-container");
			container.innerHTML = `<p>Fejl ved hentning af data: ${error.message}</p>`;
		});
}

// Display each event's data in the DOM.
function displayData(data) {
	const container = document.getElementById("data-container");
	container.innerHTML = ""; // Clear previous contents before displaying new data.

	// Create and append a div for each event in the fetched data.
	data.forEach((item) => {
		const dataDiv = document.createElement("div");
		const date = new Date(item.date);

		dataDiv.classList.add("event"); // Add class for potential styling.

		// I use the logical OR operator below to provide a default value if the name or description is not provided.
		// It shouldn't happen, but just in case I get some data that doesn't have a name or description I want to handle it.
		dataDiv.innerHTML = `
            <h2>${item.name || "Intet navn angivet"}</h2>
            <p>Dato: ${date.toDateString()}</p>
            <p>Deltagere: ${item.attendees}</p>
            <p>Beskrivelse: ${item.description || "Ingen beskrivelse givet"}</p>
        `;
		// Add a click event listener to each event div to fetch and display its ratings.
		dataDiv.addEventListener("click", () => fetchRatingData(item.id));
		container.appendChild(dataDiv);
	});
}

// Fetches rating data for a specific event using its ID.
function fetchRatingData(eventId) {
	fetch(getRatingDataURL + `${eventId}`)
		.then((response) => response.json()) // Parse JSON data from the response.
		.then((ratingData) => updateDOMWithRating(ratingData)) // Update the DOM with the rating data.
		.catch((error) =>
			console.error("Fejl ved hentning af rating-data:", error)
		); // Handle potential errors.
}

// Updates the DOM to only show the rating data of a selected event.
function updateDOMWithRating(ratingData) {
	const container = document.getElementById("data-container");
	container.innerHTML = ""; // Clear previous event data to focus on the selected event's ratings.

	// Create and append a div displaying the fetched rating data.
	const ratingDiv = document.createElement("div");
	ratingDiv.innerHTML = `
        <p>Bad Ratings: ${ratingData.badRatingCount}</p>
        <p>Neutral Ratings: ${ratingData.neutralRatingCount}</p>
        <p>Good Ratings: ${ratingData.goodRatingCount}</p>
    `;
	container.appendChild(ratingDiv);
}
