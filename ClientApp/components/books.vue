<template>
  <div id="app">
    <v-app id="inspire">
      <v-toolbar flat color="#FFB300">
        <v-toolbar-title>Books management</v-toolbar-title>
        <v-divider class="mx-2"
                   inset
                   vertical></v-divider>
        <v-spacer></v-spacer>
        <book-form></book-form>
      </v-toolbar>
      <v-data-table :headers="headers"
                    :items="list"
                    class="elevation-1">
        <template v-slot:items="props">
          <td>{{ props.item.isbn }}</td>
          <td>{{ props.item.title }}</td>
          <td><p v-for="author in props.item.authors" :key="author.id">{{author.name}} {{author.surname}}</p></td>
          <td>{{ props.item.publishingHouse.title }}</td>
          <td>{{ props.item.category.title }}</td>
          <td>{{ props.item.publishmentYear }}</td>
          <td>${{ props.item.price }}</td>
          <td class="justify-center">
            <delete-alert @deleted="deleteItem(props.item.isbn)"></delete-alert>
          </td>
        </template>

      </v-data-table>
      <v-btn @click="loadMore">Load more</v-btn>
    </v-app>
  </div>


</template>
<script>
  import { getBooks, deleteBook } from '../services/books'
  import bookForm from '../components/book-form'
  import deleteAlert from '../components/delete-alert'

  export default {
    data: () => ({
      list: [],
      title: "",
      category: '',
      take: 10,
      skip: 0,
      headers: [
        { text: 'ISBN', align: 'left', value: 'id' },
        { text: 'Title', value: 'title' },
        { text: 'Authors', value: 'author' },
        { text: 'Publishing House', value: 'phouse' },
        { text: 'Category', value: 'category' },
        { text: 'Publishment Year', value: 'pyear' },
        { text: 'Price', value: 'price' },
        { text: 'Actions', value: 'name', sortable: false }
      ],
    }),
    created: function () {
      this.getBody();
    },
    watch: {
      "$route"(to, from) {
        this.skip = 0;
        this.getBody();
      },
    },
    methods: {
      async deleteItem(isbn) {
        await deleteBook(isbn);
        this.skip = 0;
        this.getBody();

      },
      getBody: function () {
        getBooks(this.take, this.skip, this.category).then(value => this.list = value);
        this.skip += this.take;
      },
      loadMore: function () {
        getBooks(this.take, this.skip, this.category).then(value => this.list = this.list.concat(value));
        this.skip += this.take;
      },
    },
    components: {
      'book-form': bookForm,
      'delete-alert': deleteAlert
    }
  }
</script>
<style scoped>

</style>
