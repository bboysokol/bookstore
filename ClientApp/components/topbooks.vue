<template>
  <div id="app">
      <v-card>
        <v-toolbar color="#FFB300">
          <v-toolbar-title>Top 4 books</v-toolbar-title>
        </v-toolbar>
          <v-container fluid
                       grid-list-lg>
            <v-layout row wrap>
              <v-flex xs12 md6 v-for="book in books" :key="book.isbn">
                <v-card color="grey darken-3" class="white--text">
                  <v-layout>
                    <v-flex xs5>
                      <v-img :src="$appPath +'/img/' + book.img"
                             height="125px"
                             contain></v-img>
                    </v-flex>
                    <v-flex xs7>
                      <v-card-title primary-title>
                        <div>
                          <div class="headline">{{book.title}}</div>
                          <div v-for="author in book.authors" :key="author.id">{{author.name +" "+author.surname}}</div>
                          <div>{{book.publishingHouse.title}}({{ book.publishmentYear}})</div>
                        </div>
                      </v-card-title>
                    </v-flex>
                  </v-layout>
                  <v-divider light></v-divider>
                  <v-card-actions class="pa-3">
                    ${{book.price}}
                    <v-spacer></v-spacer>
                    <v-btn
                           round
                           outline
                           color="#FFB300"
                           @click="addBookToCart(book)">Add</v-btn>
                  </v-card-actions>
                </v-card>
              </v-flex>
            </v-layout>
          </v-container>
      </v-card>
  </div>

  
</template>

<script>
  import { mapActions, mapState } from 'vuex'
  import { getTopBooks } from '../services/books'
  import { addOrder } from '../services/orders'
  import { config } from '@fortawesome/fontawesome';
  export default {
    data() {
      return {
        title: "",
        books: [],
      }
    },
    watch: {
      "$route"(to, from) {
        this.getBody();
      },
    },
    components: {

    },
    created: function () {
      this.getBody();
    },
    methods: {
      getBody: function () {
        
        getTopBooks().then(value => this.books = value);
        console.log("hehe", this.books);
      },
      buy: function (bookId) {
        addOrder(bookId, this.$cookies.get('UserCookie').id);
      },
      ...mapActions(['addBook']),
      addBookToCart: function (book) {
        var cart = this.currentCart.concat(book);
        this.addBook({ cart: cart })
      },
    },
    computed: {
      ...mapState({
        currentCart: state => state.cart
      })
    },

  }
</script>

<style scoped>
</style>
