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
      <search-bar  style="margin-top:0px;" />
      <v-spacer />
      <v-btn icon>
        <router-link 
                     :to="'/cart'">
          <v-badge bottom
                   overlap
                   color="#12d483">
            <span slot="badge">
              {{currentCart.length}}
            </span>
            <v-icon>shopping_cart</v-icon>
          </v-badge>
        </router-link>
      </v-btn>
      <v-menu bottom
              left
              class="hidden-md-and-up"
              transition="slide-y-reverse-transition">
        <v-btn icon
               large
               slot="activator">
          <v-icon>menu</v-icon>
        </v-btn>
        <v-list class="hidden-md-and-up" dark>
          <v-list-tile v-for="(item, title) in items"
                       class="tile"
                       :key="title"
                       @click="handle_function_call(item.method)"
                       v-if="isLogged">
            <router-link :to="item.path">{{ item.title }}</router-link>
          </v-list-tile>
          <login-modal v-if="!isLogged"></login-modal>
          <register-modal v-if="!isLogged"></register-modal>
        </v-list>
      </v-menu>
      <login-modal class="hidden-sm-and-down"
                   v-if="!isLogged"></login-modal>
      <register-modal class="hidden-sm-and-down"
                      v-if="!isLogged"></register-modal>
      <v-btn @click="logout"
             color="#FFB300"
             outline
             class="modal-button hidden-sm-and-down"
             round
             v-if="isLogged">Logout</v-btn>
    </v-toolbar>
  </div>
</template>
<script>
  import { routes } from '../router/routes'
  import { mapActions, mapState } from 'vuex'
  import axios from 'axios'
  import Searchbar from './searchbar'
  import router from '../router/index'
  import loginForm from './login-form'
  import registerForm from './register-form'

  export default {
    components: {
      'search-bar': Searchbar,
      'register-modal': registerForm,
      'login-modal': loginForm,
    },
    data() {
      return {
        routes,
        isLogged: false,
        collapsed: true,
        items: [
          { title: "Your account", path: "/user/" + this.userId, method: "" },
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
      ...mapState({
        currentCart: state => state.cart
      })
    },
    created: function () {
      var that = this;
      if (this.$cookies.get('UserCookie')) {
        axios.defaults.headers = { 'Authorization': `Bearer ${$cookies.get('UserCookie').token}` }
        that.isLogged = true;
        that.userId = $cookies.get('UserCookie').id;
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
        $cookies.remove('UserCookie');
        this.$emit('successLogout');
        router.push('/')
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
