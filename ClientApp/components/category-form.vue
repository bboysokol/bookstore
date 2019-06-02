<template>
  <v-dialog width="500"
            dark
            v-model="dialog">
    <v-btn slot="activator"
           color="black"
           class="modal-button"
           dark
   >
      Add category
    </v-btn>
    <v-card class="dialog">
      <v-form ref="form"
              v-model="valid"
              lazy-validation>
        <v-card-title class="headline amber darken-1"
                      primary-title>
          New category
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
                        :rules="titleRules"
                        label="Title"
                        required
                        color="#FFB300"
                        prepend-inner-icon="person"
                        outline>
          </v-text-field>
          <v-btn @click="submit"
                 color="#FFB300"
                 outline
                 round>Add Category</v-btn>
          </v-card-text>
      </v-form>
    </v-card>
  </v-dialog>
</template>

<script>
  import axios from 'axios'

  export default {
    data: () => ({
      valid: true,
      alert: false,
      title: '',
      titleRules: [
        v => !!v || 'Title is required'
      ],
    }),
    methods: {
      submit() {
        var that = this;
        if (this.$refs.form.validate()) {
          axios.post('categories/add', {
            NewTitle: this.title
          }).then(function (response) {
            if (response.data.successful) {
              console.log(response.data);
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
