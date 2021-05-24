var urlDomain = "https://localhost:44323/";
var urlPets = urlDomain + "api/Pets/";

window.addEventListener("load", function () {
    loadPetsTable();
});

function loadPetsTable() {
    var divTable = document.querySelector("#tblPets");

    var table = `
        <table class="table table-hover border">
            <thead class="thead-light">
                <tr>
                    <th>Nombre</th>
                    <th>Color</th>
                    <th>Genero</th>
                    <th>Dueño</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>`;

    const headers = {
        method: "GET"
    };

    fetch(urlPets, headers)
        .then(res => res.json())
        .then(json => {
            const data = json.data;

            if (data.length > 0) {
                data.forEach(x => {
                    const tr = `<tr>
                                    <td>${x.name}</td>
                                    <td>${x.color}</td>
                                    <td>${x.gender}</td>
                                    <td>${x.ownerName}</td>
                                    <td>
                                        <a href="editPet.html?id=${x.id}" class="btn btn-warning">Editar</a>
                                        <button onclick="openDelete(${x.id})" class="btn btn-danger">Borrar</button>
                                    </td>
                                </tr>`;

                    table += tr;
                });
            } else {
                table += `  <tr>
                                <td class="text-danger text-center" colspan="5">No hay datos para mostrar.</td>
                            </tr>`;
            }

            table += `  </tbody>
                    </table>`;

            divTable.innerHTML = table;

        }).catch(err => {

            table += `  <tr>
                            <td class="text-danger text-center" colspan="5">Error al cargar los datos.</td>
                        </tr>
                </tbody>
            </table>`;

            divTable.innerHTML = table;

            console.log("Error fetching data from backend: " + err);
        });
}

function openDelete(id){
    Swal.fire({
        title: 'Estás seguro?',
        text: "No podrás recuperar la información!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, borrar!',
        cancelButtonText: 'Cancelar'
      }).then((result) => {
        if (result.isConfirmed) {
          Swal.fire(
            'Eliminado!',
            'Se borró correctamente.',
            'success'
          )
        }
      })
}
