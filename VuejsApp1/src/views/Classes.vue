<template>
  <v-container fluid>
    <v-row dense>
      <!-- 查詢區塊 -->
      <v-col cols="12">
        <v-card outlined class="title">
          <v-container fluid>
            <v-row dense>
              <v-col cols="3">
                課號
              </v-col>
              <v-col cols="3">
                <v-text-field
                  v-model="search.cl_id"
                  outlined
                  dense
                  hide-details
                ></v-text-field>
              </v-col>
              <v-col cols="3">
                課名
              </v-col>
              <v-col cols="3">
                <v-text-field
                  v-model="search.cl_name"
                  outlined
                  dense
                  hide-details
                ></v-text-field>
              </v-col>
              <v-col cols="3">
                學分數
              </v-col>
              <v-col cols="3">
                <v-text-field
                  v-model.number="search.cl_credit"
                  outlined
                  dense
                  hide-details
                ></v-text-field>
              </v-col>
              <v-col cols="3">
                上課地點
              </v-col>
              <v-col cols="3">
                <v-text-field
                  v-model="search.cl_location"
                  outlined
                  dense
                  hide-details
                ></v-text-field>
              </v-col>
              <v-col cols="3">
                講師名字
              </v-col>
              <v-col cols="3">
                <v-text-field
                  v-model="search.cl_teacher"
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
            { value: 'cl_id', text: '課號' },
            { value: 'cl_name', text: '課名' },
            { value: 'cl_credit', text: '學分數' },
            { value: 'cl_location', text: '上課地點' },
            { value: 'cl_teacher', text: '講師名字' },
            { value: 'action', text: '操作', sortable: false },
          ],
        },
        search:{
          cl_id:'',
          cl_name:'',
          cl_credit:0,
          cl_location:'',
          cl_teacher:'',
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
          cl_id:'',
          cl_name:'',
          cl_credit:0,
          cl_location:'',
          cl_teacher:'',
        }
        this.ui.editing = false
      },
      editItem(model){
        this.search = {
          cl_id: model.cl_id,
          cl_name: model.cl_name,
          cl_credit: model.cl_credit,
          cl_location: model.cl_location,
          cl_teacher: model.cl_teacher,
        }
        this.ui.editing = true
      },
      get(){
        this.$ajax('./classes/get').then((res) => {
          this.results = res.data
        })
      },
      createItem(){
        this.$ajax('./classes/create', this.search).then((res) => {
          if (!res.data.success){
            alert('error!')
          }
          this.get()
          this.clearSearch()
        })
      },
      updateItem(){
        this.$ajax('./classes/update', this.search).then((res) => {
          if (!res.data.success){
            alert('error!')
          }
          this.get()
          this.clearSearch()
        })
      },
      deleteItem(model){
        this.$ajax('./classes/delete', model).then((res) => {
          if (!res.data.success){
            alert('error!')
          }
          this.get()
        })
      }
    }
  }
</script>
