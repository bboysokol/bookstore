import CounterExample from 'components/counter-example'
import HomePage from 'components/home-page'
import AuthorForm from 'components/author-form'
import Authors from 'components/authors'
import Client from 'components/register-form'
import Login from 'components/login-form'
import Category from 'components/category-form'
import PublishHouses from 'components/publishHouse-form'
import BookForm from 'components/book-form'

export const routes = [
  { name: 'home', path: '/', component: HomePage, display: 'Home', icon: 'home' },
  { name: 'counter', path: '/counter', component: CounterExample, display: 'Counter', icon: 'graduation-cap' },
  { name: 'form', path: '/addauthor', component: AuthorForm, display: 'ASd', icon: 'graduation-cap' },
  { name: 'aithors', path: '/authors', component: Authors, display: 'Aasd', icon: 'graduation-cap' },
  { name: 'clients', path: '/register', component: Client, display: 'Register form', icon: 'graduation-cap' },
  { name: 'login', path: '/login', component: Login, display: 'Login', icon: 'graduation-cap' },
  { name: 'category', path: '/addcategory', component: Category, display: 'Cat', icon: 'graduation-cap' },
  { name: 'phouses', path: '/addphouses', component: PublishHouses, display: 'asdfsd', icon: 'graduation-cap' },
  { name: 'phousasdes', path: '/book', component: BookForm, display: 'asdfsd2', icon: 'graduation-cap' },
]
