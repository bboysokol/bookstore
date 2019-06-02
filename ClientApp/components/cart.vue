<template>
  <div id="app">
    <v-app id="inspire">
      <v-toolbar flat color="red">
        <v-toolbar-title>Cart</v-toolbar-title>
        <v-divider class="mx-2"
                   inset
                   vertical></v-divider>
      </v-toolbar>
      <v-data-table :headers="headers"
                    :items="list"
                    class="elevation-1"
                    hide-actions>
        <template v-slot:items="props">
          <td>{{ props.item.title }}</td>
          <td>{{ props.item.category.title }}</td>
          <td>${{ props.item.price }}</td>
        </template>
      </v-data-table>
      <v-btn v-if="isLogged" @click="buy">Buy</v-btn>
    </v-app>
  </div>

  
</template>

<script>
  import { mapActions, mapState } from 'vuex'
  import axios from 'axios'
  export default {
    data: () => ({
      headers: [
        {
          text: 'Title',
          align: 'left',
          value: 'id'
        },
        { text: 'Name', value: 'name' },
        { text: 'Price', value: 'price'},
      ],
      isLogged: false,
    }),
    computed: {
      ...mapState({
        list: state => state.cart,
      })
    },
    created: function () {
      
      if (this.$cookies.get('UserCookie') != null) {
        this.isLogged = true;
      }
    },
    methods: {
      submit() {
        
      },
      ...mapActions(['deleteBooks']),

      buy() {
        var that = this;
        axios.post('orders/AddOrder', {
          clientId: this.$cookies.get('UserCookie').id,
          list: this.list, 
        }).then(function () {
          var cart = [];
          that.deleteBooks({ cart: cart })
        })
      },
    }
  }
</script>

<style scoped>

</style>
