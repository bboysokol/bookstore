<template>
  <v-dialog width="500"
            dark
            v-model="dialog">
    <v-btn slot="activator"
           color="#FFB300"
           class="modal-button"
           outline
           round>
      Sign In
    </v-btn>
    <v-card class="dialog">
      <v-form ref="form" v-model="valid" lazy-validation>

        <v-card-title class="headline amber darken-1"
                      primary-title>
          Login
          <v-spacer></v-spacer>
          <v-btn icon dark @click="dialog = false">
            <v-icon>close</v-icon>
          </v-btn>
        </v-card-title>
        <v-card-text class="dialog-card">
          <v-text-field v-model="username"
                        :rules="userRules"
                        label="Username"
                        required
                        color="#FFB300"
                        prepend-inner-icon="person"
                        outline>
          </v-text-field>

          <v-text-field v-model="password"
                        type="password"
                        :rules="passRules"
                        label="Password"
                        required
                        outline
                        color="#FFB300"
                        prepend-inner-icon="lock"
                        @keyup.enter="submit">
          </v-text-field>
          <v-btn @click="submit"
                 color="#FFB300"
                 outline
                 class="modal-button"
                 round>Sign In</v-btn><br />
          <register-form></register-form>
        </v-card-text>
      </v-form>
    </v-card>
  </v-dialog>
</template>

<script>
  import axios from 'axios'
  import RegisterForm from './register-form'
  import router from '../router/index'

  export default {
    data: () => ({
      valid: true,
      alert: false,
      dialog:false,
      password: '',
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
              $cookies.set('UserCookie', that.user)
              axios.defaults.headers = { 'Authorization': `Bearer ${that.user}` }
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
  .dialog {
    padding-top:15px;
    background-color: rgba(0,0,0,0.9);
  }

  .dialog-card {
    padding-top:30px;
    display: grid;
    justify-items: center;
  }

  .v-text-field {
    width: 100%;
    max-width: 400px;
  }
</style>
