<template>
  <div id="app">
    <v-app id="inspire">
      Authors
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
      
        axios.get('categories/GetCategories')
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
