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
              v-bind:to="{ name: 'searchpet' }"
              style="color: black"
              >SEARCH PETS</router-link
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



    <p />
    <div class="py-3"></div>
    <div>
      <h1>Add A Pet</h1>
    </div>
  <div id="wholeform">
    <form id='formbox' @submit.prevent="submitPet" class="has-text-centered">

      <div class="form-input-group">    
        <p class="has-text-centered py-3">
      Please fill out the required fields below
    </p>
        <hr/>
        <label for="petname">Pet Name</label>
        <input id="petname" type="text" v-model="newpet.name" />
      </div>
      <div class="form-input-group">
        <label for="pettype">Pet Type </label>
        <select for="pettype" v-on:change="changeToOtherBreeds(newpet.type)" v-model="newpet.type">
          <option value="dog">Dog</option>
          <option value="cat">Cat</option>
          <option value="rabbit">Rabbit</option>
          <option value="horse">Horse</option>
          <option value="bird">Bird</option>
          <option value="other">Other</option>
        </select>
        <input id="pettype" type="hidden"/>
      </div>
      <div class="form-input-group">
        <label for="petspecies">Pet Breed</label>
        <select id="petspecies" v-model="newpet.species">
          <option v-for="breed in breeds" :key="breed.value" :value="breed.value">{{ breed.text }}</option>
        </select>
        <input id="petspecies" type="hidden" v-model="newpet.breed" />
      </div>
      <div class="form-input-group">
        <label for="petcolor">Pet Color</label>
        <input id="petcolor" type="text" v-model="newpet.color" />
      </div>
      <div class="form-input-group">
        <label for="petage">Pet Age</label>
        <select id="petage">
          <option value=""></option>
          <option value="baby">Baby</option>
          <option value="young">Young</option>
          <option value="adult">Adult</option>
          <option value="senior">Senior</option>
        </select>
        <input id="petage" type="hidden" v-model="newpet.age" />
      </div>
      <div class="form-input-group">
        <p>Please enter a short description for your pet.</p>
        <input id="petdesc" type="textarea" v-model="newpet.description" />
      </div>

      <form id=environments>
        <h1 class="subtitle">Environment</h1>
        <input type=checkbox id="children" value="children">
        <label for="children">Is good with children</label><br>
        <input type=checkbox id="dogs" value="dogs">
        <label for="dogs">Is good with dogs</label><br>
        <input type=checkbox id="cats" value="cats">
        <label for="cats">Is good with cats</label><br>
        <input type=checkbox id="others" value="others">
        <label for="others">Is good with other animals</label><br>
        <input type=checkbox id="indoor" value="indoor">
        <label for="indoor">Indoor only</label><br>
        <hr/>    
      </form>
       <form id=attributes>
        <p>Attributes</p>
        <input type=checkbox id="spayed_neutered" v-model="newpet.attributes.IsSpayedNeutered">
        <label for="spayed_neutered">Has been spayed/Neutered</label><br>
        <input type=checkbox id="house_trained" v-model="newpet.attributes.IsHouseTrained">
        <label for="house_trained">House Trained</label><br>
        <input type=checkbox id="declawed" v-model="newpet.attributes.IsDeclawed">
        <label for="declawed">Declawed</label><br>
        <input type=checkbox id="special_needs" v-model="newpet.attributes.IsSpecialNeeds">
        <label for="special_needs">Has special needs</label><br>
        <input type=checkbox id="shots_current" v-model="newpet.attributes.IsShotsCurrent">
        <label for="shots_current">Current on shots</label><br>
        <hr/>    
      </form>
       <form id=tags>
        <p>Tags</p>
        <input type=checkbox id="playful" value="playful">
        <label for="playful">Playful</label><br>
        <input type=checkbox id="needs_exercise" value="needs_exercise">
        <label for="needs_exercise">Needs Exercise</label><br>
        <input type=checkbox id="cute" value="cute">
        <label for="cute">Cute</label><br>
        <input type=checkbox id="affectionate" value="affectionate">
        <label for="affectionate">Affectionate</label><br>
        <input type=checkbox id="large" value="large">
        <label for="large">Large</label><br>
        <input type=checkbox id="intellegent" value="intellegent">
        <label for="intellegen">Intellegent</label><br>
        <input type=checkbox id="happy" value="happy">
        <label for="happy">Happy</label><br>
        <input type=checkbox id="short" value="short">
        <label for="short">Short</label><br>
        <input type=checkbox id="shedder" value="shedder">
        <label for="shedder">Shedder</label><br>
        <input type=checkbox id="shy" value="shy">
        <label for="shy">Shy</label><br>
        <input type=checkbox id="faithful" value="faithful">
        <label for="faithful">Faithful</label><br>
        <input type=checkbox id="leash_trained" value="leash_trained">
        <label for="leash_trained">Leash Trained</label><br>
        <input type=checkbox id="hypoallergenic" value="hypoallergenic">
        <label for="hypoallergenic">Hypoallergenic</label><br>
      </form>
      <hr/>    
      <p class="has-text-centered py-3">
      Add Picture(s) below.
      </p>
      <input type="file" @change="imageUploaded"><br>
      <button class="button is-success my-4" type="submit">
        Add Pet
      </button>

    </form>
    </div>


  </div>


</template>

<script>

import BreedsService from '../services/BreedsService.js';
import PetsService from '../services/PetsService.js';
import axios from 'axios';

export default {
  name: "addpet",
  data() {
    return {
      newpet: {
        type: "Please select type",
        breed: "",
        species: "",
        color: "",
        age: "",
        name: "",
        description: "",
        is_adopted:false,
        attributes: {
          IsSpayedNeutered: false,
          IsHouseTrained: false,
          IsDeclawed: false,
          IsSpecialNeeds: false,
          IsShotsCurrent: false,

        },

        },
        breeds: [],
        newBreed: "",
        imageFile: '',
    }
  },
  created() {
        this.breeds = BreedsService.getBreedOfDogs();
  },
  methods: {
    changeToOtherBreeds(event){

      if (event == "dog")
      {
        this.breeds = BreedsService.getBreedOfDogs();
      }
      else if (event == "cat")
      {
        this.breeds = BreedsService.getBreedsofCats();
      }
      else if (event == "rabbit")
      {
        this.breeds = BreedsService.getBreedsofRabbits();
      }
      else if (event == "horse")
      {
        this.breeds = BreedsService.getBreedsofHorse();
      }
      else if (event == "bird")
      {
        this.breeds = BreedsService.getBreedsofBirds();
      }
      else
      {
        this.breeds = BreedsService.getBreedsofOthers();
      }
    },
    submitPet()
    {
      this.newpet.userid = this.$store.state.user.userId;
      PetsService.AddPet(this.newpet)
      .then((response) => {
        console.log(response.data)
        this.submitPhoto(response.data);
      })
    },
    submitPhoto(pet) {
            const formData = new FormData();
            formData.append('formFile', this.imageFile);

            const config = {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            };
            axios.post(`/photo/save/${pet.petId}`, formData, config);
    },

        imageUploaded(event) {
            this.imageFile = event.target.files[0];
        }
  }
};
  

</script>

<style scoped>

#addpet
{
  background-color:lightgreen
}
#wholeform {
  display:flex;
  height: 220vh;
  justify-content: center;
  justify-items: center;
}
#formbox{
  background-color: rgb(196, 255, 201);
  padding: 15px;
  border:black solid 2px;
  border-radius: 10px;
  margin: 10px;
}
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
  height: max;
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
