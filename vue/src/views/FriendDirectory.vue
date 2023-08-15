<template>
  <div id="main-page">
    <div id="header">
      <div id="page-title" class="has-text-left is-size-2">All Friends</div>

      <div class="has-text-right py-4 px-4">
        <router-link :to="{ name: 'home' }" class="button is-light">
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
    </div>

    <div id="friend-list">
      <div>
        
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "frienddirectory",
};
</script>

<style scoped>

#friend-list{
  display: grid;

  width: 90vw;
  margin-left: 5rem;
  margin-right: 5rem;
  margin-top: 3rem;
  margin-bottom: 5rem;
  height: 80vh;
  background-color: white;
}
#main-page {
  height: 100vh;
  background-color: lightgreen;
}
#page-title {
  margin-left: 2rem;
}
#header {
  display: flex;
  background-color: white;
  justify-content: space-between;
  align-items: center;
  height: 10vh;
  border-bottom: 1px solid gray;
}
</style>

