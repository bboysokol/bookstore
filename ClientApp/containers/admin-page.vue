<template>
  <div id="app">
    <v-app id="inspire">
      <v-toolbar color="#FFB300">
        <v-toolbar-title>Admin panel</v-toolbar-title>
      </v-toolbar>
      <v-card>
        <v-container fluid
                     grid-list-lg>
          <v-layout row wrap>
              <v-btn block
                     class="grey darken-1"
                     dark
                     :to="'/categories'">Categories</v-btn>
              <v-btn block class="grey darken-1"
                     dark :to="'/authors'">Authors</v-btn>
              <v-btn block class="grey darken-1"
                     dark :to="'/publishinghouses'">Houses</v-btn>
              <v-btn block class="grey darken-1"
                     dark :to="'/books'">Books</v-btn>
              <v-btn block class="grey darken-1"
                     dark :to="'/orders'">Orders</v-btn>
              <v-btn block class="grey darken-1"
                     dark @click="addTopBook">New TOP 4 BOOKS</v-btn>
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
      return {}
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
