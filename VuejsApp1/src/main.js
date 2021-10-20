import 'core-js/stable'
import 'regenerator-runtime/runtime'
import 'intersection-observer'

import Vue from 'vue';
import router from './plugins/router'
import App from './App.vue';
import vuetify from './plugins/vuetify';

// axios
import axios from 'axios'
Vue.prototype.$ajax= axios.post

Vue.config.productionTip = false;

new Vue({
  router,
  render: h => h(App),
  vuetify,
  created() {
    //讓IE11可響應router
    if ('-ms-scroll-limit' in document.documentElement.style
      && '-ms-ime-align' in document.documentElement.style) { // detect it's IE11
      window.addEventListener("hashchange", () => {
        var currentPath = window.location.hash.slice(1);
        if (this.$route.path !== currentPath) {
          this.$router.push(currentPath)
        }
      }, false)
    }
  }
}).$mount('#app');
