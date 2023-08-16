import axios from 'axios';

const http = axios.create({
  baseURL: "https://localhost:44315"
});

export default {

  GetAttribute(attributeId) {
    return http.get(`/attributes/${attributeId}`);
  },

  CreateAttribute(newAttributes) {
    return axios.post('/attributes/add', newAttributes);
  },

  UpdateAttribute(updatedAttributes) {
    return axios.put(`/attributes/update/${updatedAttributes.attributeId}`, updatedAttributes);
  },

}