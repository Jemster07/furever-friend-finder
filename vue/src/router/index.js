import Vue from 'vue'
import Router from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Logout from '../views/Logout.vue'
import Register from '../views/Register.vue'
import FriendDirectory from '../views/FriendDirectory.vue'
import NewFriend from '../views/NewFriend.vue'
import NewPet from '../views/NewPet.vue'
import PendingApp from '../views/PendingApp.vue'
import PetDirectory from '../views/PetDirectory.vue'

import store from '../store/index'

Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: '/direct/pet',
      name: 'petdirectory',
      component: PetDirectory,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/pending',
      name: 'pendingapp',
      component: PendingApp,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/newpet',
      name: 'newpet',
      component: NewPet,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/login/newfriend',
      name: 'newfriend',
      component: NewFriend,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/direct/friend',
      name: 'frienddirectory',
      component: FriendDirectory,
      meta: {
        requiresAuth: true
      }
    }
  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '') {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
