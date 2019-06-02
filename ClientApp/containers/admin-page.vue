<template>
  <div id="app">
    <v-app id="inspire">
      <v-toolbar color="pink"
                 dark>
        <v-toolbar-title>Admin panel</v-toolbar-title>
      </v-toolbar>

      <v-card>
        <v-container fluid
                     grid-list-lg>
          <v-layout row wrap>

              <v-btn :to="'/categories'">Categories</v-btn>


              <v-btn :to="'/authors'">Authors</v-btn>


              <v-btn :to="'/publishinghouses'">Houses</v-btn>


              <v-btn :to="'/books'">Books</v-btn>

              <v-btn :to="'/orders'">Orders</v-btn>
              <v-btn @click="addTopBook">New TOP 4 BOOKS</v-btn>

          </v-layout>
        </v-container>
      </v-card>
    </v-app>
  </div>
</template>
<script>
  import { addTopBooks } from '../services/books'



 
  export default {
    data() {
      return {

      }
    },
    components: {



    },
    methods: {
      addTopBook() {
        addTopBooks();
      },

    }
  }
</script>
<style scoped>
</style>
