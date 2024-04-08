import { createStore, createLogger } from 'vuex'

// Defina o estado como um objeto
const state = {
  user: {
    nome: '',
    login: '',
    perfil: [],
    token: ''
  }
}

// Crie uma nova instância de store Vuex
const store = createStore({
  state,
  mutations: {
    increment(state) {
      state.count++
    }
  },
  plugins: process.env.NODE_ENV !== 'production'
    ? [createLogger()]
    : []
})

export default store
