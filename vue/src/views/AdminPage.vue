<template>
  <div> 
      This is where you go when you have the "admin" role and would like to see a list of all pending "friend" applications
      <p> This will take the account info from "user" roles applying for a "friend" role </p> 
              
    <button class="button is-success my-4" type="submit">
      <router-link v-bind:to="{ name: 'frienddirectory' }" style="color: white">Pending Users</router-link>
    </button>

  </div>
</template>

<script>
export default {
    name: 'adminpage'
}
</script>

