import axios from 'axios';

const http = axios.create({
  baseURL: "https://localhost:44315"
});

export default {

    GetPetDirectory() {
        return http.get('/directory/pet');
    },

    ListPetsByZip(zip) {
        return http.get(`/directory/pet/${zip}`);
    },
    
    ListPetsByAttributes(attributes) {
        return http.get(`/directory/pet/${attributes}`);
    },

    ListPetsByEnvironments(environment) {
        return http.get(`/directory/pet/${environment}`);
    },

    ListPetsByTags(tags) {
        return http.get(`/directory/pet/${tags}`);
    },

    GetPet(petId) {
        return http.get(`/directory/pet/${petId}`);
    },

    UpdatePet(updatedPet) {
        return axios.put(`/directory/pet/${updatedPet.petId}/update`, updatedPet);
      },    

    AddPet(newPet) {
        return axios.post('/directory/pet/add', newPet);
    },
    
}