<template>
  <div id="app">
    <v-app id="inspire">
      Authors
      <v-data-table :headers="headers"
                    :items="list"
                    class="elevation-1">
        <template v-slot:items="props">
          <td>{{ props.item.isbn }}</td>
          <td>{{ props.item.title }}</td>
          <td><p v-for="author in props.item.authors" :key="author.id">{{author.name}}{{author.surname}}</p></td>
          <td>{{ props.item.publishingHouse.title }}</td>
          <td>{{ props.item.category.title }}</td>
          <td>{{ props.item.publishmentYear }}</td>
          <td>${{ props.item.price }}</td>
        </template>
      </v-data-table>
    </v-app>
  </div>

  
</template>

<script>
  import axios from 'axios'

  export default {
    data: () => ({
      list: [],
      headers: [
        {
          text: 'ISBN',
          align: 'left',
          value: 'id'
        },
        { text: 'Title', value: 'title' },
        { text: 'Authors', value: 'author' },
        { text: 'Publishing House', value: 'phouse' },
        { text: 'Category', value: 'category' },
        { text: 'Publishment Year', value: 'pyear' },
        { text: 'Price', value: 'price' },
      ],
    }),
    created: function () {
      var that = this;
      
        axios.get('books/GetBooks')
          .then(function (response) {
            console.log(response.data.payload);
            that.list = response.data.payload;
          })
    },
    methods: {
      submit() {
        
      },
    }
  }
</script>

<style scoped>
</style>
