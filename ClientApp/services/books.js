import axios from 'axios'

function getBooksByCategories() {
  return axios.get('books/GetBooksByCategory')
    .then(response => { return response.data.payload })
}

export { getBooksByCategories };
