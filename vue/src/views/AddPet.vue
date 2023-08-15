<template>
  <div id="addpet">
    <div class="has-text-right py-4 px-4">
      <router-link v-bind:to="{ name: 'home' }" class="button is-light">
        Home
      </router-link>

      <router-link
        v-bind:to="{ name: 'logout' }"
        v-if="$store.state.token != ''"
        class="button is-light mx-3"
      >
        Logout
      </router-link>
    </div>

    <div class="has-text-right py-4 px-4">
      <router-link :to="{ name: 'home' }" class="button is-light">
        Home
      </router-link>
    </div>
    <h1 class="has-text-centered is-size-1 py-3">Add a Pet</h1>
    <p class="has-text-centered py-3">
      Please fill out the required fields below
    </p>
    <p />
    <div class="py-3"></div>
  <div id="wholeform">
    <form id='formbox' @submit.prevent="newpet" class="has-text-centered">
      <div class="form-input-group">
        <hr/>
        <label for="petname">Pet Name</label>
        <input id="petname" type="text" v-model="newpet.name" />
      </div>
      <div class="form-input-group">
        <label for="pettype">Pet Type </label>
        <select for="pettype">
          <option value="dog">Dog</option>
          <option value="cat">Cat</option>
          <option value="rabbit">Rabbit</option>
          <option value="Horse">Horse</option>
          <option value="bird">Bird</option>
          <option value="other">Other</option>
        </select>
        <input id="pettype" type="hidden" v-model="newpet.type" />
      </div>
      <div class="form-input-group">
        <label for="petspecies">Pet Breed</label>
        <select id="petspecies">
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
      <hr/>
    </form>
    </div>
  </div>
</template>

<script>

import BreedsService from '../services/BreedsService.js';

export default {
  name: "addpet",
  data() {
    return {
      newpet: {
        type: "",
        breed: "",
        color: "",
        age: "",
        name: "",
        description: "",

        },
        breeds: [],
    }
  },
  created() {
        this.breeds = BreedsService.getBreedOfDogs();
    }
  
}
</script>

<style>
#addpet
{
  background-color:lightgreen
}
#wholeform {
  display:flex;
  height: 50vh;
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
</style>
