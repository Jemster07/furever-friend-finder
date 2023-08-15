<template>
  <div>
    <div class="has-text-right py-4 px-4">
      <router-link :to="{ name: 'home' }" class="button is-light">
        Home
      </router-link>
    </div>

    <div>
      This is where you go to see a list of all active friends and admins
      <p>build this layout when register works</p>
    </div>
  </div>
</template>

<script>
export default {
  name: "frienddirectory",
};
</script>

