import axios from 'axios';

const http = axios.create({
  baseURL: "https://localhost:44315"
});

export default {

  GetEnvironment(environmentId) {
    return http.get(`/environments/${environmentId}`);
  },

  CreateEnvironment(newEnvironment) {
    return axios.post('/environments/add', newEnvironment);
  },

  UpdateEnvironment(updatedEnvironment) {
    return axios.put(`/environments/update/${updatedEnvironment.environmentId}`, updatedEnvironment);
  },

}