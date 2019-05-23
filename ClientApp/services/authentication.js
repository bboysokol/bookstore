import axios from 'axios'

function getBooksByCategories() {
  return axios.get('books/GetBooksByCategory')
    .then(response => { return response.data.payload })
}

function getBooks() {
  return axios.get('books/GetBooks')
    .then(response => { return response.data.payload })
}

export { getBooksByCategories, getBooks };
