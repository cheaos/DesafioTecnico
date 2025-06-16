<script setup>
import { RouterLink, RouterView } from 'vue-router'
</script>

<!-- Parte HTML: Aqui estão os links para as telas no Frontend de Lista de Produtos, Cadastrar Produto e Movimentações -->

<template>
  <header>
    <div class="wrapper">
      <nav>
        <RouterLink to="/">Lista de Produtos</RouterLink>
        <RouterLink to="/cadastrar">Cadastrar Produto</RouterLink>
        <RouterLink to="/movimentacoes">Movimentações</RouterLink>
      </nav>
    </div>
  </header>

  <RouterView />
</template>

<style scoped>
/* Parce CSS: Formatação do menu de navegação */
header {
  line-height: 1.5;
  max-height: 100vh;
}
nav {
  width: 100%;
  font-size: 1rem;
  text-align: center;
  margin-top: 2rem;
  margin-bottom: 2rem;
}
nav a {
  color:aqua;
  display: inline-block;
  padding: 0 1rem;
  border-left: 1px solid var(--color-border);
}
nav a:first-of-type {
  border: 0;
}
</style>