## Vue + Vuetify + ASP.Net Core 3.1 專案

### VuejsApp1

1. 套件主要包含  
   Vue 2  
   Vue Router 3  
   Vuetify 2  
   axios

### goodarc-homework

1. 套件主要包含：  
   Dapper  
   Dapper.Contrib  
   Dapper.SqlBuilder  
   Microsoft.Data.SqlClient  

## 程式清單

| App | 說明 |
| --- | ---- |
| goodarc-homework | ASP.NET Core 後端 |
| VuejsApp1 | Vue 前端 |
| GoodarcDB | 資料庫 POCO |
| SQL | 建立資料庫資料表的語法、測試資料 |

## 開發環境

- Visual Studio 2019 16.11.5
- VS Code
- SQL Server 2019 LocalDB
- Nodejs 14.18.1
- Vue CLI 4.5.8

### 執行方法
 1. 使用語法建立資料庫
 2. 到 goodarc-homework/appsettings.Development.json 修改連線字串
 3. 執行 VuejsApp1/Build.bat 
   build 前端網頁並複製到 ASP.NET 專案
 4. 用 Visual Studio 啟動後端程式