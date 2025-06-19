<template>
  <div>
    <h2>Entrada de Estoque</h2>
    <form @submit.prevent="registrarEntrada">
      <select v-model="entrada.produtoId">
        <option disabled value="">Selecione um produto</option>
        <option v-for="produto in produtos" :value="produto.id" :key="produto.id">
          {{ produto.descricao }}
        </option>
      </select>
      <input type="number" v-model.number="entrada.quantidade" placeholder="Quantidade" />
      <input type="number" v-model.number="entrada.valor" placeholder="Valor fornecedor" />
      <button type="submit">Registrar Entrada</button>
    </form>
  </div>
</template>

<script>
import estoqueService from '@/api/estoqueService';

export default {
  data() {
    return {
      produtos: [],
      entrada: {
        produtoId: '',
        quantidade: null,
        valor: null
      }
    };
  },
  async mounted() {
    this.produtos = await estoqueService.listarProdutos();
  },
  methods: {
    async registrarEntrada() {
      await estoqueService.registrarEntrada(this.entrada);
      alert('Entrada registrada com sucesso!');
      this.entrada = { produtoId: '', quantidade: 0, valor: 0 };
    }
  }
};
</script>
