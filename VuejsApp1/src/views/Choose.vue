<template>
  <div class="home">
    <h1>{{ msg }}</h1>
    <p>
      Welcome to your new single-page application, built with
      <a href="https://vuejs.org" target="_blank">Vue.js</a>.
    </p>
  </div>
</template>

<script>
  export default {
    props: {
      msg: String,
    },
  }
</script>
