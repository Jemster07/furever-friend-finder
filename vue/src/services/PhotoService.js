import axios from 'axios';

const http = axios.create({
  baseURL: "https://localhost:44315"
});

export default {

  RetrieveImage(photoId) {
    return http.get(`/photo/retrieve/${photoId}`);
  },

  GeneratePhotoList(petId) {
    return http.get(`/photo/list/${petId}`);
  },

  SaveUserImage(formFile, petId) {
    return axios.post(`/photo/save/${petId}`, formFile);
  },

  DeletePhoto(photoId) {
    return axios.put(`/photo/delete/${photoId}`, photoId);
  },

}