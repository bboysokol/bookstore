<template>
  <v-app>
    <div id="app" class="container-fluid">
      <link href="https://fonts.googleapis.com/icon?family=Material+Icons"
            rel="stylesheet">
      <div class="row">
          <nav-menu params="route: route"></nav-menu>
      </div>
      <div class="row">
        <div class="col-md-8 offset-md-2">
          <div class="row no-gutters">
            <div class="col">
              <side-nav></side-nav>
            </div>
            <div class="col-12 col-lg-10">
              <router-view></router-view>
            </div>
          </div>
        </div>
      </div>
    </div>
  </v-app>
</template>

<script>
  import NavMenu from './nav-menu'
  import SideNav from './side-nav'

    export default {
      components: {
        'nav-menu': NavMenu,
        'side-nav': SideNav,
      },

      data () {
        return {}
      }
    }
</script>

<style scoped>
  .offset-md-2 {
    margin-top: 78px;
  }
</style>
