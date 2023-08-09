<template class="has-background-success">
  <div id="register" class="section is-small has-text-centered">
    <form @submit.prevent="register">
      <h1 class="is-size-1 py-5">Create Account</h1>
      <div class="my-6" role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <div class="form-input-group">
        <label for="username">Username</label>
        <input
          type="text"
          id="username"
          v-model="user.username"
          required
          autofocus
        />
      </div>
      <div class="form-input-group">
        <label for="email">Email</label>
        <input type="email" id="email" v-model="user.email" required />
      </div>
      <div class="form-input-group">
        <label for="password">Password</label>
        <input type="password" id="password" v-model="user.password" required />
      </div>
      <div class="form-input-group">
        <label for="confirmPassword">Confirm Password</label>
        <input
          type="password"
          id="confirmPassword"
          v-model="user.confirmPassword"
          required
        />
      </div>
      <div class="level"> 
          <div>
            <label for="street">Street Address</label>
            <input type="text" id="street" v-model="user.address.street" required />
          </div>
          <div>
            <label for="state">State</label>
            <input type="text" id="state" v-model="user.address.state" required />
          </div>
          <div>
            <label for="city">City</label>
            <input type="text" id="city" v-model="user.address.city" required />
          </div>
          <div>
            <label for="zip">Zip Code</label>
            <input type="number max-99999" id="zip" v-model="user.address.zip" required /> 
          </div>
      </div>
      <button
        class="button is-success my-4"
        type="submit"
        v-on:click="register()"
      >
        Create Account
      </button>
      <p>
        <router-link :to="{ name: 'login' }"
          >Already have an account? Log in.</router-link
        >
      </p>
    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "register",
  data() {
    return {
      user: {
        username: "",
        email: "",
        password: "",
        confirmPassword: "",
        role: "user",
        address: {
          street: "",
          city: "",
          state: "",
          zip: 0,
        },
      },
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = "Password & Confirm Password do not match.";
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: "/login",
                query: { registration: "success" },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = "Bad Request: Validation Errors";
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = "There were problems registering this user.";
    },
  },
};
</script>

<style scoped>
.form-input-group {
  margin-bottom: 1rem;
}
label {
  margin-right: 0.5rem;
}
</style>
