<template>
  <div id="app">
    <v-app id="inspire">
      Authors
      <v-data-table :headers="headers"
                    :items="list"
                    class="elevation-1">
        <template v-slot:items="props">
          <td>{{ props.item.title }}</td>
          <td>{{ props.item.category.title }}</td>
        </template>
      </v-data-table>
    </v-app>
  </div>

  
</template>

<script>
  import { mapActions, mapState } from 'vuex'
  export default {
    data: () => ({
      headers: [
        {
          text: 'Title',
          align: 'left',
          value: 'id'
        },
        { text: 'Name', value: 'name' },
      ],
    }),
    computed: {
      ...mapState({
        list: state => state.cart,
      })
    },
    created: function () {
     
    },
    methods: {
      submit() {
        
      },
    }
  }
</script>

<style scoped>
</style>
