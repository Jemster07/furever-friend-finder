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

    <div class="section has-text-left">
      <div class="dropdown is-hoverable">
        <div class="dropdown-trigger">
          <button
            class="button"
            aria-haspopup="true"
            aria-controls="dropdown-menu4"
          >
            <span>More</span>
            <span class="icon is-small">
              <i class="fas fa-angle-down" aria-hidden="true"></i>
            </span>
          </button>
        </div>
        <div class="dropdown-menu" id="dropdown-menu3" role="menu">
          <div class="dropdown-content">
            <a href="#" class="dropdown-item"> Overview</a>
            <a href="#" class="dropdown-item"> Find a Pet</a>
            <a href="#" class="dropdown-item"> Adopt a Pet</a>
            <a href="#" class="dropdown-item"> About Us </a>
            <a href="#" class="dropdown-item"> FAQ</a>
            <hr class="dropdown-divider" />
            <a href="#" class="dropdown-item"> More </a>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "home",
};
</script>
