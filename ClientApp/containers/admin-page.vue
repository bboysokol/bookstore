<template>
  <div id="app">
    <v-app id="inspire">
      <div>
        <category-form></category-form>
        <author-form></author-form>
        <publish-form></publish-form>
        <book-form></book-form>
      </div>
      <div>
        <v-btn>Categories list</v-btn>
        <v-btn>Authors list</v-btn>
        <v-btn>Houses list</v-btn>
        <v-btn>Books list</v-btn>
        <v-btn>Orders list</v-btn>
      </div>
    </v-app>
  </div>
</template>
<script>
  import authorForm from '../components/author-form'
  import categoriesForm from '../components/category-form'
  import publishForm from '../components/publishHouse-form'
  import bookForm from '../components/book-form'
  export default {
    data() {
      return {

      }
    },
    components: {
      'category-form': categoriesForm,
      'author-form': authorForm,
      'publish-form': publishForm,
      'book-form': bookForm,
    },
    methods: {
      getData(request) {
        getBooks().then(value => this.items = value)
      }
    },

  }
</script>
<style scoped>
</style>
