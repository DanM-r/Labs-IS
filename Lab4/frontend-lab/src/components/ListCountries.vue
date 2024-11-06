<template>
  <div class="container mt-5">
    <h1 class="display-4 text-center">Lista de países</h1>
    <div class="row justify-content-end">
      <div class="col-2">
        <a href="/country">
          <button
            type="button"
            class="btn btn-outline-secondary float-right"
          >
          Agregar país
          </button>
        </a>
      </div>
    </div>
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
              v-model="pais.idioma"
              @keypress.enter="allowEditing = !allowEditing">
            <span v-else>{{ pais.idioma }}</span>
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
  import axios from "axios";

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
        paises: [ ],
      };
    },
    methods:
    {
      deleteListElement(index)
      {
        this.paises.splice(index, 1);
      },

      obtenerTareas() {
        axios.get("https://localhost:7055/api/Countries").then(
         (response) => {
           this.paises = response.data;
         });
      },
    },

    created: function () {
      this.obtenerTareas();
    },
  }
</script>

<style lang="scss" scoped>

</style>