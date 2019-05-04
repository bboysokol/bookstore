<template>
  <div>
    <v-toolbar dark app>
      <v-toolbar-items v-for="(route, index) in visibleRoutes" :key="index">
        <v-btn flat
               :to="route.path"
               active-class="active">
          <span>{{route.display}}</span>
        </v-btn>
      </v-toolbar-items>
      <v-spacer />
      <search-bar style="margin-top:0px;" />
      <v-spacer />
      
        <v-btn icon>
          <v-badge bottom
                   overlap
                   color="#12d483">
            <span slot="badge">
              2
            </span>
            <v-icon>shopping_cart</v-icon>
          </v-badge>
        </v-btn>
      <v-menu bottom
              left
              transition="slide-y-reverse-transition"
              >
        <v-btn icon
               large
               slot="activator">
          <v-icon>menu</v-icon>
        </v-btn>
        <v-list dark>
          <v-list-tile v-for="(item, title) in items"
                       class="tile"
                       :key="title"
                       @click="handle_function_call(item.method)">
            <router-link :to="item.path">{{ item.title }}</router-link>
          </v-list-tile>
        </v-list>
      </v-menu>
    </v-toolbar>
  </div>
</template>
<script>
  import { routes } from '../router/routes'
  import axios from 'axios'
  import Searchbar from './searchbar'
  import router from '../router/index'

  export default {
    components: {
      'search-bar': Searchbar
    },
    data() {
      return {
        routes,
        userState: false,
        collapsed: true,
        items: [
          { title: "Your account", path: "/user/" + this.userId, method: "" },
          { title: "Find user", path: "/search", method: "" },
          { title: "Logout", path: "", method: "logout" },
        ]
      }
    },
    watch: {
      newNotification: function (newVal, oldVal) {
        this.showNotifications();
      }
    },
    computed: {
      visibleRoutes: function () {
        return this.routes.filter(item => { return item.visible });
      },
    },
    created: function () {
      var that = this;
      if (this.$cookies.get('IsLoggedCookie')) {
        axios.defaults.headers = { 'Authorization': `Bearer ${$cookies.get('IsLoggedCookie').token}` }
        that.userState = true;
        that.userId = $cookies.get('IsLoggedCookie').id;
        axios.get('notifications/getnotifications/' + $cookies.get('IsLoggedCookie').id)
          .then(function (data) {
            that.notifications = data.data.payload.reverse();
            console.log(data.data.payload);
          })
      }
    },
    methods: {
      toggleCollapsed: function (event) {
        this.collapsed = !this.collapsed
      },
      handle_function_call(function_name) {
        if (function_name)
          this[function_name]()
      },
      logout() {
        axios.post('authentication/logout')
          .then(function (response) {
            console.log(response)
          });
        $cookies.remove('IsLoggedCookie');
        this.$emit('successLogout');
        router.push('/login')
      },
    }
  }
</script>

<style scoped>
  a, a:hover {
    text-decoration: none !important;
    color: white;
  }

  .v-btn {
    font-size: 18px;
  }

  .active {
    text-decoration: none;
    border-bottom: 4px solid;
    border-color: #12d483;
  }

  .v-toolbar__side-icon {
    width: 40px;
    display: none;
  }
</style>
