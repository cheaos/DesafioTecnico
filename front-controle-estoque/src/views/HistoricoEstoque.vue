<template>
  <div>
    <h2>Histórico de Movimentações</h2>
    <table>
      <thead>
        <tr>
          <th>Data</th>
          <th>Tipo</th>
          <th>Produto</th>
          <th>Quantidade</th>
          <th>Valor</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="m in historico" :key="m.id">
          <td>{{ new Date(m.data).toLocaleString() }}</td>
          <td>{{ m.tipo }}</td>
          <td>{{ m.produtoDescricao }}</td>
          <td>{{ m.quantidade }}</td>
          <td>{{ m.valor.toFixed(2) }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import estoqueService from '@/api/estoqueService';

export default {
  data() {
    return {
      historico: []
    };
  },
  async mounted() {
    this.historico = await estoqueService.listarMovimentacoes();
  }
};
</script>
