<template>
  <v-form ref="form"
          v-model="valid"
          lazy-validation>
    <v-alert :value="alert"
             type="error"
             transition="scale-transition">
      "Username or password is incorrect"
    </v-alert>
    <v-label>Add new author</v-label><br />
    <v-text-field v-model="title"
                  :rules="titleRules"
                  label="Title"
                  required
                  color="#12d483"
                  prepend-inner-icon="person"
                  outline
                  >
    </v-text-field>
    <v-btn @click="submit"
           color="#12d483"
           outline
           round>Add Category</v-btn><br />
  </v-form>
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
          axios.post('publishinghouses/add', {
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
</style>
