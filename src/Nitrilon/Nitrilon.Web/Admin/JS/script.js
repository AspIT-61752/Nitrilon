const memberURL = "https://localhost:7201/api/Member";

fetch(memberURL)
	.then((response) => response.json())
	.then((data) => {
		// Get the <section> element
		let memberList = document.querySelector("#memberList");

		// Loop through the events and create <li> elements
		data.forEach((Member) => {
			let li = document.createElement("li");
			let Name = document.createElement("h2");
			let MembershipStatus = document.createElement("p");
			let CreationDate = document.createElement("p");
			let PhoneNumb = document.createElement("p");
			let EmailText = document.createElement("p");
			let buttonContainer = document.createElement("div");
			let del = document.createElement("button");
			let edit = document.createElement("button");

			console.log(Member);

			Name.textContent = Member.fullName;

			if (Member.membership.membershipId == 2) {
				MembershipStatus.textContent = "Aktiv";
			} else if (Member.membership.membershipId == 1) {
				MembershipStatus.textContent = "Passiv";
			}

			let date = Member.joinDate.split("T")[0];
			CreationDate.textContent = date;
			CreationDate.id = "date";

			PhoneNumb.textContent = Member.phoneNumber;
			EmailText.textContent = Member.email;
			EmailText.id = "email";

			del.textContent = "Fjern";
			del.id = "delete";

			del.addEventListener("click", function () {
				// Display confirmation pop-up
				if (confirm("Er du sikker på at du vil fjerne dette medlem?")) {
					console.log(Member);
					console.log(JSON.stringify(Member.memberId));
					fetch(memberURL + `?id=${Member.memberId}`, {
						method: "DELETE",
						headers: {
							"Content-Type": "application/json",
						},
					});

					// Remove the member from the list
					li.remove();
				}
			});

			edit.textContent = "Rediger";
			edit.id = "edit";
			edit.addEventListener("click", function () {
				// Create a modal element
				let modal = document.createElement("div");
				modal.classList.add("modal");

				// Create form elements for editing member data
				let form = document.createElement("form");

				// Create input elements for editing member data
				let nameLabel = document.createElement("label");
				nameLabel.textContent = "Navn:";
				let nameInput = document.createElement("input");
				nameInput.type = "text";
				nameInput.value = Member.fullName;

				let membershipLabel = document.createElement("label");
				membershipLabel.textContent = "Medlemskab:";
				let membershipSelect = document.createElement("select");
				let activeOption = document.createElement("option");
				activeOption.value = 2;
				activeOption.textContent = "Aktiv";
				let passiveOption = document.createElement("option");
				passiveOption.value = 1;
				passiveOption.textContent = "Passiv";
				membershipSelect.appendChild(activeOption);
				membershipSelect.appendChild(passiveOption);
				membershipSelect.value = Member.membership.membershipId;

				let joinDateLabel = document.createElement("label");
				joinDateLabel.textContent = "Oprettelsesdato:";
				let joinDateInput = document.createElement("input");
				joinDateInput.type = "date";
				joinDateInput.value = Member.joinDate.split("T")[0];

				let phoneNumberLabel = document.createElement("label");
				phoneNumberLabel.textContent = "Telefon:";
				let phoneNumberInput = document.createElement("input");
				phoneNumberInput.type = "text";
				phoneNumberInput.value = Member.phoneNumber;

				let emailLabel = document.createElement("label");
				emailLabel.textContent = "Email:";
				let emailInput = document.createElement("input");
				emailInput.type = "email";
				emailInput.value = Member.email;

				let saveButton = document.createElement("button");
				saveButton.textContent = "Gem";
				saveButton.addEventListener("click", function () {
					// Update member data
					Member.fullName = nameInput.value;
					Member.membership.membershipId = parseInt(membershipSelect.value);
					Member.joinDate = joinDateInput.value;
					Member.phoneNumber = phoneNumberInput.value;
					Member.email = emailInput.value;

					console.log(Member);

					// Update the member in the database
					fetch(memberURL, {
						method: "PUT",
						headers: {
							"Content-Type": "application/json",
						},
						body: JSON.stringify(Member),
					});

					// Close the modal
					modal.remove();
				});

				let cancelButton = document.createElement("button");
				cancelButton.textContent = "Annuller";
				cancelButton.addEventListener("click", function () {
					// Close the modal without saving changes
					modal.remove();
				});

				// Append input elements to the form
				form.appendChild(nameLabel);
				form.appendChild(nameInput);
				form.appendChild(membershipLabel);
				form.appendChild(membershipSelect);
				form.appendChild(joinDateLabel);
				form.appendChild(joinDateInput);
				form.appendChild(phoneNumberLabel);
				form.appendChild(phoneNumberInput);
				form.appendChild(emailLabel);
				form.appendChild(emailInput);
				form.appendChild(saveButton);
				form.appendChild(cancelButton);

				// Append the form to the modal
				modal.appendChild(form);

				// Append the modal to the document body
				document.body.appendChild(modal);
			});

			li.appendChild(Name);
			li.appendChild(EmailText);
			li.appendChild(PhoneNumb);
			li.appendChild(CreationDate);
			li.appendChild(MembershipStatus);
			buttonContainer.appendChild(del);
			buttonContainer.appendChild(edit);
			li.appendChild(buttonContainer);

			memberList.appendChild(li);
		});
	})
	.catch((error) => {
		console.error("Error fetching Members:", error);
	});

