<template>
  <div id="app">
    <v-app id="inspire">
      <v-toolbar flat color="#FFB300">
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
          <td>{{ props.item.client.name }} {{ props.item.client.surname }}</td>
          <td>{{ props.item.client.street }} {{ props.item.client.houseNumber }}/{{ props.item.client.apartamentNumber }}<br /> {{ props.item.client.postCode }}</td>
          <td><p v-for="item in props.item.shoppingCarts" :key="item.isbn"> {{item.title}}</p></td>
          <td><v-checkbox v-model="props.item.isDone"  @change="changeState(props.item.id)"></v-checkbox>
          </td>
          <td class="justify-center">
            <delete-alert @deleted="deleteItem(props.item.id)"></delete-alert>
          </td>
        </template>
      </v-data-table>
      <v-btn @click="loadMore">Load more</v-btn>
    </v-app>
  </div>

  
</template>

<script>
  import axios from 'axios'
  import { getOrders, deleteOrder, changeState } from '../services/orders'
  import deleteAlert from '../components/delete-alert'
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
        { text: 'Date', value: 'date' },
        { text: 'Personalia', value: 'personalia' },
        { text: 'Odbiór', value: 'odbior' },
        { text: 'Produkt', value: 'produkt' },
        { text: 'Zrealizowane', value: 'done' },
      ],
    }),
    created: function () {
      this.getBody();
    },
    components: {
      'delete-alert': deleteAlert
    },
    methods: {
      getBody() {
        getOrders(this.take, this.skip).then(response => this.list = response);
        this.skip += this.take;
      },
      loadMore() {
        getOrders(this.take, this.skip).then(response => this.list = this.list.concat(response));
        this.skip += this.take;
      },
      changeState(id) {
        changeState(id)

      },
      async deleteItem(id) {
        await deleteOrder(id);
        this.skip = 0;
        this.getBody();
      }
    }
  }
</script>

<style scoped>
</style>
