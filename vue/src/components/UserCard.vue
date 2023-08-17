<template>
  <div class="card" id="card">
        <div class="card-image">
          
        </div>
        <div class="card-content">
          <div class="media">
            <div class="media-left">
              
            </div>
            <div class="media-content has-text-left">
              <p class="title is-4">{{localUser.username}}</p>
              <p class="subtitle is-6">{{localUser.role}}</p>
              <p class="subtitle is-6">{{localUser.email}}</p>
            </div>
          </div>

          <div class="content">
            {{localUser.address.street}}
          </div>
          <div class="content">
            {{localUser.address.city}}
          </div>
          <div class="content">
            {{localUser.address.state}}
          </div>
          <div class="content">
            {{localUser.address.zip}}
          </div>

          <div v-show="CheckStatus">
            <button v-on:click="ApproveUser(localUser)" class="button is-success my-4" type="submit">Approve</button>
            <button v-on:click="RejectUser(localUser)" class="button is-success my-4" type="submit">Reject</button>
          </div>

        </div>
      </div>
</template>

<script>
import UsersService from '../services/UsersService.js';

export default {
  name: 'user-card',
  props: ['displayUser'],
  computed: {
    CheckStatus() {
      return this.$store.state.user.role == 'admin' && this.displayUser.applicationStatus == 'pending';
    }
  },
  data(){
    return {
      localUser: this.displayUser
    }
  },
  methods: {
    ApproveUser(userIn) {
      userIn.applicationStatus = 'approved';
      UsersService.ApproveRejectApp(userIn).then(response => {
      this.localUser = response.data;
      this.$store.commit('UPDATE_PENDING',this.localUser);
    });
    },
    RejectUser(userIn) {
      userIn.applicationStatus = 'rejected';
      UsersService.ApproveRejectApp(userIn).then(response => {
      this.localUser = response.data;
      this.$store.commit('UPDATE_PENDING',this.localUser);
    });
    },
  },
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