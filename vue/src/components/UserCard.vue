<template>
  <div class="card" id="card">
        <div class="card-image">
          <figure class="image is-4by3">
            <img
              src="https://bulma.io/images/placeholders/1280x960.png"
              alt="Placeholder img"
            />
          </figure>
        </div>
        <div class="card-content">
          <div class="media">
            <div class="media-left">
              <figure class="image is-48x48">
                <img
                  src="https://bulma.io/images/placeholders/96x96.png"
                  alt="Placeholder img"
                />
              </figure>
            </div>
            <div class="media-content has-text-left">
              <p class="title is-4">{{displayUser.username}}</p>
              <p class="subtitle is-6">{{displayUser.role}}</p>
            </div>
          </div>

          <div class="content">
            {{displayUser.address.street}}
          </div>
        </div>
      </div>
</template>

<script>
// import UsersService from '../services/UsersService.js';

export default {
    name: 'user-card',
    props: ['displayUser'],
    data() {
      return {
        // tempUser: {
        //   userId: 0,
        //   username: "",
        //   role: "",
        //   address: {
        //     addressId: 0,
        //     street: "",
        //     city: "",
        //     state: "",
        //     zip: 0,
        //   },
        //   applicationStatus: "",
        //   isInactive: false,
        //   email: "",
        //   isAdopter: false
        // }
      }
    },
  //   created() {
  //       UsersService.GetUser(this.users.displayUser.username).then(response => {
  //       this.displayUser = response.data;
  //   });
  // }
}
</script>

<style scoped>
#card {
  display: inline-block;
  padding-top: 1rem;
  padding-left: 1vw;
  padding-right: 1vw;
  margin-left: 1vw;
  margin-right: 1vw;
  width: 22vw;
  height: 60vh;
  margin-bottom: 4rem;
  margin-top: 3rem;
}
</style>