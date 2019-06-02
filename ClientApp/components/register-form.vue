<template>
  <v-dialog width="500"
            dark
            v-model="dialog">
    <v-btn slot="activator"
           color="#FFB300"
           class="modal-button"
           outline
           round>
      Sign Up
    </v-btn>
    <v-card class="dialog">
      <v-form ref="form"
              v-model="valid"
              lazy-validation>

        <v-card-title class="headline amber darken-1"
                      primary-title>
          Register!
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
          <v-text-field v-model="username"
                        label="Username"
                        :rules="userRules"
                        required
                        color="#FFB300"
                        outline
                        prepend-inner-icon="person">
          </v-text-field>
          <v-text-field v-model="name"
                        label="Name"
                        :rules="dataRules"
                        required
                        color="#FFB300"
                        outline
                        prepend-inner-icon="person">
          </v-text-field>
          <v-text-field v-model="surname"
                        label="Surname"
                        :rules="dataRules"
                        required
                        color="#FFB300"
                        outline
                        prepend-inner-icon="person">
          </v-text-field>
          <v-text-field v-model="postcode"
                        label="Postcode"
                        :rules="dataRules"
                        required
                        color="#FFB300"
                        outline
                        prepend-inner-icon="person">
          </v-text-field>
          <v-text-field v-model="street"
                        label="Street"
                        :rules="dataRules"
                        required
                        color="#FFB300"
                        outline
                        prepend-inner-icon="person">
          </v-text-field>
          <v-text-field v-model="housenumber"
                        label="House number"
                        :rules="dataRules"
                        required
                        color="#FFB300"
                        outline
                        prepend-inner-icon="person">
          </v-text-field>
          <v-text-field v-model="apartamentnumber"
                        label="Apartament number"
                        required
                        color="#FFB300"
                        outline
                        prepend-inner-icon="person">
          </v-text-field>
          <v-text-field v-model="email"
                        :rules="emailRules"
                        label="E-mail"
                        required
                        color="#FFB300"
                        outline
                        prepend-inner-icon="email">
          </v-text-field>
          <v-text-field v-model="password"
                        :rules="passRules"
                        type="password"
                        label="Password"
                        required
                        color="#FFB300"
                        outline
                        prepend-inner-icon="lock"
                        hint="At least 6 characters, 1 lowercase, 1 uppercase, 1 number and 1 special character">
          </v-text-field>
          <v-text-field v-model="ConfirmedPassword"
                        :rules="passRules"
                        type="password"
                        @keyup.enter="submit"
                        label="Confirm password"
                        required
                        color="#FFB300"
                        outline
                        prepend-inner-icon="lock">
          </v-text-field>
          <div>
            <v-btn @click="submit" color="#FFB300"
                   round
                   class="modal-button"
                   outline :disable="!valid">submit</v-btn>
            <v-btn @click="clear" color="error"
                   round
                   class="modal-button"
                   outline>clear</v-btn>
          </div>
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
      dialog: false,
      username: '',
      name: '',
      surname: '',
      postcode: '',
      street: '',
      housenumber: '',
      apartamentnumber: '',
      alert: {
        state: false,
        type: "error",
        content: 'xd'
      },
      password: '',
      ConfirmedPassword: '',
      email: '',
      userRules: [
        v => !!v || 'Username is required',
        v => (v && v.length <= 10) || 'Username must be less than 10 characters',
      ],
      dataRules: [
        v => !!v || 'This field is required',
      ],
      passRules: [
        v => !!v || 'Password is required',
        v => (v && v.length > 6) || 'Password must be more than 6 characters',
        v => /[a-z]/g.test(v) || 'Password must contain 1 lowercase',
        v => /[A-Z]/g.test(v) || 'Password must contain 1 uppercase',
        v => /[0-9]/g.test(v) || 'Password must contain 1 number',
        v => /[.,!@#\$%\^&\*]/g.test(v) || 'Password must contain 1 special character',
      ],
      emailRules: [
        v => !!v || 'E-mail is required',
        v => /.+@.+/.test(v) || 'E-mail must be valid'
      ],
    }),
    methods: {
      submit() {
        var that = this;
        if (that.$refs.form.validate()) {
          axios.post('authentication/register', {
            username: this.username,
            password: this.password,
            email: this.email,
            name: this.name,
            surname: this.surname,
            postcode: this.postcode,
            street: this.street,
            housenumber: this.housenumber,
            apartamentnumber: this.apartamentnumber,
            ConfirmedPassword: this.ConfirmedPassword
          }).then(function (response) {
            console.log(response.data);
            if (!response.data.successful)
              that.alert = { state: true, type: "error", content: "Passwords must be the same!" }
            else
              that.alert = { state: true, type: "success", content: "You have successfully registered!" }
            that.clear();
          })
            .catch(function () {
              that.alert = { state: true, type: "error", content: "Something goes wrong! Try again" }
            });
        }
      },
      clear() {
        this.$refs.form.reset()
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
