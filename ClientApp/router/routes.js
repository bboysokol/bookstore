import CounterExample from 'components/counter-example'
import HomePage from '../containers/home-page'
import Houses from 'components/houses'
import Authors from 'components/authors'
import Books from 'components/books'
import Orders from 'components/orders'
import Cart from 'components/cart'
import Categories from 'components/categories'
import BookPage from '../containers/books-page'
import AdminPanel from '../containers/admin-page'

export const routes = [
  { name: 'home', path: '/', component: HomePage, display: 'Bookstore', visible: true },
  { name: 'phouses', path: '/publishinghouses', component: Houses, display: 'PHouses', visible: false },
  { name: 'books', path: '/books', component: Books, display: 'Books', visible: false },
  { name: 'cart', path: '/cart', component: Cart, display: 'Cart', visible: false },
  { name: 'categories', path: '/categories', component: Categories, display: 'Categories', visible: false },
  { name: 'orders', path: '/orders', component: Orders, display: 'Orders', visible: false },
  { name: 'counter', path: '/counter', component: CounterExample, display: 'Counter', icon: 'graduation-cap', visible: false },
  { name: 'aithors', path: '/authors', component: Authors, display: 'Aasd', icon: 'graduation-cap', visible: false },
  {
    name: 'admin', path: '/admin', component: AdminPanel, display: 'Admin Panel', visible: false, meta: {
      isAdmin: true
    }
  },
  { name: 'book-page', path: '/books/:category', component: BookPage, display: 'Book Page', visible: false },
]
