import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

/* essa rotina vai nos dar qual tela deve ser exibida pro usuario */
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/cadastrar',
      name: 'cadastrar',
      /* carregar o componente dinamicamente */
      component: () => import('../views/CadastroView.vue')
    },
    {
      path: '/movimentacoes',
      name: 'movimentacoes',
      /* carregar o componente dinamicamente 2*/
      component: () => import('../views/MovimentacaoView.vue')
    }
  ]
})

export default router