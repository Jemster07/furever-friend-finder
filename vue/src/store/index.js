import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
/* this is for if we have already logged in */
let currentToken = localStorage.getItem('token')
let currentUser = '';
try{
  currentUser = JSON.parse(localStorage.getItem('user'));
} catch(e) {
  currentToken = '';
  localStorage.removeItem('token');
  localStorage.removeItem('user');
}


if(currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    pendingUsers: []
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      /* for when we log in through the front end. Saving the data */
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      /* for when we log in through the front end. Saving the data */
      state.user = user;
      localStorage.setItem('user',JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    ADD_PENDING_USERS(state,userList)
    {
      state.pendingUsers = userList;
    },
    UPDATE_PENDING(state,updatedUser)
    {
      let focusUser = state.pendingUsers.find(u => u.userId = updatedUser.userId);
      focusUser.applicationStatus = updatedUser.applicationStatus;
    }
  }
})
