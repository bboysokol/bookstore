<template>
  <div id="app">
    
      <v-carousel delimiter-icon="stop"
                  height="350px"
                  prev-icon="mdi-arrow-left"
                  next-icon="mdi-arrow-right">
        <v-carousel-item v-for="(item,i) in items"
                         :key="i"
                         :src="item.src"></v-carousel-item>
      </v-carousel>
    
  </div>
</template>

<script>
  import {Configuration} from '../Configuration'
  export default {
    data() {
      return {
        items: [
          {
            src: Configuration.ServerPath + '/img/slider/slider1.png'
          },
          {
            src: Configuration.ServerPath + '/img/slider/slider2.png'
          },
          {
            src: Configuration.ServerPath + '/img/slider/slider3.png'
          },
          {
            src: Configuration.ServerPath + '/img/slider/slider4.png'
          }
        ]
      }
    }
  }
</script>
<style scoped>
</style>
