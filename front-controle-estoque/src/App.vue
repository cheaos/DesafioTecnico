<template>
  <div id="app">
    <img
      alt="Vue logo"
      src="./assets/imgEstoqueEasy.png"
      class="logo"
    >
    
    <h1>Controle de Estoque</h1>
    <nav>
      <router-link to="/produtos">Produtos</router-link> |
      <router-link to="/entrada">Entrada</router-link> |
      <router-link to="/saida">Saída</router-link> |
      <router-link to="/historico">Histórico</router-link>
    </nav>
    <router-view />
  </div>
</template>


<script>
import './assets/style.css';

export default {
  name: 'App',
};
</script>
