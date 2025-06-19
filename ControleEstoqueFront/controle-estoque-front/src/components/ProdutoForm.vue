<template>
  <form @submit.prevent="salvar">
    <input v-model="produto.codigo" placeholder="Código" />
    <input v-model="produto.descricao" placeholder="Descrição" />
    <select v-model="produto.tipoProduto">
      <option>Eletrônico</option>
      <option>Eletrodoméstico</option>
      <option>Móvel</option>
    </select>
    <input v-model.number="produto.valorFornecedor" placeholder="Valor" type="number" />
    <input v-model.number="produto.quantidadeEstoque" placeholder="Quantidade" type="number" />
    <button>Salvar</button>
  </form>
</template>

<script setup>
import { ref } from 'vue';
import api from '../services/api';

const produto = ref({
  codigo: '',
  descricao: '',
  tipoProduto: '',
  valorFornecedor: null,
  quantidadeEstoque: null
});

const salvar = async () => {
  try {
    await api.post('/produtos', produto.value);
    alert('Produto cadastrado!');
  } catch (err) {
    alert('Erro ao salvar');
  }
};
</script>