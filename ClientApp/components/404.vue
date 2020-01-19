<template>
  <center>
    <div class="container">
      <h1 class="main-color">
        <v-icon color="#FFB300"
                size="130px">bug_report</v-icon>404
      </h1>
      <h3 class="second"><b>Ooops! Page not found</b></h3>
      <v-label class="second">We're sorry, the page you requested could not be found. Plase go back to the homepage!</v-label><br />
      <v-btn @click="goHomePage"
             color="#FFB300"
             round
             dark>Homepage</v-btn>
    </div>
  </center>
</template>

<script>
  import router from '../router/index'
  export default {
    data: () => ({
    })
    ,
    methods: {
      goHomePage() {
        router.push('/');
      }
    }
  }


</script>

<style scoped>
  .container {
    
    margin-top: 70px;
    width: 100%;
  }

  .main-color {
    color: #FFB300;
    font-size: 120px;
  }

  .second {
    font-size: 30px;
  }
</style>
