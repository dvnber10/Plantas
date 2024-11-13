document.addEventListener('DOMContentLoaded', function () {
    const radioButtons = document.querySelectorAll('input[name="DataType"]');
    const formContainer = document.getElementById('formContainer');

    // Función para cargar el formulario por AJAX
    function loadForm(formId) {
        // Aquí usamos fetch para hacer la solicitud al servidor y obtener la vista parcial
        fetch(formId)
            .then(response => {
                if (response.ok) {
                    return response.text();  // Si la respuesta es exitosa, obtenemos el contenido HTML
                } else {
                    throw new Error('Error al cargar el formulario');
                }
            })
            .then(html => {
                formContainer.innerHTML = html;  // Inserta el formulario en el contenedor
            })
            .catch(error => {
                console.error('Error cargando el formulario:', error);
            });
    }

    // Cargar el formulario por defecto al cargar la página
    loadForm('/Home/FormPlants');  // Ruta para el primer formulario

    // Agregar un listener a cada radio button para cargar el formulario correspondiente
    radioButtons.forEach(radio => {
        radio.addEventListener('change', function () {
            switch (this.value) {  // Usamos el value del radio button
                case 'plant':
                    loadForm('/Home/FormPlants');
                    break;
                case 'family':
                    loadForm('/Home/FormFamily');
                    break;
                case 'disease':
                    loadForm('/Home/FormDisease');
                    break;
                case 'plague':
                    loadForm('/Home/FormPlague');
                    break;
                default:
                    break;
            }
        });
    });
});



// Esta funcion hace que el radio sea true cuando se le de click a el label 
// function chequea(radio) {
//     document.getElementById(radio).checked = true;
// }

const formContainer = document.getElementById('formContainer');


function formatPlantName() {
    var input = document.getElementById('plantName');
    input.value = capitalizeFirstLetter(input.value);
}

function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1).toLowerCase();
}