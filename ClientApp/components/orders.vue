<template>
  <div id="app">
    <v-app id="inspire">
      <v-toolbar flat color="red">
        <v-toolbar-title>Orders management</v-toolbar-title>
        <v-divider class="mx-2"
                   inset
                   vertical></v-divider>
        <v-spacer></v-spacer>
      </v-toolbar>
      <v-data-table :headers="headers"
                    :items="list"
                    class="elevation-1">
        <template v-slot:items="props">
          <td>{{ props.item.id }}</td>
          <td>{{ props.item.date }}</td>
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
      take: 10,
      skip: 0,
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
      var that = this;
      
      axios.get('orders/GetOrders' + '?take=' + that.take + '&skip=' + that.skip)
          .then(function (response) {
            that.skip += 10;
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
