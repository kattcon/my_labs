<template>
    <!-- Contenedor principal con margen superior -->
    <div class="container mt-5">
        <!-- Título de la página -->
        <h1 class="display-4 text-center">Lista de países</h1>
        <!-- Tabla donde se mostrarán los datos -->
        <table class="table is-bordered is-striped is-narrow is-hoverable is-fullwidth">
            <!-- Encabezado de la tabla -->
            <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Continente</th>
                    <th>Idioma</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <!-- Cuerpo de la tabla -->
            <tbody>
                <!-- v-for recorre el arreglo countries y crea una fila por cada país -->
                <tr v-for="(country, index) of countries" :key="index">
                     <!-- Muestra el nombre del país -->
                    <td>{{country.name}}</td>
                    <!-- Muestra el continente -->
                    <td>{{country.continent}}</td>
                    <!-- Muestra el idioma -->
                    <td>{{country.language}}</td>
                    <!-- Botones de acciones -->
                    <td>
                        <button class="btn btn-secondary btn-sm">Editar</button>
                        <button class="btn btn-danger btn-sm">Eliminar</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    // Nombre del componente y datos que se mostrarán en la tabla
    export default {
        name: 'CountriesList',
        // Función data que define los datos del componente
        data() {
            return {
                // Arreglo de objetos con información de países
                countries: [
                    { name: 'Costa Rica', continent: 'América', language: 'Español' },
                    { name: 'Japón', continent: 'Asia', language: 'Japonés' },
                    { name: 'Corea del Sur', continent: 'Asia', language: 'Coreano' },
                    { name: 'Italia', continent: 'Europa', language: 'Italiano' },
                    { name: 'Alemania', continent: 'Europa', language: 'Alemán' },
                ],
            };
        }
    }
</script>

<style lang="scss" scoped>

</style>