<template>
  <div>
    <img src="https://roboteasy.tech/wp-content/uploads/2023/04/roboteasy.png" alt="Logo Roboteasy" style="width: 250px; height: auto" />
    <h1>Controle de Estoque</h1>
    <nav>
      <button @click="aba = 'cadastro'">Cadastro de Produto</button>
      <button @click="aba = 'entrada'">Entrada de Estoque</button>
      <button @click="aba = 'saida'">Saída de Estoque</button>
      <button @click="aba = 'historico'">Histórico</button>
    </nav>

    <div v-if="aba === 'cadastro'">
      <ProdutoForm />
    </div>
    <div v-if="aba === 'entrada'">
      <EntradaEstoque />
    </div>
    <div v-if="aba === 'saida'">
      <SaidaEstoque />
    </div>
    <div v-if="aba === 'historico'">
      <Historico />
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue';
import ProdutoForm from './components/ProdutoForm.vue';
import EntradaEstoque from './components/EntradaEstoque.vue';
import SaidaEstoque from './components/SaidaEstoque.vue';
import Historico from './components/Historico.vue';

const aba = ref('cadastro');
</script>