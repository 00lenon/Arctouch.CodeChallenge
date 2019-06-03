import "./assets/css/global.css";

import Vue from 'vue'
import App from './App.vue'

import DetalhesDoFilme from './components/DetalhesDoFilme/DetalhesDoFilme.vue'
import ListagemDeFilmes from './components/ListagemDeFilmes/ListagemDeFilmes.vue'
import Filme from './components/Filmes/Filme.vue'

import VueRouter from 'vue-router'
Vue.use(VueRouter);

import axios from 'axios'
import VueAxios from 'vue-axios'
Vue.use(VueAxios, axios)

Vue.use(require('vue-moment'));

import { library } from '@fortawesome/fontawesome-svg-core'
import { faUserSecret } from '@fortawesome/free-solid-svg-icons'
import { faSpinner, faThumbsUp, faThumbsDown } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'


library.add(faSpinner, faThumbsUp, faThumbsDown)


library.add(faUserSecret)

Vue.component('font-awesome-icon', FontAwesomeIcon)

Vue.component("Filme", require('./components/Filmes/Filme.vue').default);

const routes = [
    { path: '/', component: ListagemDeFilmes },
    { path: '/filme/:id', component: DetalhesDoFilme }
  ];

const router = new VueRouter({
  mode: 'history',
  routes
});

const app = new Vue({router})
    .$mount('#container');