var urlDomain = "https://localhost:44323/";
var urlOwners = urlDomain + "api/Owners/";
var urlPets = urlDomain + "api/Pets/";

window.addEventListener("load", function () {

    var ownerSelect = document.getElementById("ownerid");
    var genderSelect = document.getElementById("gender");

    const headers = {
        method: "GET"
    };

    fetch(urlPets + "GetGenders", headers)
        .then(res => res.json())
        .then(json => {
            if (json.success) {
                const data = json.data;

                data.forEach(x => {
                    let opt = `<option value="${x}">${x}</options>`;
                    genderSelect.innerHTML += opt;
                });
            }
        }).catch(err => {
            console.log("Error fetching data from backend: " + err);
        });


        fetch(urlOwners + "GetOwners", headers)
        .then(res => res.json())
        .then(json => {
            if (json.success) {
                const data = json.data;

                data.forEach(x => {
                    let opt = `<option value="${x.key}">${x.value}</options>`;
                    ownerSelect.innerHTML += opt;
                });
            }
        }).catch(err => {
            console.log("Error fetching data from backend: " + err);
        });

});