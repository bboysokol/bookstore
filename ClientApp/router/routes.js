import CounterExample from 'components/counter-example'
import HomePage from 'components/home-page'
import AuthorForm from 'components/author-form'
import Authors from 'components/authors'

export const routes = [
  { name: 'home', path: '/', component: HomePage, display: 'Home', icon: 'home' },
  { name: 'counter', path: '/counter', component: CounterExample, display: 'Counter', icon: 'graduation-cap' },
  { name: 'form', path: '/addauthor', component: AuthorForm, display: 'ASd', icon: 'graduation-cap' },
  { name: 'aithors', path: '/authors', component: Authors, display: 'Aasd', icon: 'graduation-cap' },
]
