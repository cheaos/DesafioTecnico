<template>
  <form @submit.prevent="entrada">
    <select v-model="dto.produtoId">
      <option v-for="p in produtos" :key="p.id" :value="p.id">{{ p.descricao }}</option>
    </select>
    <input v-model.number="dto.quantidade" placeholder="Quantidade" type="number" />
    <input v-model.number="dto.valorFornecedor" placeholder="Valor" type="number" />
    <button>Adicionar Estoque</button>
  </form>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import api from '../services/api';

const produtos = ref([]);
const dto = ref({ produtoId: null, quantidade: null, valorFornecedor: null });

const entrada = async () => {
  try {
    await api.post('/produtos/entrada', dto.value);
    alert('Entrada registrada!');
  } catch (err) {
    alert('Erro ao registrar entrada');
  }
};

onMounted(async () => {
  const res = await api.get('/produtos');
  produtos.value = res.data;
});
</script>