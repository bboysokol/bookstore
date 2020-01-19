<template>
  <div>
    <slider></slider><br />
    <top-books></top-books>   
  </div>
  
</template>
<script>
  import Slider from "components/slider"
  import TopBooks from "components/topbooks"
  export default {
    data() {
      return {}
    },
    components: {
      'top-books': TopBooks,
      'slider': Slider
    },
  }
</script>
<style scoped>

</style>
