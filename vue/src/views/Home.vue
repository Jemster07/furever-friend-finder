<template>
  <div id="main-page" class="has-text-centered">
    <nav id="navigator">
      <a>
        <img
          id="banner"
          src="../img/FFF-Banner-Transparent.png"
          alt="site-logo"
          style="max-height: 150px"
        />
      </a>
      <a id="tab-bar">
        <ul id="tabs">
          <li id="tab">
            <router-link
              v-bind:to="{ name: 'searchpet' }"
              style="color: black"
              >SEARCH PETS</router-link
            >
          </li>
          <li id="tab">
            <router-link
              v-bind:to="{ name: 'petdirectory' }"
              style="color: black"
              >VIEW PETS</router-link
            >
          </li>
          <li id="tab">
            <router-link v-bind:to="{ name: 'addpet' }" style="color: black"
              >ADD NEW PET</router-link
            >
          </li>
          <li id="tab">
            <router-link
              v-bind:to="{ name: 'frienddirectory' }"
              style="color: black"
              >VIEW FRIENDS</router-link
            >
          </li>
        </ul>
      </a>

      <div>
        <div id="buttons">
          <router-link
            v-bind:to="{ name: 'login' }"
            class="button is-size-6 is-primary navbar-item my-3"
            v-if="$store.state.token == ''"
            >Login</router-link
          >
          <router-link
            v-bind:to="{ name: 'register' }"
            class="button is-size-6 is-success navbar-item my-3"
            v-if="$store.state.token == ''"
            >Create Account</router-link
          >
          <router-link
            id="logout"
            v-bind:to="{ name: 'logout' }"
            class="button is-size-6 is-light"
<<<<<<< HEAD
=======
            v-if="$store.state.token != ''"
>>>>>>> 4e1e07a6ce8ad4ed017830867bf0541581087286
            >Logout</router-link
          >
        </div>
      </div>
    </nav>

    <div id="lower-page" class="has-text-center">
      <div id="welcome-box">
        <h1 id="welcome-message" class="is-size-1 py-5">Welcome!</h1>
      </div>
    </div>

    <div id="message-box" class="message">
      <div class="message-header">About Us</div>
      <div class="message-body is-size-4">
        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Autem facilis
        et reprehenderit vero debitis ex, maxime eligendi veniam quas enim
        molestias amet quo ad id doloribus tempora laboriosam a non! Lorem ipsum
        dolor sit amet consectetur adipisicing elit. Molestiae voluptatibus
        esse, ipsam ratione repellat rerum corporis, odio aut vitae quas nostrum
        quaerat eligendi! Nobis odit, deserunt maiores hic eveniet optio?Lorem
        ipsum dolor sit, amet consectetur adipisicing elit. Asperiores nobis
        iste eum. Dolores qui ullam velit, quam ad dignissimos, eligendi maxime
        fugit magnam id laudantium! Dignissimos fuga impedit at rem! Lorem
        ipsum, dolor sit amet consectetur adipisicing elit. Quo sunt eveniet
        non, minus consequatur laudantium reprehenderit, eligendi est suscipit
        exercitationem, distinctio tempore quas consectetur cumque animi dolore
        porro totam nobis?
      </div>
    </div>

  <div class="has-text-centered is-size-3">
    Have a look at some of our pets!
  </div>

    <div class="cards">
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
              <p class="title is-4">Pet Name</p>
              <p class="subtitle is-6">Breed</p>
            </div>
          </div>

          <div class="content">
            (description) Lorem, ipsum dolor sit amet consectetur adipisicing
            elit. Quaerat pariatur dolorem quo aliquam sapiente eos accusamus
            sunt tempore. Praesentium natus repudiandae commodi eaque eligendi a
            molestiae rem quo delectus numquam.
          </div>
        </div>
      </div>
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
              <p class="title is-4">Pet Name</p>
              <p class="subtitle is-6">Breed</p>
            </div>
          </div>

          <div class="content">
            (description) Lorem, ipsum dolor sit amet consectetur adipisicing
            elit. Quaerat pariatur dolorem quo aliquam sapiente eos accusamus
            sunt tempore. Praesentium natus repudiandae commodi eaque eligendi a
            molestiae rem quo delectus numquam.
          </div>
        </div>
      </div>
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
              <p class="title is-4">Pet Name</p>
              <p class="subtitle is-6">Breed</p>
            </div>
          </div>

          <div class="content">
            (description) Lorem, ipsum dolor sit amet consectetur adipisicing
            elit. Quaerat pariatur dolorem quo aliquam sapiente eos accusamus
            sunt tempore. Praesentium natus repudiandae commodi eaque eligendi a
            molestiae rem quo delectus numquam.
          </div>
        </div>
      </div>
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
              <p class="title is-4">Pet Name</p>
              <p class="subtitle is-6">Breed</p>
            </div>
          </div>

          <div class="content">
            (description) Lorem, ipsum dolor sit amet consectetur adipisicing
            elit. Quaerat pariatur dolorem quo aliquam sapiente eos accusamus
            sunt tempore. Praesentium natus repudiandae commodi eaque eligendi a
            molestiae rem quo delectus numquam.
          </div>
        </div>
      </div>
    </div>

    <footer id="footer">
      (insert copyright info here lol FureverFriendFinder 2023)
    </footer>
  </div>
</template>

<script>
export default {
  name: "home",
};
</script>

<style scoped>
#footer{
  color: darkgrey;
}
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
#lower-page {
  padding-top: 25px;
  background-color: rgb(rgba(11, 243, 135, 0.575), green, blue);
}
#banner {
  padding-left: 25px;
}
#buttons {
  padding-right: 25px;
}
#tab {
  font-size: 20px;
  padding-top: 10px;
  padding-bottom: 10px;
  padding-left: 20px;
  padding-right: 20px;
  margin-left: 20px;
  margin-right: 20px;
  border-left: 1px solid lightgreen;
  border-right: 1px solid lightgreen;
  border-radius: 2px;
}
#tabs {
  display: flex;
}
#navigator {
  display: flex;
  align-items: center;
  justify-content: space-between;
  border-bottom: 1px solid gray;
  background-color: white;
}
#welcome-box {
  display: flex;
  justify-content: center;
  padding-bottom: 3rem;
}
#welcome-message {
  display: flex;
  background-color: rgba(255, 255, 255, 0.281);
  color: rgb(10, 82, 58);

  width: 100vw;
  height: 10vh;
  justify-content: center;
  align-items: center;
}
#main-page {
  background-color: lightgreen;
  height: 160vh;
}
#message-box {
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  margin-left: 5rem;
  margin-right: 5rem;
  width: 90vw;
  height: 40vh;
  padding-bottom: 10rem;
  margin-bottom: 3rem;
}
</style>