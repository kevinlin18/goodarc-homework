<template>
  <v-container fluid>
    <v-row dense>
      <!-- 查詢區塊 -->
      <v-col cols="12">
        <v-card outlined class="title">
          <v-container fluid>
            <v-row dense>
              <v-col cols="3">
                學生
              </v-col>
              <v-col cols="3">
                <v-select
                  dense
                  outlined
                  hide-details
                  :items="drop.students"
                  v-model="search.st_id"
                />
              </v-col>
              <v-col cols="6">
              </v-col>
              <v-col cols="12">
                <v-checkbox v-for="(elem,index) in drop.classes"
                  hide-details
                  :key="index"
                  :label="elem.text"
                  :value="elem.value"
                  v-model="search.cl_ids"
                />
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
                  :disabled="search.st_id == null"
                  v-else
                  >
                  新增</v-btn>
                <v-btn
                  depressed
                  dark
                  color="green"
                  @click="clearSearch()"
                  >
                  清除</v-btn>
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
                @click="editItem(item.st_id)"
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
    data() {
      return{
        ui: {
          editing: false,
          headers: [
            { value: 'st_id', text: '學號' },
            { value: 'cl_names', text: '課程' },
            { value: 'action', text: '操作', sortable: false },
          ],
        },
        drop:{
          classes:[],
          students:[]
        },
        search:{
          st_id: null,
          cl_ids: [],
        },
        results: []
      }
    },
    mounted(){
      this.initial()
      this.get()
    },
    methods: {
      initial(){
        this.$ajax('./choose/initial').then((res) => {
          this.drop = res.data
        })
      },
      clearSearch(){
        this.search = {
          st_id: null,
          cl_ids: [],
        }
        this.ui.editing = false
        this.initial()
        this.get()
      },
      editItem(st_id){
        let model = {
          st_id: st_id
        }
        this.$ajax('./choose/getStudentClass', model).then((res) => {
          this.search.st_id = res.data.st_id
          this.search.cl_ids = res.data.cl_ids
          this.drop.students = res.data.students
        })
        this.ui.editing = true
      },
      get(){
        this.$ajax('./choose/get').then((res) => {
          this.results = res.data
        })
      },
      createItem(){
        this.$ajax('./choose/create', this.search).then((res) => {
          if (!res.data.success){
            alert('error!')
          } else {
            this.clearSearch()
          }
        })
      },
      updateItem(){
        this.$ajax('./choose/update', this.search).then((res) => {
          if (!res.data.success){
            alert('error!')
          } else {
            this.clearSearch()
          }
        })
      },
      deleteItem(model){
        this.$ajax('./choose/delete', model).then((res) => {
          if (!res.data.success){
            alert('error!')
          } else {
            this.clearSearch()
          }
        })
      }
    }
  }
</script>
