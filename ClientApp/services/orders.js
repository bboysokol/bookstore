import axios from 'axios'

function addOrder(bookId, clientId) {
  axios.post('orders/AddOrder', {
    bookId: bookId,
    clientId: clientId
  })

}

function getOrders(take, skip) {
  return axios.get('orders/GetOrders' + '?take=' + take + '&skip=' + skip)
    .then(response => { return response.data.payload })
}

function deleteOrder(id) {
  return axios.post('orders/deleteOrder/' + id)
    .then(response => { return response.data.payload })
}

function changeState(id) {
  return axios.post('orders/changeState/' + id)
    .then(response => { return response.data.payload })
}


export { addOrder, getOrders, deleteOrder, changeState };
