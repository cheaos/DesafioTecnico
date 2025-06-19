<template>
  <div>
    <h2>Histórico de Movimentações</h2>
    <table>
      <thead>
        <tr>
          <th>Produto</th>
          <th>Tipo</th>
          <th>Quantidade</th>
          <th>Valor Venda</th>
          <th>Data</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="mov in movimentacoes" :key="mov.id">
          <td>{{ mov.produtoDescricao }}</td>
          <td>{{ mov.tipoMovimentacao }}</td>
          <td>{{ mov.quantidade }}</td>
          <td>{{ mov.valorVenda || '-' }}</td>
          <td>{{ new Date(mov.dataMovimentacao).toLocaleString() }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import api from '../services/api';

const movimentacoes = ref([]);

onMounted(async () => {
  try {
    const res = await api.get('/produtos/historico');
    movimentacoes.value = res.data.sort((a, b) => new Date(b.dataMovimentacao) - new Date(a.dataMovimentacao));
  } catch (err) {
    console.error('Erro ao buscar histórico', err);
  }
});
</script>