import axios from 'axios';

const http = axios.create({
  baseURL: "https://localhost:44315"
});

export default {

    GetPetDirectory() {
        return http.get('/directory/pet');
    },

    ListPetsByZip(zip) {
        return http.get(`/directory/pet/zip/${zip}`);
    },
    
    ListPetsByAttributes(attributes) {
        return http.get(`/directory/pet/attributes/${attributes}`);
    },

    ListPetsByEnvironments(environment) {
        return http.get(`/directory/pet/environment/${environment}`);
    },

    ListPetsByTags(tags) {
        return http.get(`/directory/pet/tags/${tags}`);
    },

    GetPet(petId) {
        return http.get(`/directory/pet/${petId}`);
    },

    UpdatePet(updatedPet) {
        return axios.put(`/directory/pet/update/${updatedPet.petId}`, updatedPet);
      },    

    AddPet(newPet) {
        return axios.post('/directory/pet/add', newPet);
    },
    
}