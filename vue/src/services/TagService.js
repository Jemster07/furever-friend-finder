import axios from 'axios';

const http = axios.create({
  baseURL: "https://localhost:44315"
});

export default {

  GetTag(tagId) {
    return http.get(`/tags/${tagId}`);
  },

  CreateTag(newTag) {
    return axios.post('/tags/add', newTag);
  },

  UpdateTag(updatedTags) {
    return axios.put(`/tags/update/${updatedTags.tagId}`, updatedTags);
  },

}