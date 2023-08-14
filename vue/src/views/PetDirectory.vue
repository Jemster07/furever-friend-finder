<template>
  <div>
    <div class="has-text-right py-4 px-4">
      <router-link :to="{ name: 'home' }" class="button is-light">
        Home
      </router-link>
    </div>

  <div>
    This is where you go when you want to view all pets available on the site
    <p>
      updates to this page are to be handled when the pet card is built and able
      to be posted to the page itself
    </p>
    </div>
  </div>
</template>

<script>
export default {
  name: "petdirectory",
};
</script>

