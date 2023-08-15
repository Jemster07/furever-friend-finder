<template>
  <div>
    <div class="has-text-right py-4 px-4">
      <router-link v-bind:to="{ name: 'home' }" class="button is-light">
        Home
      </router-link>

    <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''" class="button is-light mx-3">
      Logout
    </router-link>
    <router-view />
    </div>

    

  
  </div>
</template>

<script>
export default {
  name: "frienddirectory",
};
</script>

