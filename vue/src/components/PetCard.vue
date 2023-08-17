<template>
  <div class="card" id="card">
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
        <div class="media-content has-text-left">
          <p class="title is-4">{{ displayPet.name }}</p>
          <p class="subtitle is-6">{{ displayPet.species }}</p>
        </div>
      </div>

      <div class="content">
        {{ displayPet.description }}
      </div>
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