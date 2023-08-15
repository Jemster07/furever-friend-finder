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
              v-bind:to="{ name: 'petdirectory' }"
              style="color: black"
              >VIEW PETS</router-link
            >
          </li>
          <li id="tab">
            <router-link v-bind:to="{ name: 'newpet' }" style="color: black"
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
            v-if="this.$route.query.registration"
            >Login</router-link
          >
          <router-link
            v-bind:to="{ name: 'register' }"
            class="button is-size-6 is-success navbar-item my-3"
            v-if="this.$route.query.registration"
            >Create Account</router-link
          >
          <router-link
            id="logout"
            v-bind:to="{ name: 'logout' }"
            class="button is-size-6 is-light"
            v-if="this.$store.user.role == 'friend'"
            >Logout</router-link
          >
        </div>
      </div>
    </nav>

    <div id="lower-page" class="has-text-center">
      <div id="welcome-box">
        <h1 id="welcome-message" class="is-size-1 py-5">Welcome!</h1>
      </div>
    </div>
    <div id="message-box" class="message">
      <div class="message-header">About Us</div>
      <div class="message-body">
        Furever Friend Finder is your one-stop shop when it comes to discovering
        the purr-fect addition to your family
      </div>
    </div>

    <div class="card">
      <div class="card-image">
        <figure class="image is-4by3">
          <img
            src="https://bulma.io/images/placeholders/1280x960.png"
            alt="Placeholder img"
          />
        </figure>
      </div>
      <div class="card-content">
        <div class="media">
          <div class="media-left">
            <figure class="image is-48x48">
              <img
                src="https://bulma.io/images/placeholders/96x96.png"
                alt="Placeholder img"
              />
            </figure>
          </div>
          <div class="media-content">
            <p class="title is-4">Pet Name</p>
            <p class="subtitle is-6">Breed</p>
          </div>
        </div>

        <div class="content">
          (description) Lorem, ipsum dolor sit amet consectetur adipisicing
          elit. Quaerat pariatur dolorem quo aliquam sapiente eos accusamus sunt
          tempore. Praesentium natus repudiandae commodi eaque eligendi a
          molestiae rem quo delectus numquam.
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
#lower-page {
  padding-top: 15px;
  height: 40vh;
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
  width: 100vw;
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