let addMemberButton = document.querySelector("#add");
addMemberButton.addEventListener("click", function () {
	// Create a modal element
	let modal = document.createElement("div");
	modal.classList.add("modal");

	// Create form elements for adding a new member
	let form = document.createElement("form");

	// Create input elements for adding a new member
	let nameLabel = document.createElement("label");
	nameLabel.textContent = "Navn:";
	let nameInput = document.createElement("input");
	nameInput.type = "text";

	let membershipLabel = document.createElement("label");
	membershipLabel.textContent = "Medlemskab:";
	let membershipSelect = document.createElement("select");
	let activeOption = document.createElement("option");
	activeOption.value = 2;
	activeOption.textContent = "Aktiv";
	let passiveOption = document.createElement("option");
	passiveOption.value = 1;
	passiveOption.textContent = "Passiv";
	membershipSelect.appendChild(activeOption);
	membershipSelect.appendChild(passiveOption);

	let joinDateLabel = document.createElement("label");
	joinDateLabel.textContent = "Oprettelsesdato:";
	let joinDateInput = document.createElement("input");
	joinDateInput.type = "date";

	let phoneNumberLabel = document.createElement("label");
	phoneNumberLabel.textContent = "Telefon:";
	let phoneNumberInput = document.createElement("input");
	phoneNumberInput.type = "text";

	let emailLabel = document.createElement("label");
	emailLabel.textContent = "Email:";
	let emailInput = document.createElement("input");
	emailInput.type = "email";

	let saveButton = document.createElement("button");
	saveButton.textContent = "Tilføj";
	saveButton.addEventListener("click", function () {
		// Create a new member
		let membershipVar = {
			membership: {
				membershipId: parseInt(membershipSelect.value),
				name: "string",
				description: "string",
			},
		};

		let member = {
			fullName: nameInput.value,
			membership: membershipVar.membership, // Access the inner object directly
			joinDate: joinDateInput.value,
			phoneNumber: phoneNumberInput.value,
			email: emailInput.value,
		};

		console.log(membershipSelect.value);
		console.log(member);

		// Add the new member to the database
		fetch(memberURL, {
			method: "POST",
			headers: {
				"Content-Type": "application/json",
			},
			body: JSON.stringify(member),
		});

		// Close the modal
		modal.remove();
	});

	let cancelButton = document.createElement("button");
	cancelButton.textContent = "Annuller";
	cancelButton.addEventListener("click", function () {
		// Close the modal without saving the new member
		modal.remove();
	});

	// Append input elements to the form
	form.appendChild(nameLabel);
	form.appendChild(nameInput);
	form.appendChild(membershipLabel);
	form.appendChild(membershipSelect);
	form.appendChild(joinDateLabel);
	form.appendChild(joinDateInput);
	form.appendChild(phoneNumberLabel);
	form.appendChild(phoneNumberInput);
	form.appendChild(emailLabel);
	form.appendChild(emailInput);
	form.appendChild(saveButton);
	form.appendChild(cancelButton);

	// Append the form to the modal
	modal.appendChild(form);

	// Append the modal to the document body
	document.body.appendChild(modal);
});
