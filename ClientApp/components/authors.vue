<template>
  <div id="app">
    <v-app id="inspire">
      <v-toolbar flat color="#FFB300">
        <v-toolbar-title>Authors management</v-toolbar-title>
        <v-divider class="mx-2"
                   inset
                   vertical></v-divider>
        <v-spacer></v-spacer>
        <author-form></author-form>
      </v-toolbar>
      <v-data-table :headers="headers"
                    :items="list"
                    class="elevation-1">
        <template v-slot:items="props">
          <td>{{ props.item.id }}</td>
          <td>{{ props.item.name }}</td>
          <td><delete-alert @deleted="deleteItem(props.item.id)"></delete-alert></td>
        </template>
      </v-data-table>
    </v-app>
  </div>

  
</template>

<script>
  import axios from 'axios'
  import authorForm from '../components/author-form'
  import deleteAlert from '../components/delete-alert'
  import { getAuthors, deleteAuthor } from '../services/authors'

  export default {
    data: () => ({
      list: [],
      headers: [
        {
          text: 'Id',
          align: 'left',
          value: 'id'
        },
        { text: 'Name', value: 'name' },
      ],
    }),
    created: function () {
      this.getBody();
    },
    components: {
      'author-form': authorForm,
      'delete-alert': deleteAlert
    },
    methods: {
      getBody() {
        getAuthors().then(value => this.list = value);
      },
      async deleteItem(id) {
        await deleteAuthor(id);
        this.getBody();
      },
    }
  }
</script>

<style scoped>
</style>
