import Group from './containers/Group.vue'
import Groups from './containers/Groups.vue'
import Login from './containers/Login.vue'
import Test from './components/Test.vue'
import Register from './containers/Register.vue'

export const routes = [
  { path: '/signup', component: Register, meta: { requiresAnonymous: true } },
  { path: '/discover', component: Test },
  { path: '/login', component: Login, meta: { requiresAnonymous: true } },
  { path: '/group/:id', component: Group, meta: { requiresAuth: true } },
  { path: '/', component: Groups },
  { path: '*', redirect: '/' }
];