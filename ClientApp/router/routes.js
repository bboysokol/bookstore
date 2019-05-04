import CounterExample from 'components/counter-example'
import HomePage from '../containers/home-page'
import AuthorForm from 'components/author-form'
import Authors from 'components/authors'
import Login from 'components/login-form'
import Category from 'components/category-form'
import PublishHouses from 'components/publishHouse-form'
import BookForm from 'components/book-form'
import BookPage from '../containers/books-page'

export const routes = [
  { name: 'home', path: '/', component: HomePage, display: 'Bookstore', visible: true },
  { name: 'counter', path: '/counter', component: CounterExample, display: 'Counter', icon: 'graduation-cap', visible: false },
  { name: 'form', path: '/addauthor', component: AuthorForm, display: 'ASd', icon: 'graduation-cap', visible: false },
  { name: 'aithors', path: '/authors', component: Authors, display: 'Aasd', icon: 'graduation-cap', visible: false },
  { name: 'login', path: '/login', component: Login, display: 'Login', icon: 'graduation-cap', visible: false },
  { name: 'category', path: '/addcategory', component: Category, display: 'Cat', icon: 'graduation-cap', visible: false },
  { name: 'phouses', path: '/addphouses', component: PublishHouses, display: 'asdfsd', icon: 'graduation-cap', visible: false },
  { name: 'phousasdes', path: '/book', component: BookForm, display: 'asdfsd2', icon: 'graduation-cap', visible: false },
  { name: 'book-page', path: '/books/:category', component: BookPage, display: 'Book Page', visible: false },
]
