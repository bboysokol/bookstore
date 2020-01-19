import HomePage from '../containers/home-page'
import Houses from 'components/houses'
import Authors from 'components/authors'
import Books from 'components/books'
import Orders from 'components/orders'
import Cart from 'components/cart'
import Categories from 'components/categories'
import BookPage from '../containers/books-page'
import AdminPanel from '../containers/admin-page'
import PageNotFound from 'components/404'
import Book from 'components/book'

export const routes = [
  { name: 'home', path: '/', component: HomePage, display: 'Bookstore', visible: true },
  {
    name: 'phouses', path: '/publishinghouses', component: Houses, display: 'PHouses', visible: false, meta: {
      isAdmin: true
    } },
  {
    name: 'books', path: '/books', component: Books, display: 'Books', visible: false, meta: {
      isAdmin: true
    } },
  { name: 'cart', path: '/cart', component: Cart, display: 'Cart', visible: false },
  {
    name: 'categories', path: '/categories', component: Categories, display: 'Categories', visible: false, meta: {
      isAdmin: true
    } },
  {
    name: 'orders', path: '/orders', component: Orders, display: 'Orders', visible: false, meta: {
      isAdmin: true
    } },
  {
    name: 'authors', path: '/authors', component: Authors, display: 'Aasd', icon: 'graduation-cap', visible: false, meta: {
      isAdmin: true
    } },
  {
    name: 'admin', path: '/admin', component: AdminPanel, display: 'Admin Panel', visible: false, meta: {
      isAdmin: true
    }
  },

  { name: 'book', path: '/book/:isbn', component: Book, display: 'Book', visible: false },
  { name: 'book-page', path: '/books/:category', component: BookPage, display: 'Book Page', visible: false },
  
  {
    name: '404', path: '*', component: PageNotFound, display: 'PageNotFound', visible: false
  },
]
