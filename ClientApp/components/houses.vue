<template>
  <div id="app">
    <v-app id="inspire">
      <v-toolbar flat color="#FFB300">
        <v-toolbar-title>Publishing Houses management</v-toolbar-title>
        <v-divider class="mx-2"
                   inset
                   vertical></v-divider>
        <v-spacer></v-spacer>
        <publish-form></publish-form>
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
  import { getPublishingHouses, deletePublishingHouse } from '../services/publishinghouses'
  import deleteAlert from '../components/delete-alert'
  import publishForm from '../components/publishHouse-form'
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
    methods: {
      async deleteItem(id) {
        await deletePublishingHouse(id);
        this.getBody();
      },
      getBody() {
        getPublishingHouses().then(response => this.list = response);
      }
    },
    components: {
      'publish-form': publishForm,
      'delete-alert': deleteAlert
    }
  }
</script>

<style scoped>
</style>
