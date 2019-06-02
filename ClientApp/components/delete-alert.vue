<template>
  <v-layout row justify-center>
    <v-dialog v-model="dialog" persistent max-width="290">
      <template v-slot:activator="{ on }">
        <v-btn color="red" dark v-on="on" icon><i class="material-icons">
  delete_forever
</i></v-btn>
      </template>
      <v-card>
        <v-card-title class="headline">Do you really want to delete it?</v-card-title>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="green darken-1" flat @click="dialog = false">No</v-btn>
          <v-btn color="green darken-1" flat @click="agree">Yes</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-layout>
</template>

<script>
  export default {
    data: () => ({
      dialog: false
    }),
    methods: {
      agree() {
        this.dialog = false;
        this.$emit("deleted");
      }
    }
  }
</script>
<style scoped>
</style>
