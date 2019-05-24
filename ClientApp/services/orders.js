import axios from 'axios'

function addOrder(bookId, clientId) {
    axios.post('orders/AddOrder', {
      bookId: bookId,
      clientId: clientId
  })
  
}

//function getBooks() {
//  return axios.get('books/GetBooks')
//    .then(response => { return response.data.payload })
//}

export { addOrder };
