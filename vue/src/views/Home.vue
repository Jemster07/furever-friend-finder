<template>
  <div class="has-text-centered">
    
    <nav class="navbar has-shadow">
      <div class="navbar-brand">
        <a class="navbar-item">
          <img
            src="../img/FFF-Banner-Transparent.png"
            alt="site-logo"
            style="max-height: 125px"
          />
        </a>
      </div>

      <div class="navbar-menu is-active" id="nav-links">
        <div class="navbar-end">
          <div class="buttons">
            <router-link
              v-bind:to="{ name: 'login' }"
              class="button is-size-5 is-primary navbar-item"
              >Login</router-link
            >
            <router-link
              v-bind:to="{ name: 'register' }"
              class="button is-size-5 is-success navbar-item"
              >Create Account</router-link
            >
          </div>
        </div>
      </div>
    </nav>


  </div>
</template>

<script>
export default {
  name: "home",
};
</script>
