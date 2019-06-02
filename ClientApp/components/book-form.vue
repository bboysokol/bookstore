<template>
  <v-dialog width="500"
            dark
            v-model="dialog">
    <v-btn slot="activator"
           color="black"
           class="modal-button"
           outline>
      Add book
    </v-btn>
    <v-card class="dialog">
      <v-form ref="form"
              v-model="valid"
              lazy-validation>

        <v-card-title class="headline amber darken-1"
                      primary-title>
          New book
          <v-spacer></v-spacer>
          <v-btn icon dark @click="dialog = false">
            <v-icon>close</v-icon>
          </v-btn>
        </v-card-title>
        <v-alert :value="alert.state"
                 :type="alert.type"
                 transition="scale-transition">
          {{alert.content}}
        </v-alert>
        <v-card-text class="dialog-card">
          <v-text-field v-model="title"
                        :rules="textRules"
                        label="Title"
                        required
                        color="#FFB300"
                        prepend-inner-icon="title"
                        outline>
          </v-text-field>

          <v-autocomplete v-model="author"
                          :items="authors"
                          item-text="name"
                          item-value="id"
                          :label="`Author`"
                          color="#FFB300"
                          outline
                          prepend-inner-icon="person">
          </v-autocomplete>

          <v-autocomplete v-model="category"
                          :items="categories"
                          item-text="title"
                          item-value="id"
                          color="#FFB300"
                          :label="`Category`"
                          outline
                          prepend-inner-icon="book">
          </v-autocomplete>

          <v-autocomplete v-model="phouse"
                          :items="phouses"
                          item-text="title"
                          item-value="id"
                          color="#FFB300"
                          :label="`Publishing House`"
                          outline
                          prepend-inner-icon="book">
          </v-autocomplete>
          <v-text-field v-model="publishyear"
                        :label="`Publishment Year`"
                        outline
                        color="#FFB300"
                        prepend-inner-icon="book">
          </v-text-field>
          <v-text-field v-model="price"
                        :label="`Price`"
                        outline
                        color="#FFB300"
                        prepend-inner-icon="book">
          </v-text-field>
          <uploader @fileUploaded="photoSet"></uploader>

          <v-btn @click="submit"
                 color="#FFB300"
                 outline
                 class="modal-button"
                 round>Submit</v-btn>
        </v-card-text>
      </v-form>
    </v-card>
  </v-dialog>
</template>

<script>
  import axios from 'axios'
  import { getCategories } from '../services/categories'
  import { getAuthors } from '../services/authors'
  import { getPublishingHouses } from '../services/publishinghouses'
  import uploader from '../components/upload-file'

  export default {
    data: () => ({
      alert: { state: false, type: "error", content: '' },
      valid: true,
      title: null,
      publishyear: null,
      alert: false,
      authors: [],
      dialog: false,
      categories: [],
      title: null,
      author: null,
      category: null,
      phouse: null,
      price: null,
      ImgUrl: '',
      phouses: [],

      textRules: [
        v => !!v || 'Text is required'
      ],
    }),
    components: {
      'uploader': uploader
    },
    created: function () {
      getCategories().then(response => this.categories = response);
      getAuthors().then(response => this.authors = response);
      getPublishingHouses().then(response => this.phouses = response);
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
            img: this.ImgUrl,
          }).then(function (response) {
            if (response.data.successful) {
              that.alert = { state: true, type: "success", content: "You have successfully added book!" }
            } else
              that.alert = { state: true, type: "error", content: "Something goes wrong! Try again" }
          });
        }
      },
      photoSet(fileUrl) {
        this.ImgUrl = fileUrl;
      }
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
