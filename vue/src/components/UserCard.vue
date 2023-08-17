<template>
  <div class="card" id="card">
        <div class="card-image">
          
        </div>
        <div class="card-content">
          <div class="media">
            <div class="media-left">
              
            </div>
            <div class="media-content has-text-left">
              <p class="title is-4">{{displayUser.username}}</p>
              <p class="subtitle is-6">{{displayUser.role}}</p>
            </div>
          </div>

          <div class="content">
            {{displayUser.address.street}}
          </div>
          <div class="content">
            {{displayUser.address.city}}
          </div>
          <div class="content">
            {{displayUser.address.state}}
          </div>
          <div class="content">
            {{displayUser.address.zip}}
          </div>

        </div>
      </div>
</template>

<script>

export default {
    name: 'user-card',
    props: ['displayUser'],

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