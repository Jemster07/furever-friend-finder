<template>
  <div id="newpet">
  
    <div class="has-text-right py-4 px-4">
      <router-link v-bind:to="{ name: 'home' }" class="button is-light">
        Home
      </router-link>

    <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''" class="button is-light mx-3">
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

    <form @submit.prevent="newpet" class="has-text-centered">
      <div class="form-input-group">
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
        <select for="petspecies" v-if="pettype.value === 'dog'">
          <option value="afghanhound">Afghan Hound</option>
          <option value="airedaleterrier">Airedale Terrier</option>
          <option value="akbash">Akbash</option>
          <option value="akita">Akita</option>
          <option value="alaskanmalamute">Alaskan Malamute</option>
          <option value="americanbulldog">American Bulldog</option>
          <option value="americanbully">American Bully</option>
          <option value="americaneskimodog">American Eskimo Dog</option>
          <option value="americanfoxhound">American Foxhound</option>
          <option value="americanhairlessterrier">
            American Hairless Terrier
          </option>
          <option value="americanstaffordshireterrier">
            American Staffordshire Terrier
          </option>
          <option value="americanwaterspaniel">American Water Spaniel</option>
          <option value="anatolianshepard">Anatolian Shepard</option>
          <option value="appenzell">Appenzell Mountain Dog</option>
          <option value="aussiedoodle">Aussiedoodle</option>
          <option value="australiancattledog">
            Australian Cattle Dog / Blue Heeler
          </option>
          <option value="australiankelpie">Australian Kelpie</option>
          <option value="australianshepard">Australian Shepard</option>
          <option value="australianterrier">Australian Terrier</option>
        </select>
        <input id="petspecies" type="hidden" v-model="newpet.breed" />
      </div>
      <div class="form-input-group">
        <label for="petcolor">Pet Color</label>
        <input id="petcolor" type="text" v-model="newpet.color" />
      </div>
      <div class="form-input-group">
        <label for="petage">Pet Age</label>
        <input id="petage" type="number" v-model="newpet.age" />
      </div>
      <div class="form-input-group">
        <p>Please enter a short description for your pet.</p>
        <input id="petdesc" type="textarea" v-model="newpet.description" />
      </div>
    </form>
  </div>
</template>

<script>
export default {
  name: "newpet",
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
    };
  },
};
</script>

