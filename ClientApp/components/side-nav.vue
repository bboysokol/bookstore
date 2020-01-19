<template>
  <div id="app">
    <v-btn :to="'/books/'+item.title"
                 v-for="item in categories"
                  :key="item.id"
           class="category_btn">
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
  .category_btn{
    min-width:90%;
  }
  @media only screen and (max-width: 1407.9px){
    .category_btn{
      min-width:0;
    }
  }
</style>
