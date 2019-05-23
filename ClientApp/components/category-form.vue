<template>
  <v-dialog width="500"
            dark
            v-model="dialog">
    <v-btn slot="activator"
           color="#FFB300"
           class="modal-button"
           outline
           round>
      Add category
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
        <v-label>Add new category</v-label><br />
        <v-text-field v-model="title"
                      :rules="titleRules"
                      label="Title"
                      required
                      color="#12d483"
                      prepend-inner-icon="person"
                      outline>
        </v-text-field>
        <v-btn @click="submit"
               color="#12d483"
               outline
               round>Add Category</v-btn><br />
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
