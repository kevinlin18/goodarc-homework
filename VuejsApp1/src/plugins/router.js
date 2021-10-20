import Vue from 'vue'
import Router from 'vue-router'
import home from '@/views/Home'
Vue.use(Router)

const router = new Router({
  scrollBehavior() {
    return { x: 0, y: 0 }
  },
  routes: [
    {
      path: '/',
      name: '首頁',
      component: home
    },
    {
      path: '/classes',
      name: '課程編輯',
      component: () => import('@/views/Classes')
    },
    {
      path: '/students',
      name: '學生編輯',
      component: () => import('@/views/Students')
    },
    {
      path: '/Choose',
      name: '選課',
      component: () => import('@/views/Choose')
    },
    {
      path: '/*',
      name: '404',
      component: home
    }
  ]
})

router.beforeEach((to, from, next) => {
  if (to.path != "/" && to.name && to.name != '404') {
    document.title = to.name + ' | 我的Vuetify專案'
    let search = {}
    search.event_page = to.path
  } else {
    document.title = '我的Vuetify專案'
  }
  next()
})
export default router;
