<template>
  <div id="app">

      <v-footer dark
                fixed
                height="auto">
        <v-card class="flex"
                flat
                tile>
          <v-card-title class="grey darken-1">
            <strong class="subheading">{{day}}</strong>

            <v-spacer></v-spacer>

            <v-btn v-for="icon in icons"
                   :key="icon"
                   class="mx-3"
                   dark
                   icon>
              <v-icon size="24px">{{ icon }}</v-icon>
            </v-btn>
          </v-card-title>

          <v-card-actions class="grey darken-4 justify-center">
            &copy;2019 — <strong>Bookstore</strong>
          </v-card-actions>
        </v-card>
      </v-footer>
  </div>
</template>

<script>
  import axios from 'axios'

  export default {
    data: () => ({
      day:'',
      icons: [
        'fab fa-facebook',
        'fab fa-twitter',
        'fab fa-google-plus',
        'fab fa-linkedin',
        'fab fa-instagram'
      ]
    }),
    created: function () {
      var that = this;
      axios.get("http://worldclockapi.com/api/json/utc/now").
        then(function (response) {
          that.day = response.data.dayOfTheWeek;
        })
    }
  }
</script>

<style scoped>
</style>
