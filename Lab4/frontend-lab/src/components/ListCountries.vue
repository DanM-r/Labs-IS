<template>
  <div class="container mt-5">
    <h1 class="display-4 text-center">Lista de países</h1>
    <table
    class="table is-bordered is-striped is-narrow is-hoverable
    is-fullwidth"
    >
      <thead>
          <tr>
              <th>Nombre</th>
              <th>Continente</th>
              <th>Idioma</th>
              <th>Acciones</th>
          </tr>
      </thead>
      <tbody>
        <tr v-for="(pais, index) in paises" :key="index">
          <td>
            <input type="text"
              v-if="allowEditing"
              v-model="pais.nombre"
              @keypress.enter="allowEditing = !allowEditing">
            <span v-else>{{ pais.nombre }}</span>
          </td>
          <td>
            <input type="text"
              v-if="allowEditing"
              v-model="pais.continente"
              @keypress.enter="allowEditing = !allowEditing">
            <span v-else>{{ pais.continente }}</span>
          </td>
          <td>
            <input type="text"
              v-if="allowEditing"
              v-model="pais.Idioma"
              @keypress.enter="allowEditing = !allowEditing">
            <span v-else>{{ pais.Idioma }}</span>
          </td>
          <td>
            <button @click="allowEditing = !allowEditing" class="btn btn-secondary btn-sm">Editar</button>
            <button @click="deleteListElement(index)" class="btn btn-danger btn-sm">Eliminar</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
  import { ref } from "vue";

  export default {
    name:  "ListCountries",
    setup() {
      const allowEditing = ref(false);

      return {
        allowEditing
      }
    },
    data() {
      return {
        paises: [
        { nombre: "Costa Rica", continente: "América", Idioma: "Español" },
        { nombre: "Japón", continente: "Asia", Idioma: "Japonés" },
        { nombre: "Corea del Sur", continente: "Asia", Idioma: "Coreano" },
        { nombre: "Italia", continente: "Europa", Idioma: "Italiano" },
        { nombre: "Alemania", continente: "Europa", Idioma: "Alemán" },
        ],
      };
    },
    methods:
    {
      deleteListElement(index)
      {
        this.paises.splice(index, 1);
      }
    },
  }
</script>

<style lang="scss" scoped>

</style>