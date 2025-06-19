import { createRouter, createWebHistory } from 'vue-router';
import EntradaEstoque from '../views/EntradaEstoque.vue';
import SaidaEstoque from '../views/SaidaEstoque.vue';
import HistoricoEstoque from '../views/HistoricoEstoque.vue';
import ProdutosEstoque from '../views/ProdutosEstoque.vue';

const routes = [
  { path: '/', redirect: '/produtos' },
  { path: '/produtos', component: ProdutosEstoque },
  { path: '/entrada', component: EntradaEstoque },
  { path: '/saida', component: SaidaEstoque },
  { path: '/historico', component: HistoricoEstoque }
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
});

export default router;