import Vue from 'vue'
import VueRouter from 'vue-router'
import { routes } from './routes'

Vue.use(VueRouter)

let router = new VueRouter({
  mode: 'history',
  routes
})

router.beforeEach((to, from, next) => {
  if (to.matched.some(record => record.meta.requiresAuth)) {
    if ($cookies.get('UserCookie') == null) {
      next({
        path: '/',
        params: { nextUrl: to.fullPath }
      })
    } else {
      next()
    }
  }
  else if (to.matched.some(record => record.meta.isAdmin)) {
    if ($cookies.get('UserCookie') == null) {
      next({
        path: '/',
        params: { nextUrl: to.fullPath }
      })
    } else {
      if ($cookies.get('UserCookie').isAdmin) {
        next()
      }else
        next({
          path: '/',
          params: { nextUrl: to.fullPath }
        })
    }
  }
  else if (to.matched.some(record => record.meta.guest)) {
    if ($cookies.get('UserCookie') == null) {
      next()
    }
    else {
      next()
    }
  } else {
    next()
  }
})

export default router
