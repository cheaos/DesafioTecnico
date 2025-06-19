<template>
  <form @submit.prevent="saida">
    <select v-model="dto.produtoId">
      <option v-for="p in produtos" :key="p.id" :value="p.id">{{ p.descricao }}</option>
    </select>
    <input v-model.number="dto.quantidade" placeholder="Quantidade" type="number" />
    <input v-model.number="dto.valorVenda" placeholder="Valor Venda" type="number" />
    <button>Remover Estoque</button>
  </form>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import api from '../services/api';

const produtos = ref([]);
const dto = ref({ produtoId: null, quantidade: null, valorVenda: null });

const saida = async () => {
  try {
    await api.post('/produtos/saida', dto.value);
    alert('Saída registrada!');
  } catch (err) {
    alert(err.response?.data?.message || 'Erro ao registrar saída');
  }
};

onMounted(async () => {
  const res = await api.get('/produtos');
  produtos.value = res.data;
});
</script>