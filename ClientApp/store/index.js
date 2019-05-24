import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

// TYPES
const MAIN_SET_COUNTER = 'MAIN_SET_COUNTER'
const MAIN_BOOK_STORAGE = 'MAIN_BOOK_STORAGE'

// STATE
const state = {
  counter: 1,
  cart: [],
}

// MUTATIONS
const mutations = {
  [MAIN_SET_COUNTER] (state, obj) {
    state.counter = obj.counter
  },

  [MAIN_BOOK_STORAGE](state, obj) {
    state.cart = obj.cart
  }
}

// ACTIONS
const actions = ({
  setCounter ({ commit }, obj) {
    commit(MAIN_SET_COUNTER, obj)
  },
  addBook({ commit }, obj) {
    commit(MAIN_BOOK_STORAGE, obj)
  }
})

export default new Vuex.Store({
  state,
  mutations,
  actions
})
