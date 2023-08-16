import axios from 'axios';

const http = axios.create({
  baseURL: "https://localhost:44315"
});

export default {

  GetFriendDirectory() {
    return http.get('/directory/friend');
  },

  GetUser(username) {
    return http.get(`/directory/friend/${username}`);
  },

  GetAdopter(adopterId) {
    return http.get(`/directory/friend/${adopterId}`);
  },

  ListPendingUsers() {
    return http.get('/application/list');
  },

  ApproveRejectApp(updatedUser) {
    return axios.put(`/application/update/${updatedUser.username}`, updatedUser);
  },

  //add RegisterAdopter method

}