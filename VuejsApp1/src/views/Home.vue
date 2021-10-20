<template>
  <div class="home">
    <h1>{{ msg }}</h1>
    <p>
      請從左側清單選擇功能
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
