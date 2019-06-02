import axios from 'axios'

function getPublishingHouses() {
  return axios.get('publishinghouses/GetPublishingHouses')
    .then(response => {
      return response.data.payload;
    })
}

function deletePublishingHouses(id) {
  return axios.post('publishinghouses/deletePublishingHouse/' + id)
    .then(response => { return response.data.payload })
}
export { getPublishingHouses, deletePublishingHouses };
