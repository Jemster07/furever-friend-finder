<template>
  <div id="main-page">

    <nav id="navigator">
      <a>
        <img
          id="banner"
          src="../img/FFF-Banner-Transparent.png"
          alt="site-logo"
          style="max-height: 150px"
        />
      </a>
      <a id="tab-bar">
        <ul id="tabs">
          <li id="tab">
            <router-link
              v-bind:to="{ name: 'home' }"
              style="color: black"
              >HOME</router-link
            >
          </li>
          <li id="tab">
            <router-link
              v-bind:to="{ name: 'petdirectory' }"
              style="color: black"
              >VIEW PETS</router-link
            >
          </li>
          <li id="tab">
            <router-link v-bind:to="{ name: 'addpet' }" style="color: black"
              >ADD NEW PET</router-link
            >
          </li>
          <li id="tab">
            <router-link
              v-bind:to="{ name: 'frienddirectory' }"
              style="color: black"
              >VIEW FRIENDS</router-link
            >
          </li>
        </ul>
      </a>

      <div>
        <div id="buttons">
          <router-link
            v-bind:to="{ name: 'login' }"
            class="button is-size-6 is-primary navbar-item my-3"
            v-if="$store.state.token == ''"
            >Login</router-link
          >
          <router-link
            v-bind:to="{ name: 'register' }"
            class="button is-size-6 is-success navbar-item my-3"
            v-if="$store.state.token == ''"
            >Create Account</router-link
          >
          <router-link
            id="logout"
            v-bind:to="{ name: 'logout' }"
            class="button is-size-6 is-light"
            v-if="$store.state.token != ''"
            >Logout</router-link
          >
        </div>
      </div>
    </nav>

    <div id="friend-back">
      <div>
        <button class="button is-success my-4" type="submit" v-show="$store.state.user.role == 'admin'">
          <router-link v-bind:to="{ name: 'adminpage' }" style="color: white">Pending Users</router-link>
        </button>

      <div id="friend-list">
        <user-card v-for='displayUser in users' v-bind:key="displayUser.username" 
        v-bind:displayUser="displayUser"></user-card>
      </div>
      </div>
    </div>
  </div>
</template>

<script>
import UserCard from '../components/UserCard.vue';
import UsersService from '../services/UsersService.js';

export default {
  name: "frienddirectory",
  components: { UserCard },
  data() {
    return {
      users: []
    }
  },
  created() {
    UsersService.GetFriendDirectory().then(response => {
      this.users = response.data;
    });
  }
};
</script>

<style scoped>

#friend-list{
  margin-left: 8vw;
  margin-right: 8vw;

}

#friend-back{

  width: 90vw;
  margin-left: 5rem;
  margin-right: 5rem;
  margin-top: 3rem;
  margin-bottom: 5rem;
  height: 180vh;
  background-color: white;
}
#main-page {
  height: 200vh;
  background-color: lightgreen;
}
#page-title {
  margin-left: 2rem;
}
#header {
  display: flex;
  background-color: white;
  justify-content: space-between;
  align-items: center;
  height: 10vh;
  border-bottom: 1px solid gray;
}
  #navigator {
  display: flex;
  align-items: center;
  justify-content: space-between;
  border-bottom: 1px solid gray;
  background-color: white;
}
#banner {
  padding-left: 25px;
}
#buttons {
  padding-right: 25px;
}
#tab {
  font-size: 20px;
  padding-top: 10px;
  padding-bottom: 10px;
  padding-left: 20px;
  padding-right: 20px;
  margin-left: 20px;
  margin-right: 20px;
  border-left: 1px solid lightgreen;
  border-right: 1px solid lightgreen;
  border-radius: 2px;
}
#tabs {
  display: flex;
}

</style>

