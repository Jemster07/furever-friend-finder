<template>
  <div id="main-page" class="has-text-centered">
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

    <div id="lower-page" class="has-text-center">
      <div id="welcome-box">
        <h1 id="welcome-message" class="is-size-1 py-5">Welcome to our family!</h1>
      </div>
    </div>

    <div id="message-box" class="message">
      <div class="message-header"></div>
      <div class="message-body is-size-4">
        Welcome to the Furever Friends Family.  Your application is being reviewed.  Once your application has been approved you will have full access to our website.  Look for an email sent from an administrator. In the meantime, feel free to browse the pets that are available.
      </div>
    </div>

    <footer id="footer">
      (insert copyright info here lol FureverFriendFinder 2023)
    </footer>
  </div>
</template>

<script>
export default {
  name: "home",
};
</script>

<style scoped>
#footer{
  color: darkgrey;
}
#card {
  display: inline-block;
  padding-top: 1rem;
  padding-left: 1vw;
  padding-right: 1vw;
  margin-left: 1vw;
  margin-right: 1vw;
  width: 22vw;
  height: 60vh;
  margin-bottom: 4rem;
  margin-top: 3rem;
}
#lower-page {
  padding-top: 25px;
  background-color: rgb(rgba(11, 243, 135, 0.575), green, blue);
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
#navigator {
  display: flex;
  align-items: center;
  justify-content: space-between;
  border-bottom: 1px solid gray;
  background-color: white;
}
#welcome-box {
  display: flex;
  justify-content: center;
  padding-bottom: 3rem;
}
#welcome-message {
  display: flex;
  background-color: rgba(255, 255, 255, 0.281);
  color: rgb(10, 82, 58);

  width: 100vw;
  height: 10vh;
  justify-content: center;
  align-items: center;
}
#main-page {
  background-color: lightgreen;
  height: 160vh;
}
#message-box {
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  margin-left: 5rem;
  margin-right: 5rem;
  width: 90vw;
  height: 40vh;
  padding-bottom: 10rem;
  margin-bottom: 3rem;
}
</style>