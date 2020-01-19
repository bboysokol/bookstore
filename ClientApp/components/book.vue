<template>
  <div id="app">
    <v-toolbar color="#FFB300">
      <v-toolbar-title>{{book.title}}</v-toolbar-title>
    </v-toolbar>
    <v-card>
      <v-container fluid
                   grid-list-lg>
        <v-layout row wrap>
          <v-flex xs12>
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
                      <div> {{book.category.title}}</div>
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
  import { getBook } from '../services/books'
  import { mapActions, mapState } from 'vuex'
  export default {
    data: () => ({
      book:[],
      title: "",
      
    }),
    created: function () {
      this.getBody();
    },
    watch: {
      "$route"(to, from) {
        this.getBody();
      },
    },
    methods: {
      getBody: function () {
        getBook(this.$route.params.isbn).then(value => this.book = value);
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
