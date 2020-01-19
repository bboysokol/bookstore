import axios from 'axios'

function getBook(id) {
  return axios.get('books/GetBook' + '?id=' + id)
    .then(response => { return response.data.payload })

}
function getBooks(take, skip, category) {
  return axios.get('books/GetBooks' + '?take=' + take + '&skip=' + skip + '&category=' + category)
    .then(response => { return response.data.payload })
}

function addTopBooks() {
  return axios.post('books/AddTopBooks')
    .then(response => { return response.data.payload })
}

function getTopBooks() {
  return axios.get('books/GetTopBooks')
    .then(response => { return response.data.payload })
}

function deleteBook(isbn) {
  console.log("XD:");
  return axios.post('books/deleteBook/' + isbn)
    .then(response => { return response.data.payload })
}
export { getBooks, getBook, addTopBooks, getTopBooks, deleteBook };
