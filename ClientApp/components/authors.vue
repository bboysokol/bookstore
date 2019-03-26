<template>
  <v-container>
    <div v-for="item in list" :key="item.id">
      {{item.id}} {{item.name}}  {{item.surname}}
    </div>
  </v-container>
</template>

<script>
  import axios from 'axios'

  export default {
    data: () => ({
      list:[]
    }),
    created: function () {
      var that = this;
      
        axios.get('authors/GetAuthors')
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

<style>
</style>
