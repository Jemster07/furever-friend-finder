<template>
  <div id="newpet">
        <div class="has-text-right py-4 px-4">
      <router-link :to="{name: 'home'}" class="button is-light">
        Home
      </router-link>
    </div>

    <h1 class="has-text-centered is-size-1 py-3">Add a Pet</h1>
      <p class="has-text-centered py-3"> Please fill out the required fields below<p/>
      <div class="py-3"></div>

      <form @submit.prevent="newpet" class="has-text-centered">
        <div class="form-input-group">
          <label for="petname">Pet Name</label>
          <input id="petname" type="text" v-model="newpet.name" />
        </div>
        <div class="form-input-group">
          <label for="pettype">Pet Type </label>
          <select for="pettype"> Pet Type
            <option value="type1">Type 1</option>
            <option value="type2">Type 2</option>
            <option value="type3">Type 3</option>
          </select>
          <input id="pettype" type="hidden" v-model="newpet.type" />
        </div>
        <div class="form-input-group">
          <label for="petspecies">Pet Species</label>
          <select for="petspecies">
            <option value="species1">Species 1</option>
            <option value="species2">Species 2</option>
            <option value="species3">Species 3</option>
          </select>
          <input id="petspecies" type="hidden" v-model="newpet.species" />
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
    name: 'newpet',
    data() {
      return{
        newpet: {
          type: '',
          species: '',
          color: '',
          age: '',
          name: '',
          description: '',
        }
      }
    }
}
</script>

<style>

</style>