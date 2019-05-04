<template>
  <div id="app">
    <v-btn :to="'/addcategory'"
                 v-for="item in categories"
                  :key="item.id">
      {{item.title}}
    </v-btn>
  </div>
</template>

<script>
  import { getCategories } from '../services/categories'
  export default {
    data() {
      return {
        categories: []
      }
    },
    created: function () {
      getCategories().then(value => this.categories= value);    
    },
  }
</script>
<style scoped>
</style>
