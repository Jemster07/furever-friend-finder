<template>
  <div id="main-page">

    <div id="header">

      <div id="page-title" class="has-text-left is-size-2">
        All Pets 
      </div>

      <div class="has-text-right py-4 px-4">
        <router-link :to="{ name: 'home' }" class="button is-light">
          Home
        </router-link>
        
        <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''" class="button is-light mx-3">
      Logout
    </router-link>
      </div>

    </div>

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
</style>
