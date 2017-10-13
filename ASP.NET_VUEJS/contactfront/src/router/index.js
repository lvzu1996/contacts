import Vue from 'vue'
import Router from 'vue-router'


const Home = () => import('@/pages/Home')
const Add = () => import('@/pages/Add')
const Revice = () => import('@/pages/Revice')
const Success = () => import('@/pages/Success')
const Fail = () => import('@/pages/Fail')

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path:'/add',
      name:'Add',
      component:Add
    },
    {
      path:'/revice',
      name:'Revice',
      component:Revice
    },
    {
      path:'/success',
      name:'Success',
      component:Success
    },
    {
      path:'/fail',
      name:'Fail',
      component:Fail
    },
  ]
})
