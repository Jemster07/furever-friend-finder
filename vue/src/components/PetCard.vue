<template>
  <div class="card" id="card">
    <div class="card-image">
      <figure id="image" class="image">
        <img :src="displayPet.photos[0].photoUrl" :alt="displayPet.name" />
      </figure>
    </div>
    <div class="card-content">
      <div class="media">
        <div class="media-content has-text-left">
          <p class="title is-4">{{ displayPet.name }}</p>
          <p class="subtitle is-6">{{ displayPet.species }}</p>
        </div>
      </div>
    </div>

    <div class="content">
      {{ displayPet.description }}
    </div>
  </div>
</template>

<script>
export default {
  name: "pet-card",
  props: ["displayPet"],
  data() {
    return {};
  },
};
</script>

<style>
</style>