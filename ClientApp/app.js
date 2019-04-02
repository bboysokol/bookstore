import Vue from 'vue'
import axios from 'axios'
import router from './router/index'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from 'components/app-root'
import { FontAwesomeIcon } from './icons'
import Vuetify from 'vuetify'
import { Configuration } from './Configuration'
import VueCookies from 'vue-cookies'
import 'vuetify/dist/vuetify.min.css'

Vue.use(VueCookies)
VueCookies.config('1d')
VueCookies.set('theme', 'default');
VueCookies.set('hover-time', '1s');

Vue.use(Vuetify)
Vue.component('icon', FontAwesomeIcon)

Vue.prototype.$http = axios
axios.defaults.baseURL = Configuration.ApiPath
sync(store, router)


const app = new Vue({
  store,
  router,
  ...App
})

export {
  app,
  router,
  store
}
