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
                <router-link v-bind:to="{name: 'home'}" style="color: black" v-on:hover="{color: lightgreen}">HOME</router-link>
              </li>
              <li id="tab">
                <router-link v-bind:to="{name: 'petdirectory'}" style="color: black">VIEW PETS</router-link>
              </li>
              <li id="tab">
                <router-link v-bind:to="{name: 'newpet'}" style="color: black">ADD NEW PET</router-link>
              </li>
              <li id="tab">
                <router-link v-bind:to="{name: 'frienddirectory'}" style="color: black">VIEW FRIENDS</router-link>
              </li>
            </ul>
          </a>

        <div>
          <div id="buttons">
            <router-link
              v-bind:to="{ name: 'login' }"
              class="button is-size-6 is-primary navbar-item my-3"
              >Login</router-link
            >
            <router-link
              v-bind:to="{ name: 'register' }"
              class="button is-size-6 is-success navbar-item my-3"
              >Create Account</router-link
            >
          </div>
        </div>
    </nav>

    <div id="lower-page" class="has-text-center">
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

#lower-page{
    background-image: url('../img/3-running-dogs.gif');
  padding-top: 15px;
}
#banner{
  padding-left: 25px;
}
#buttons{
  padding-right: 25px;
}
#tab{
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
#tabs{
display: flex;
}
#navigator{
  display: flex;
  align-items: center;
  justify-content: space-between;
  border-bottom: 1px solid lightgray;
  background-color: white;
}
#welcome-box {
  display: flex;
  justify-content: center;
  padding-top: 5px;
  padding-bottom: 6rem;
}
#welcome-message {
  display: flex;
  background-color: rgba(175, 250, 212, 0.281);
  color: rgb(10, 82, 58);
  border-left: solid black 1px;
  border-right: solid black 1px;

  border-radius: 4px;
  width: 1500px;
  height: 75px;
  justify-content: center;
  align-items: center;
}
#main-page {
  height: 50vh;
  
}
#message-box {
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  margin-left: 6rem;
  width: 600px;
}
</style>