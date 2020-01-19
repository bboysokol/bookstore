<template>
  <div id="app">
    <v-app id="inspire">
      <v-toolbar flat color="#FFB300">
        <v-toolbar-title>Categories management</v-toolbar-title>
        <v-divider class="mx-2"
                   inset
                   vertical></v-divider>
        <v-spacer></v-spacer>
        <category-form></category-form>
      </v-toolbar>
      <v-data-table :headers="headers"
                    :items="list"
                    class="elevation-1">
        <template v-slot:items="props">
          <td>{{ props.item.id }}</td>
          <td>{{ props.item.title }}</td>
          <td class="justify-center">
            <delete-alert @deleted="deleteItem(props.item.id)"></delete-alert>
          </td>
        </template>
      </v-data-table>
    </v-app>
  </div>

  
</template>

<script>
  import { getCategories, deleteCategory } from '../services/categories'
  import deleteAlert from '../components/delete-alert'
  import categoriesForm from '../components/category-form'
  export default {
    data: () => ({
      list: [],
      headers: [
        {
          text: 'Id',
          align: 'left',
          value: 'id'
        },
        { text: 'Title', value: 'title' },
      ],
    }),
    created: function () {
      this.getBody();
    },
    components: {
      'category-form': categoriesForm,
      'delete-alert': deleteAlert
    },
    methods: {
      async deleteItem(id) {
        await deleteCategory(id);
        this.getBody();
      },
      getBody() {
        getCategories().then(response => this.list = response);
      }
    }
  }
</script>

<style scoped>
</style>
