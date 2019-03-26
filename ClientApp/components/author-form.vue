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
    <v-text-field v-model="name"
                  :rules="nameRules"
                  label="Name"
                  required
                  color="#12d483"
                  prepend-inner-icon="person"
                  outline
                  >
    </v-text-field>
    <v-text-field v-model="surname"
                  :rules="nameRules"
                  label="Surname"
                  required
                  outline
                  color="#12d483"
                  prepend-inner-icon="person"
                  @keyup.enter="submit">
    </v-text-field>

    <v-btn @click="submit"
           color="#12d483"
           outline
           round>Add Author</v-btn><br />
  </v-form>
</template>

<script>
  import axios from 'axios'

  export default {
    data: () => ({
      valid: true,
      alert: false,
      name: '',
      nameRules: [
        v => !!v || 'Name and Surname is required'
      ],
      surname: '',
    }),
    methods: {
      submit() {
        var that = this;
        if (this.$refs.form.validate()) {
          axios.post('authors/AddAuthor', {
            Name: this.name,
            Surname: this.surname
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

<style>
</style>
