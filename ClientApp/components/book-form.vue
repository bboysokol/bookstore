<template>
  <v-dialog width="500"
            dark
            v-model="dialog">
    <v-btn slot="activator"
           color="#FFB300"
           class="modal-button"
           outline
           round>
      Add book
    </v-btn>
    <v-card class="dialog">
      <v-form ref="form"
              v-model="valid"
              lazy-validation>
        <v-alert :value="alert"
                 type="error"
                 transition="scale-transition">
          "Username or password is incorrect"
        </v-alert>
        <v-label><h2 class="logo">Add a book</h2> </v-label><br />
        <v-text-field v-model="title"
                      :rules="textRules"
                      label="Title"
                      required
                      color="#12d483"
                      prepend-inner-icon="title"
                      outline>
        </v-text-field>

        <v-autocomplete v-model="author"
                        :items="authors"
                        item-text="name"
                        item-value="id"
                        :label="`Author`"
                        outline
                        prepend-inner-icon="person">
        </v-autocomplete>

        <v-autocomplete v-model="category"
                        :items="categories"
                        item-text="title"
                        item-value="id"
                        :label="`Category`"
                        outline
                        prepend-inner-icon="book">
        </v-autocomplete>

        <v-autocomplete v-model="phouse"
                        :items="phouses"
                        item-text="title"
                        item-value="id"
                        :label="`Publishing House`"
                        outline
                        prepend-inner-icon="book">
        </v-autocomplete>
        <v-text-field v-model="publishyear"
                      :label="`Publishment Year`"
                      outline
                      prepend-inner-icon="book">
        </v-text-field>
        <v-text-field v-model="price"
                      :label="`Price`"
                      outline
                      prepend-inner-icon="book">
        </v-text-field>


        <v-btn @click="submit"
               color="#12d483"
               outline
               class="modal-button"
               round>Submit</v-btn>
      </v-form>
    </v-card>
  </v-dialog>
</template>

<script>
  import axios from 'axios'

  export default {
    data: () => ({
      valid: true,
      title: null,
      publishyear: null,
      alert: false,
      authors: [],
      categories: [],
      title: null,
      author: null,
      category: null,
      phouse: null,
      price: null,
      phouses:[],

      textRules: [
        v => !!v || 'Text is required'
      ],
    }),
    components: {

    },
    created: function () {
      var that = this;
      axios.get('authors/GetAuthors').then(function (response) {
        console.log(response.data.payload)
        that.authors = response.data.payload;
      })

      axios.get('categories/GetCategories').then(function (response) {
        console.log(response.data.payload)
        that.categories = response.data.payload;
      })

      axios.get('publishinghouses/GetAll').then(function (response) {
        console.log(response.data.payload)
        that.phouses = response.data.payload;
      })
    },
    methods: {
      submit() {
        var that = this;
        if (this.$refs.form.validate()) {
          axios.post('books/AddBook', {
            title: this.title,
            category: this.category,
            authors: this.author,
            publishinghouse: this.phouse,
            publishmentYear: this.publishyear,
            price: this.price,

          }).then(function (response) {
            if (response.data.payload) {
              console.log(response);
              that.user = response.data.payload;
            } else
              that.alert = true;
          });
        }
      },
    }
  }
</script>
<style scoped>
  .dialog {
    padding-top: 15px;
    background-color: rgba(0,0,0,0.9);
  }

  .dialog-card {
    padding-top: 30px;
    display: grid;
    justify-items: center;
  }

  .v-text-field {
    width: 100%;
    max-width: 400px;
  }

</style>
