<template>
  <div class="panel panel-default" style="margin-top:70px; width:100%;">
    <div class="row">
      <div class="search-wrapper panel-heading col-sm-12">
        <input class="form-control searchbar-color"
               type="text"
               v-model="searchQuery"
               placeholder="Search" />
      </div>
    </div>
    <div class="panel-body"
         style="overflow-y: scroll;"
         v-bind:class="{ 'search-list': isTyping}">
      <table v-if="resources.length"
             class="table">
        <tbody>
          <tr v-for="item in resources">
            <td class="search-item">
              <v-avatar>
                <v-img :src="$appPath +'/img/' + item.avatarUrl"
                       alt="avatar" />
              </v-avatar>
              <router-link
                        style="padding-left:20px;"
                        :to="'/user/' + item.id">
                {{item.author}}
              </router-link>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>

</template>

<script>
  import axios from 'axios'
  import _ from 'lodash'
  export default {
    data: () => ({
      searchQuery: '',
      resources: []
    }),

    watch: {
      searchQuery(after, before) {
        var that = this
        if (this.searchQuery) {
          axios.get('books/searchusers/' + this.searchQuery)
            .then(function (data) {
              that.resources = data.data.payload;
            })
        }
      }
    },
    computed: {
      isTyping() {
        return !this.searchQuery;
      }
    }
  }


</script>

<style scoped>
  .search-item:hover {
    color: black;
    background-color: #dcdee3;
  }

  .search-item, a {
    text-decoration: none;
    color: black
  }

  .search-list {
    display: none;
  }

  .searchbar-color:focus {
    box-shadow: 0 0 0 .2rem rgba(18,212,131,.25)
  }

  .panel-body {
    position: absolute;
    background-color: white;
    width: 100%;
  }

  .panel {
    position: relative;
    max-width: 500px;
  }
</style>
