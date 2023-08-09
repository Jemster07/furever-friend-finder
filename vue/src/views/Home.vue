<template>
  <nav class="navbar">
    <div class="navbar-brand">
      <a class="navbar-item">
        <img src="../img/FFF-Banner-Transparent.png" alt="site-logo" style="max-height: 100px" />
      </a>
    </div>

    <div class="navbar-menu" id="nav-links">
      <div class="navbar-end">
        <router-link v-bind:to="{ name: 'login' }" class="navbar-item">Login</router-link>
        </div>
        </div>
  </nav>
</template>

<script>
export default {
  name: "home"
};
</script>
