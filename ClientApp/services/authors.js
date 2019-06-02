import axios from 'axios'

function getAuthors() {
  return axios.get('authors/GetAuthors')
    .then(response => {
      return response.data.payload;
    })
}

function deleteAuthor(id) {
  return axios.post('authors/deleteAuthor/' + id)
    .then(response => { return response.data.payload })
}
export { getAuthors, deleteAuthor };
