<template>
  <div>
    <h2>Produtos</h2>
    <form @submit.prevent="salvar">
      <input v-model="produto.codigo" placeholder="Código" />
      <input v-model="produto.descricao" placeholder="Descrição" />
      <select v-model="produto.tipo">
        <option value="0">Eletrônico</option>
        <option value="1">Eletrodoméstico</option>
        <option value="2">Móvel</option>
      </select>
      <input v-model.number="produto.valorFornecedor" placeholder="Valor" />
      <input v-model.number="produto.quantidade" placeholder="Quantidade" />
      <button type="submit">Salvar</button>
    </form>

    <ul>
      <li
        v-for="p in produtos" 
        :key="p.id"
      >
        {{ p.codigo }} - {{ p.descricao }} - {{ p.quantidade }}
      </li>
    </ul>
  </div>
</template>

<script>
import estoqueService from '@/api/estoqueService';

export default {
  data() {
    return {
      produto: {
        codigo: '',
        descricao: '',
        tipo: 0,
        valorFornecedor: null,
        quantidade: null,
      },
      produtos: [],
    };
  },
  async mounted() {
    this.produtos = await estoqueService.listarProdutos();
  },
  methods: {
    async salvar() {
      await estoqueService.criarProduto(this.produto);
      this.produto = { codigo: '', descricao: '', tipo: 0, valorFornecedor: 0, quantidade: 0 };
      this.produtos = await estoqueService.listarProdutos();
    },
  },
};
</script>
