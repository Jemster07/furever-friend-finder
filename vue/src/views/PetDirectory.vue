<template>
  <div id="main-page">

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
              v-bind:to="{ name: 'home' }"
              style="color: black"
              >HOME</router-link
            >
          </li>
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
            v-if="$store.state.token != ''"
            >Logout</router-link
          >
        </div>
      </div>
    </nav>

    <div id="pets-list">
      
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
  </div>
</template>

<script>
export default {
  name: "petdirectory",
};
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
  #page-title{
    margin-left: 2rem;
  }
  #main-page{
    height: 300vh;
    background-color: lightgreen;
  }
  #header{
    display:flex;
    background-color: white;
    justify-content: space-between;
    align-items: center;
    height: 10vh;
    border-bottom: 1px solid gray;

  }
  #navigator {
  display: flex;
  align-items: center;
  justify-content: space-between;
  border-bottom: 1px solid gray;
  background-color: white;
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


</style>
