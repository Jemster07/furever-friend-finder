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
            <router-link v-bind:to="{ name: 'home' }" style="color: black"
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
    <div>
      <p class="title has-text-centered">
        Our Local Friends Available For Adoptions
      </p>
    </div>
    <div>
      <li id="pets-list">
          <pet-card
            v-for="displayPet in pets"
            v-bind:key="displayPet.name"
            v-bind:displayPet="displayPet"
          ></pet-card>
      </li>
      <!-- <router-link
        v-bind:to="{ name: 'updatepet' }"
        
        v-bind:key="petToChange.id"
        v-bind:petToChange="petToChange"
        v-show="$store.state.user.applicationStatus == 'approved'"
        >Edit Pet</router-link
      >
 -->
    </div>
    <div>
      <p class="title has-text-centered">
        Search Pet-Finder for Friends To Adopt
      </p>
    </div>
    <div>
      <form id="searchform" @submit.prevent="search" class="has-text-centered">
        <div class="form-input-group">
          <label for="searchtype">How do you want to search? </label>
          <select for="searchtype" v-model="searchType">
            <option value="type">Search by pet type</option>
            <option value="breed">Search by breed</option>
            <option value="zip">Search by zip-code</option>
          </select>
          <input id="type" type="hidden" />
        </div>
        <div class="form-input-group" v-show="searchType == 'type'">
          <label for="pettype">Pet Type </label>
          <select for="pettype" v-model="petType">
            <option value="dog">Dog</option>
            <option value="cat">Cat</option>
            <option value="rabbit">Rabbit</option>
            <option value="horse">Horse</option>
            <option value="bird">Bird</option>
            <option value="other">Other</option>
          </select>
          <input id="pettype" type="hidden" />
        </div>
        <div v-show="searchType == 'breed'">
          <label for="searchbreed">Pet Breed</label>
          <input id="searchbreed" type="text" v-model="petBreed" />
        </div>
        <div v-show="searchType == 'zip'">
          <label for="searchzip">Zip-Code</label>
          <input id="searchzip" type="text" v-model="petZip" />
        </div>
        <button class="button is-success my-4" type="submit">Search</button>
        <div v-show="!hasSearchResults">Search Results not Found</div>
      </form>
    </div>

    <div id="search-results">
      <pet-search-card
        v-for="pet in petSearchResults"
        :key="pet.id"
        :displayPet="pet"
      ></pet-search-card>
    </div>
  </div>
</template>

<script>
import PetCard from "../components/PetCard.vue";
import PetSearchCard from "../components/PetSearchCard.vue";
import PetsService from "../services/PetsService.js";
import PetFinderService from "../services/PetFinderService.js";

export default {
  name: "petdirectory",
  components: { PetCard, PetSearchCard },
  data() {
    return {
      pets: [],
      searchType: "",
      petType: "",
      petBreed: "",
      petZip: "",
      petSearchResults: [],
      hasSearchResults: true,
    };
  },
  created() {
    PetsService.GetPetDirectory().then((response) => {
      this.pets = response.data;
    });
  },
  methods: {
    search() {
      if (this.searchType == "type") {
        PetFinderService.ListPetFinderAnimals(this.petType)
          .then((response) => {
            this.petSearchResults = response.data;
            this.hasSearchResults = this.petSearchResults.length > 0;
          })
          .catch(() => {
            this.hasSearchResults = false;
          });
      }
      if (this.searchType == "breed") {
        PetFinderService.ListPetFinderBreeds(this.petBreed)
          .then((response) => {
            this.petSearchResults = response.data;
            this.hasSearchResults = this.petSearchResults.length > 0;
          })
          .catch(() => {
            this.hasSearchResults = false;
          });
      }
      if (this.searchType == "zip") {
        PetFinderService.ListPetFinderByLocation(this.petZip)
          .then((response) => {
            this.petSearchResults = response.data;
            this.hasSearchResults = this.petSearchResults.length > 0;
          })
          .catch(() => {
            this.hasSearchResults = false;
          });
      }
    },
  },
};
</script>

<style scoped>

#image{
  width: 200px;
  height:200px;
}

#search-results {
  display:inline-block;
  margin-left: 5vw;
  margin-right: 5vw;
}

#pets-list {
  display:inline-block;
  margin-left: 5vw;
  margin-right: 5vw;
}
#card {
  display: inline-block;
  padding-top: 1rem;
  padding-left: 1vw;
  padding-right: 1vw;
  margin-left: 1vw;
  margin-right: 1vw;
  width: 20vw;
  height: 75vh;
  margin-bottom: 4rem;
  margin-top: 3rem;
}
#page-title {
  margin-left: 2rem;
}
#main-page {
  height: 1000vh;
  background-color: lightgreen;
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
