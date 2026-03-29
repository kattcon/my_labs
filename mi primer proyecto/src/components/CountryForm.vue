<template>
    <!-- Contenedor principal centrado vertical y horizontalmente -->
    <div class="d-flex justify-content-center align-items-center vh-100">
        <!-- Tarjeta (card) con padding, sombra y ancho máximo -->
        <div class="card p-4 shadow" style="max-width: 400px; width: 100%">
            <!-- Título centrado -->
            <h3 class="text-center">Formulario de creación de países</h3>
            <!-- Formulario Vue -->
            <!-- @submit.prevent evita que la página se recargue y llama a la función saveCountry -->
            <form @submit.prevent="saveCountry">
                <!-- Grupo del campo Nombre -->
                <div class="form-group">
                    <!-- Etiqueta del input -->
                    <label for="nombre">Nombre:</label>
                    <!-- Input de texto -->
                    <!-- v-model conecta este campo con formData.Name en Vue -->
                    <input v-model="formData.Name"
                           type="text"
                           id="name"
                           class="form-control"
                           required />
                </div>
                <!-- Grupo del campo Continente -->
                <div class="form-group">
                    <label for="continente">Continente:</label>
                    <!-- Select (lista desplegable) -->
                    <!-- v-model guarda el valor seleccionado en formData.Continent -->
                    <select v-model="formData.Continent"
                            id="continente"
                            required
                            class="form-control">
                        <!-- Opción por defecto deshabilitada -->
                        <option value="" disabled>Seleccione un continente</option>
                        <!-- Opciones disponibles -->
                        <option>África</option>
                        <option>Asia</option>
                        <option>Europa</option>
                        <option>América</option>
                        <option>Oceanía</option>
                        <option>Antártida</option>
                    </select>
                </div>
                <!-- Grupo del campo Idioma -->
                <div class="form-group">
                    <label for="idioma">Idioma:</label>
                    <!-- Input de texto -->
                    <!-- Se guarda en formData.Language -->
                    <input v-model="formData.Language"
                           type="text"
                           id="idioma"
                           class="form-control"
                           required />
                </div>
                <!-- Botón de envío -->
                <div>
                    <!-- type="submit" dispara el submit del formulario -->
                    <button type="submit" class="btn btn-success btn-block">
                        Guardar
                    </button>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
    import axios from "axios";

    export default {
        // Aquí definimos los datos reactivos del formulario
        data() {
            return {
                formData: { Name: "", Continent: "", Language: "" },
            };
        },
        methods: {
            saveCountry() {
                console.log("Datos a guardar:", this.formData);
                axios
                    .post("http://localhost:5193/api/Country", {
                        Name: this.formData.Name,
                        Continent: this.formData.Continent,
                        Language: this.formData.Language,
                    })
                    .then(function (response) {
                        console.log(response);
                        window.location.href = "/";
                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            },
        },
    };
</script>

<style></style>