<template>
  <v-container fluid>
    <v-row dense>
      <!-- 查詢區塊 -->
      <v-col cols="12">
        <v-card outlined class="title">
          <v-container fluid>
            <v-row dense>
              <v-col cols="3">
                學號
              </v-col>
              <v-col cols="3">
                <v-text-field
                  v-model="search.st_id"
                  outlined
                  dense
                  hide-details
                ></v-text-field>
              </v-col>
              <v-col cols="3">
                姓名
              </v-col>
              <v-col cols="3">
                <v-text-field
                  v-model="search.st_name"
                  outlined
                  dense
                  hide-details
                ></v-text-field>
              </v-col>
              <v-col cols="3">
                Email
              </v-col>
              <v-col cols="3">
                <v-text-field
                  v-model="search.st_email"
                  outlined
                  dense
                  hide-details
                ></v-text-field>
              </v-col>
              <v-col cols="3">
                生日
              </v-col>
              <v-col cols="3">
                <v-text-field
                  v-model="search.st_birthday"
                  outlined
                  dense
                  hide-details
                ></v-text-field>
              </v-col>
              <v-col cols="12" class="text-center">
                <v-btn
                  depressed
                  color="primary"
                  @click="updateItem()"
                  v-if="ui.editing"
                  >
                  儲存</v-btn>
                <v-btn
                  depressed
                  color="primary"
                  @click="createItem()"
                  v-else
                  >
                  新增</v-btn>
              </v-col>
            </v-row>
          </v-container>
        </v-card>
      </v-col>
    </v-row>
    <v-row dense>
      <v-col cols="12">
        <v-card flat>
          <v-data-table
            :headers="ui.headers"
            :items="results"
            hide-default-footer
          >
            <template v-slot:item.st_birthday="{ item }">
              {{ moment(item.st_birthday).format('YYYY-MM-DD') }}
            </template>
            <template v-slot:item.action="{ item }">
              <v-btn
                depressed
                color="primary"
                title="編輯"
                @click="editItem(item)"
                >
                <v-icon left>mdi-pencil</v-icon>
                編輯</v-btn>
              <v-btn
                depressed
                color="error"
                title="刪除"
                @click="deleteItem(item)"
                >
                <v-icon left>mdi-delete</v-icon>
                刪除</v-btn>
            </template>
          </v-data-table>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
  export default {
    props: {
      msg: String,
    },
    data() {
      return{
        ui: {
          editing: false,
          headers: [
            { value: 'st_id', text: '學號' },
            { value: 'st_name', text: '姓名' },
            { value: 'st_birthday', text: '生日' },
            { value: 'st_email', text: 'Email' },
            { value: 'action', text: '操作', sortable: false },
          ],
        },
        search:{
          st_id:'',
          st_name:'',
          st_email:'',
          st_birthday:'',
        },
        results: []
      }
    },
    mounted(){
      this.get()
    },
    methods: {
      clearSearch(){
        this.search = {
          st_id:'',
          st_name:'',
          st_email:'',
          st_birthday:'',
        }
        this.ui.editing = false
      },
      editItem(model){
        this.search = {
          st_id: model.st_id,
          st_name: model.st_name,
          st_email: model.st_email,
          st_birthday: this.moment(model.st_birthday).format('YYYY-MM-DD'),
        }
        this.ui.editing = true
      },
      get(){
        this.$ajax('./students/get').then((res) => {
          this.results = res.data
        })
      },
      createItem(){
        this.$ajax('./students/create', this.search).then((res) => {
          if (!res.data.success){
            alert('error!')
          }
          this.get()
          this.clearSearch()
        })
      },
      updateItem(){
        this.$ajax('./students/update', this.search).then((res) => {
          if (!res.data.success){
            alert('error!')
          }
          this.get()
          this.clearSearch()
        })
      },
      deleteItem(model){
        this.$ajax('./students/delete', model).then((res) => {
          if (!res.data.success){
            alert('error!')
          }
          this.get()
        })
      }
    }
  }
</script>
