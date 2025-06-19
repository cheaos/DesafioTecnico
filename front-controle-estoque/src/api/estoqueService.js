import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:7071/api',
});

export default {
  async listarProdutos() {
    const response = await api.get('/Produtos');
    return response.data;
  },

  async criarProduto(produto) {
    return await api.post('/Produtos', produto);
  },

  async registrarEntrada(dados) {
    return await api.post('/Estoque/entrada', dados);
  },

  async registrarSaida(dados) {
    return await api.post('/Estoque/saida', dados);
  },

  async listarMovimentacoes() {
    const response = await api.get('/Estoque/historico');
    return response.data;
  },
};