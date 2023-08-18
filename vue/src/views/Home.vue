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
        <h1 id="welcome-message" class="is-size-1 py-5">Welcome!</h1>
      </div>
    </div>

    <div id="message-box" class="message">
      <div class="message-header">About Us</div>
      <div class="message-body is-size-4">
        We match animals with loving homes. Our website provides curated selections, support for new owners, and a strong community. Join us to find your perfect furry friend and be part of heartwarming stories. Welcome to Furever Friend Finder, where friendships begin.
      </div>
    </div>

  <div class="has-text-centered is-size-3">
    Have a look at some of our pets!
  </div>

  <div id="search-results">
    <pet-search-card v-for="pet in petSearchResults" :key="pet.id" :displayPet="pet"></pet-search-card>
  </div>


    <footer id="footer">
      (insert copyright info here lol FureverFriendFinder 2023)
    </footer>
  </div>
</template>

<script>
import PetFinderService from '../services/PetFinderService.js'
import PetSearchCard from '../components/PetSearchCard.vue'


export default {
  name: "home",
  components: { PetSearchCard },
  data() {
    return {
      pets: [],
      searchType: "",
      petType: '',
      petBreed: '',
      petZip: '',
      petSearchResults: [],
      hasSearchResults: true
     
    }
  },
  created() {
        PetFinderService.ListPetFinderByLocation("15136").then(response => {
           this.petSearchResults = response.data;
           this.hasSearchResults = this.petSearchResults.length > 0;
         })
         .catch(() => {
           this.hasSearchResults = false;
         })

    
    },

  }

</script>

<style scoped>
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
  #page-title{
    margin-left: 2rem;
  }
  #main-page{
    height: max;
    background-color: lightgreen;
  }
  #header{
    display:flex;
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