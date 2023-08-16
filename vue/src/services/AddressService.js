import axios from 'axios';

const http = axios.create({
  baseURL: "https://localhost:44315"
});

export default {

  GetAddress(addressId) {
    return http.get(`/address/${addressId}`);
  },

  CreateAddress(newAddress) {
    return axios.post('/address/add', newAddress);
  },

  UpdateAddress(updatedAddress) {
    return axios.put(`/address/update/${updatedAddress.addressId}`, updatedAddress);
  },

}