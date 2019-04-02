<template>
  <v-dialog width="500"
            dark
            v-model="dialog">
    <v-btn slot="activator"
           color="#12d483"
           class="modal-button"
           outline
           round>
      Sign Up
    </v-btn>
    <v-card class="dialog">
      <v-form ref="form" v-model="valid" lazy-validation>

        <v-card-title class="headline green accent-3"
                      primary-title>
          Register your account on our website!
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
                        color="#12d483"
                        outline
                        prepend-inner-icon="person">
          </v-text-field>
          <v-text-field v-model="email"
                        :rules="emailRules"
                        label="E-mail"
                        required
                        color="#12d483"
                        outline
                        prepend-inner-icon="email">
          </v-text-field>
          <v-text-field v-model="password"
                        :rules="passRules"
                        type="password"
                        label="Password"
                        required
                        color="#12d483"
                        outline
                        prepend-inner-icon="lock"
                        hint="At least 6 characters, 1 lowercase, 1 uppercase, 1 number and 1 special character">
          </v-text-field>
          <v-text-field v-model="ConfirmedPassword"
                        :rules="passRules"
                        type="password"
                        label="Confirm password"
                        required
                        color="#12d483"
                        outline
                        prepend-inner-icon="lock">
          </v-text-field>
          <div style="padding-top:20px;">
            <v-btn @click="submit" color="#12d483"
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
            AvatarUrl: this.avatarUrl,
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
    background-color: rgba(0,0,0,0.9);
  }

  .dialog-card {
    display: grid;
    justify-items: center;
  }

  .dialog-avatar {
    width: 75%;
  }
</style>
