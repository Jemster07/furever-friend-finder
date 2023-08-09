<template>
  <div id="app">
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
    <router-view />
  </div>
</template>
