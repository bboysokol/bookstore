<template>
  <div class="login-form">
    <v-form ref="form"
            v-model="valid"
            lazy-validation>
      <v-alert :value="alert"
               type="error"
               transition="scale-transition">
        "Username or password is incorrect"
      </v-alert>
      <v-label><h2 class="logo">Bookstore</h2> </v-label><br />
      <v-text-field v-model="username"
                    :rules="userRules"
                    label="Username"
                    required
                    color="#12d483"
                    prepend-inner-icon="person"
                    outline>
      </v-text-field>

      <v-autocomplete v-model="model"
                      :items="authors"
                      item-text="name"
                      item-value="id"
                      :label="`Author`"
                      outline
                      prepend-inner-icon="person">
      </v-autocomplete>

      <v-autocomplete v-model="model2"
                      :items="categories"
                      item-text="title"
                      item-value="id"
                      :label="`Category`"
                      outline
                      prepend-inner-icon="book">
      </v-autocomplete>

      <v-text-field v-model="password"
                    type="password"
                    :rules="passRules"
                    label="Password"
                    required
                    outline
                    color="#12d483"
                    prepend-inner-icon="lock"
                    @keyup.enter="submit">
      </v-text-field>
      <v-btn @click="submit"
             color="#12d483"
             outline
             class="modal-button"
             round>Sign In</v-btn><br />
      <register-form></register-form>
    </v-form>
  </div>
</template>

<script>
  import axios from 'axios'
  import RegisterForm from './register-form'

  export default {
    data: () => ({
      valid: true,
      alert: false,
      authors: [],
      categories: [],
      password: '',
      model: null,
      model2: null,
      passRules: [
        v => !!v || 'Password is required'
      ],
      username: '',
      userRules: [
        v => !!v || 'Username is required'
      ]
    }),
    components: {
      'register-form': RegisterForm
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
    },
    methods: {
      submit() {
        var that = this;
        if (this.$refs.form.validate()) {
          axios.post('authentication/logIn', {
            username: this.username,
            password: this.password
          }).then(function (response) {
            if (response.data.payload) {
              console.log(response);
              that.user = response.data.payload;
              $cookies.set('IsLoggedCookie', that.user)
              axios.defaults.headers = { 'Authorization': `Bearer ${that.user}` }
              that.$emit('successLogin');
              router.push('/')
            } else
              that.alert = true;
          });
        }
      },
    }
  }
</script>
<style scoped>
  .v-form {
    padding-bottom: 80px;
    padding-top: 50px;
  }
  .v-text-field {
    width: 100%;
    max-width:400px;
  
  }
  .logo {
    color: #12d483;
    padding: 40px;
  }

</style>
