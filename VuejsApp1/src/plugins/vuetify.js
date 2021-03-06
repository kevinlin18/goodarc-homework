import Vue from 'vue';
import Vuetify from 'vuetify/lib';
import '@mdi/font/css/materialdesignicons.css'
import zhHant from 'vuetify/es5/locale/zh-Hant'

Vue.use(Vuetify);

export default new Vuetify({
  // theme: {
  //   themes: {
  //     light: {
  //       primary: '#ee44aa',
  //       secondary: '#424242',
  //       accent: '#82B1FF',
  //       error: '#FF5252',
  //       info: '#2196F3',
  //       success: '#4CAF50',
  //       warning: '#FFC107'
  //     },
  //   },
  // },
  lang: {
    locales: { zhHant },
    current: 'zhHant'
  },
  icons: {
    iconfont: 'mdi',
  },
});
