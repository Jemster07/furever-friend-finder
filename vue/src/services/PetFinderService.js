import axios from 'axios';

const http = axios.create({
  baseURL: "https://localhost:44315"
});

export default {

  ListPetFinderAnimals(petType) {
    return http.get(`/petfinder/type/${petType}`);
  },

  ListPetFinderBreeds(breed) {
    return axios.get(`/petfinder/breed/${breed}`);
  },

  ListPetFinderByLocation(address) {
    return axios.get(`/petfinder/location/${address}`);
  },

}