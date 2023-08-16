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

  GetAdopter(petId) {
    return http.get(`/directory/friend/adopter/${petId}`);
  },

  ListPendingUsers() {
    return http.get('/application/list');
  },

  ApproveRejectApp(updatedUser) {
    return axios.put(`/application/update/${updatedUser.username}`, updatedUser);
  },

  RegisterAdopter(adopter) {
    return axios.post('/directory/friend/adopter/register', adopter);
  },

  UpdateAdopterStatus(username) {
    return axios.put(`/directory/friend/adopter/update/${username}`, username);
  },

}