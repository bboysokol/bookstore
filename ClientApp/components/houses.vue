<template>
  <div id="app">
    <v-app id="inspire">
      <v-toolbar flat color="red">
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
        </template>
      </v-data-table>
    </v-app>
  </div>

  
</template>

<script>
  import axios from 'axios'
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
      var that = this;
      
      axios.get('publishinghouses/GetPublishingHouses')
          .then(function (response) {
            console.log(response.data.payload);
            that.list = response.data.payload;
          })
    },
    methods: {
      submit() {
        
      },
    },
    components: {
      'publish-form': publishForm,
    }
  }
</script>

<style scoped>
</style>
