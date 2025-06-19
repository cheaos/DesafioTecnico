<template>
  <div>
    <h2>Saída de Estoque</h2>
    <form @submit.prevent="registrarSaida">
      <select v-model="saida.produtoId">
        <option disabled value="">Selecione um produto</option>
        <option v-for="produto in produtos" :value="produto.id" :key="produto.id">
          {{ produto.descricao }} (Estoque: {{ produto.quantidade }})
        </option>
      </select>
      <input type="number" v-model.number="saida.quantidade" placeholder="Quantidade" />
      <input type="number" v-model.number="saida.valor" placeholder="Valor venda" />
      <button type="submit">Registrar Saída</button>
    </form>
  </div>
</template>

<script>
import estoqueService from '@/api/estoqueService';

export default {
  data() {
    return {
      produtos: [],
      saida: {
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
    async registrarSaida() {
      
      try {
        await estoqueService.registrarSaida(this.saida);
        alert('Saída registrada com sucesso!');
        this.saida = { produtoId: '', quantidade: 0, valor: 0 };
      } catch (error) {
        alert('Erro: Estoque insuficiente ou outro problema.');
      } finally {
        this.produtos = await estoqueService.listarProdutos(); 
      }
    } 
  }
};
</script>
