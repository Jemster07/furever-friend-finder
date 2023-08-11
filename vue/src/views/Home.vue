<template>
  <div id="main-page" class="has-text-centered">
    <nav id="navigator" class="navbar has-shadow">
      <div class="navbar-start">
        <div class="navbar-brand">
          <a class="navbar-item">
            <img
              src="../img/FFF-Banner-Transparent.png"
              alt="site-logo"
              style="max-height: 150px"
            />
          </a>
          <div class="tabs">
            <ul>
              <router-link v-bind:to="{name: 'home'}">HOME</router-link>|
              <router-link v-bind:to="{name: 'petdirectory'}">VIEW PETS</router-link>|
              <router-link v-bind:to="{name: 'newpet'}">ADD NEW PET</router-link>|
              <router-link v-bind:to="{name: 'frienddirectory'}">VIEW FRIENDS</router-link>|
            </ul>
          </div>
        </div>
      </div>

      <div class="navbar-menu is-active" id="nav-links">
        <div class="navbar-end">
          <div class="buttons">
            <router-link
              v-bind:to="{ name: 'login' }"
              class="button is-size-5 is-primary navbar-item px-4"
              >Login</router-link
            >
            <router-link
              v-bind:to="{ name: 'register' }"
              class="button is-size-5 is-success navbar-item mx-5"
              >Create Account</router-link
            >
          </div>
        </div>
      </div>
    </nav>

    <div class="has-text-center">
      <div id="welcome-box">
        <h1 id="welcome-message" class="is-size-1 py-5">Welcome!</h1>
      </div>

      <div id="message-box" class="message">
        <div class="message-header">About Us</div>
        <div class="message-body">
          Furever Friend Finder is your one-stop shop when it comes to
          discovering the purr-fect addition to your family
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "home",
};
</script>

<style>

#navigator{
  border-bottom: 1px solid lightgray;
}
#welcome-box {
  display: flex;
  justify-content: center;
  padding-top: 2rem;
  padding-bottom: 6rem;
}
#welcome-message {
  display: flex;
  background-color: rgb(23, 202, 142);
  color: rgb(239, 245, 243);
  border: solid black 1px;
  border-radius: 12px;
  width: 500px;
  height: 75px;
  justify-content: center;
  align-items: center;
}
#main-page {
  background-color: aliceblue;
  height: 55vh;
}
#message-box {
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  margin-left: 6rem;
  width: 600px;
}
</style>