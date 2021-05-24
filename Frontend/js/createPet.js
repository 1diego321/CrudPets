var urlDomain = "https://localhost:44323/";
var urlPets = urlDomain + "api/Pets/";

window.addEventListener("load", function () {
    document.getElementById("frmPet").addEventListener("submit", createPet)
});

function createPet(e) {
    e.preventDefault();

    var form = document.getElementById("frmPet");

    const headers = {
        'Accept': 'application/json'
    };

    const body = new FormData(form)

    fetch(urlPets, {
        headers: headers,
        method: 'POST',
        body: body
    })
        .then(res => res.json())
        .then(json => {
            if (json.success) {
                showSuccess(json.message);
            } else {

                let msg = "";

                if (json.hasModelErrors) {
                    json.data.forEach(x => {
                        msg += `${x}</br>`;
                    });

                    fireSwal('Error en las validaciones',msg,'error');

                    return;
                }

                fireSwal('Error :(',json.message,'error');
            }
        }).catch(e => {
            fireSwal('Error :(','Hubo un error.. ','error');
            console.log(e);
        });
}

function fireSwal(title,message,type){
    Swal.fire(
        title,
        message,
        type
    );
}

function showSuccess(msg) {
    let timerInterval
    Swal.fire({
        icon: 'success',
        title: msg,
        html: 'Redireccionando a la pagina de inicio en <b></b> milisegundos.',
        timer: 5000,
        timerProgressBar: true,
        didOpen: () => {
            Swal.showLoading()
            timerInterval = setInterval(() => {
                const content = Swal.getHtmlContainer()
                if (content) {
                    const b = content.querySelector('b')
                    if (b) {
                        b.textContent = Swal.getTimerLeft()
                    }
                }
            }, 100)
        },
        willClose: () => {
            clearInterval(timerInterval)
        }
    }).then((result) => {
        window.location.href = "index.html";
    })
}