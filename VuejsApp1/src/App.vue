<template>
  <v-app>
    <!-- 導覽列 -->
    <v-app-bar :clipped-left="$vuetify.breakpoint.lgAndUp" color="primary" app elevate-on-scroll dark>
      <v-app-bar-nav-icon @click.stop="ui.drawer = !ui.drawer"></v-app-bar-nav-icon>
      <router-link :to="'/'">
        <v-img :src="require('@/assets/logo.svg')" height="48" width="44"></v-img>
      </router-link>
      <v-toolbar-title class="headline pl-2">
        <span class="font-weight-bold">我的Vuetify專案 - {{ $route.name }}</span>
      </v-toolbar-title>
    </v-app-bar>
    <!-- 側欄 -->
    <v-navigation-drawer 
      :clipped="$vuetify.breakpoint.lgAndUp" 
      :dark="ui.darkTheme"
      v-model="ui.drawer"
      fixed
      app>
      <v-list expand shaped dense>
        <template v-for="item in ui.sidebars">
          <v-list-group
            v-if="item.children.length > 0"
            v-model="item.model"
            :key="item.text"
            prepend-icon='mdi-view-dashboard-outline'
            >
            <template v-slot:activator>
              <v-list-item-content>
                <v-list-item-title v-text="item.text"></v-list-item-title>
              </v-list-item-content>
            </template>
            <v-list-item v-for="(child, i) in item.children" :key="i" :to="child.link" exact >
              <v-list-item-icon>
                <v-icon v-text="child.icon"></v-icon>
              </v-list-item-icon>
              <v-list-item-content>
                <v-list-item-title class="subheading">{{ child.text }}</v-list-item-title>
              </v-list-item-content>
              <v-chip small color="red" dark v-if="child.chip && child.chip != '0'">
                {{ child.chip }}
              </v-chip>
            </v-list-item>
          </v-list-group>
        </template>
      </v-list>
    </v-navigation-drawer>
    <v-content app id="main" >
      <v-container fluid grid-list-md>
        <router-view ></router-view>
      </v-container>
    </v-content>
  </v-app>
</template>

<script>
export default {
  name: "app",
  data() {
    return {
      ui:{
        drawer: null,
        sidebars: [
          { 
            text: '功能清單',
            model: true,
            icon: 'mdi-chevron-up',
            'iconAlt': 'mdi-chevron-down',
            children: [
              { link:'/students', text: '學生編輯' },
              { link:'/classes', text: '課程編輯' },
              { link:'/choose', text: '選課' }
            ]
          }
        ]
      }
    }
  },
}
</script>

<style>
/* 本段落用來複寫 Vuetify 指定字形，避免整個網站都用新細明體 */
#app {
  font-family: "Microsoft Jhenghei", sans-serif !important;
}
#app .display-4 {
  font-family: "Microsoft Jhenghei", sans-serif !important;
}
#app .display-2,#app .display-3 {
  font-family: "Microsoft Jhenghei", sans-serif !important;
}
#app .display-1,#app .headline {
  font-family: "Microsoft Jhenghei", sans-serif !important;
}
#app .title {
  font-family: "Microsoft Jhenghei", sans-serif !important;
}
</style>