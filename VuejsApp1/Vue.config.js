module.exports = {
  "publicPath": "./",
  "productionSourceMap": false,
  "devServer": {
    "port": 8080,
    "proxy": {
      "/": {
        "target": "http://localhost:25760/",
        "ws": false,
        "changeOrigin": true
      }
    }
  },
  "pages": {
    "index": {
      "entry": "src/main.js",
      "template": "public/index.html",
      "filename": "index.html",
      "title": "我的Vuetify專案",
      "chunks": [
        "chunk-vendors",
        "chunk-common",
        "index"
      ]
    }
  },
  "transpileDependencies": [
    "vuetify"
  ]
}