<template>
  <div id="app">
    <v-app id="inspire">
      <v-toolbar flat color="#FFB300">
        <v-toolbar-title>Cart</v-toolbar-title>
        <v-divider class="mx-2"
                   inset
                   vertical></v-divider>
      </v-toolbar>
      <v-alert :value="alert.state"
               :type="alert.type"
               transition="scale-transition">
        {{alert.content}}
      </v-alert>
      <v-data-table :headers="headers"
                    :items="list"
                    class="elevation-1"
                    hide-actions>
        <template v-slot:items="props">
          <td>{{ props.item.title }}</td>
          <td>{{ props.item.category.title }}</td>
          <td>${{ props.item.price }}</td>
          <delete-alert @deleted="deleteItem(props.item)"></delete-alert>
        </template>
      </v-data-table>
      <v-btn dark color="grey darken-2" v-if="isLogged" @click="buy">Buy</v-btn>
    </v-app>
  </div>

  
</template>

<script>
  import { mapActions, mapState } from 'vuex'
  import deleteAlert from '../components/delete-alert'
  import axios from 'axios'
  export default {
    data: () => ({
      alert: { state: false, type: "error", content: '' },
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
    components: {
      'delete-alert': deleteAlert
    },
    methods: {
      submit() {
        
      },

      async deleteItem(item) {
        var filtered = this.list.filter(function (value, index, arr) {
          return value != item;
        });
        this.deleteBooks({ cart: filtered })
      },

      ...mapActions(['deleteBooks']),

      buy() {
        var that = this;
        axios.post('orders/AddOrder', {
          clientId: this.$cookies.get('UserCookie').id,
          list: this.list, 
        }).then(function (value) {
          if (value.data.successful) {
            that.alert = { state: true, type: "success", content: "You have successfully bought books! Wait for courier" }
            var cart = [];
            that.deleteBooks({ cart: cart })
          }
          else
            that.alert = { state: true, type: "error", content: "Something goes wrong! Try again"  }
        })
      },
    }
  }
</script>

<style scoped>

</style>
