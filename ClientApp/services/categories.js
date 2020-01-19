import axios from 'axios'

function getCategories() {
  return axios.get('categories/GetCategories')
    .then(response => { return response.data.payload })
}
function deleteCategory(id) {
  return axios.post('categories/deleteCategory/' + id)
    .then(response => { return response.data.payload })
}

export { getCategories, deleteCategory };
