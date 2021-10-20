<template>
  <v-card flat>
    <v-data-table
      :headers="ui.headers"
      :items="results"
      hide-default-footer
    >
      <template v-slot:item.cb_startDate="{ item }">
        {{ minguo(item.cb_startDate) }}
      </template>
      <template v-slot:item.cb_stopDate="{ item }">
        {{ minguo(item.cb_stopDate) }}
      </template>
      <template v-slot:item.action="{ item }">
        <v-btn
          depressed
          color="primary"
          title="編輯"
          @click="setStop(item)"
          v-if="!item.cb_stopDate"
          >
          <v-icon left>mdi-pencil</v-icon>
          編輯</v-btn>
        <v-btn
          depressed
          color="error"
          title="刪除"
          @click="showModal1(item.cb_title, item.cb_content)"
          >
          <v-icon left>mdi-delete</v-icon>
          刪除</v-btn>
      </template>
    </v-data-table>
  </v-card>
</template>

<script>
  export default {
    props: {
      msg: String,
    },
    data() {
      return{
        ui: {
          headers: [
            { value: 'st_id', text: '學號' },
            { value: 'st_name', text: '姓名' },
            { value: 'st_birthday', text: '生日' },
            { value: 'st_email', text: 'email' },
            { value: 'action', text: '操作', sortable: false },
          ],
        },
        results: []
      }
    },
    mounted(){
      this.get()
    },
    methods: {
      get(){
        this.$ajax('./students/get').then((res) => {
            this.results = res.data
          })
      }
    }
  }
</script>
