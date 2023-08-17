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

  <div >

      <div>
        <li>
          <ul id="pets-list">
          <pet-card v-for='displayPet in pets' v-bind:key="displayPet.name" v-bind:displayPet="displayPet"></pet-card>


          </ul>
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

  </div>
  </div>
</template>

<script>
import PetCard from '../components/PetCard.vue'
import PetsService from '../services/PetsService.js'

export default {
  name: "petdirectory",
  components: { PetCard },
  data() {
    return{
      pets: []
    }
  },
  created() {
      PetsService.GetPetDirectory().then(response => {
          this.pets = response.data
      })
    }

};

</script>

<style scoped>

#footer{
  height:max-content;
  background-color: lightgreen;
}
#pets-list{
  display:flex;
  justify-content: space-around;
}
#card {
  display: inline-block;
  padding-top: 1rem;
  padding-left: 1vw;
  padding-right: 1vw;
  margin-left: 1vw;
  margin-right: 1vw;
  width: 17.8vw;
  height: 60vh;
  margin-bottom: 4rem;
  margin-top: 3rem;
}
  #page-title{
    margin-left: 2rem;
  }
  #main-page{
    background-color: lightgreen;
    height:300vh;
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
