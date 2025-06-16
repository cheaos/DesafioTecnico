<script setup>
import { ref, onMounted } from 'vue';
import axios from 'axios';

  /* lista de todos os produtos */
const listaProdutos = ref([]);

/* guarda resposta do formulário para a Entrada de produto */
const formEntrada = ref({
  produtoId: null, /* starta nulo */
  quantidade: 1,
  novoValorFornecedor: 0.0
});

/* guarda resposta do formulário para a Saida de produto */
const formSaida = ref({
  produtoId: null, /* Starta nulo */
  quantidade: 1,
  valorVenda: 0.0
});

onMounted(async () => {
  try {
    /* busca a lista de produtos para carregar ela*/
    const response = await axios.get('https://localhost:7010/api/produtos');
    listaProdutos.value = response.data;
  } catch (error) {
    console.error("Erro ao carregar a lista de produtos:", error);
    alert("Não foi possível carregar os produtos. Verifique se a API está rodando.");
  }
});

/* função chamada pelo formulário de Entrada, se não tem valor pede para selecionar um Produto, depois que dá certo a entrada ele recarrega com estoque atualizado */
/* tratado para aparecer mensagem caso dê erro*/
const registrarEntrada = async () => {
  if (!formEntrada.value.produtoId) {
    alert("Por favor, selecione um produto.");
    return;
  }
  try {
    await axios.post('https://localhost:7010/api/movimentacoes/entrada', formEntrada.value);
    alert('Entrada registrada com sucesso!');
    location.reload(); 
  } catch (error) {
    console.error("Erro ao registrar entrada:", error);
    alert(`Falha ao registrar entrada: ${error.response?.data}`);
  }
};

/* função chamada pelo formulário de Saida, se não tem valor pede para selecionar um Produto, depois que dá certo a saída ele recarrega com estoque atualizado */
/* tratado para aparecer mensagem caso dê erro*/
const registrarSaida = async () => {
  if (!formSaida.value.produtoId) {
    alert("Por favor, selecione um produto.");
    return;
  }
  try {
    await axios.post('https://localhost:7010/api/movimentacoes/saida', formSaida.value);
    alert('Saída registrada com sucesso!');
    location.reload();
  } catch (error) {
    console.error("Erro ao registrar saída:", error);
    alert(`Falha ao registrar saída: ${error.response?.data}`);
  }
};
</script>
<!-- toda a parte HTML e CSS da página -->
<template>
  <div class="container">
    <h1>Movimentação de Estoque</h1>
    <div class="movimentacoes-wrapper">
      <div class="form-section">
        <h2>Registrar Entrada</h2>
        <form @submit.prevent="registrarEntrada">
          <div class="form-group">
            <label>Produto:</label>
            <select v-model="formEntrada.produtoId" required>
              <option disabled :value="null">Selecione um produto</option>
              <option v-for="produto in listaProdutos" :key="produto.id" :value="produto.id">
                {{ produto.descricao }} (Estoque: {{ produto.quantidadeEstoque }})
              </option>
            </select>
          </div>
          <div class="form-group">
            <label>Quantidade a Adicionar:</label>
            <input type="number" v-model.number="formEntrada.quantidade" required min="1">
          </div>
          <div class="form-group">
            <label>Valor de Entrada:</label>
            <input type="number" step="0.01" v-model.number="formEntrada.novoValorFornecedor" required>
          </div>
          <button type="submit">Registrar Entrada</button>
        </form>
      </div>

      <div class="form-section">
        <h2>Registrar Saída</h2>
        <form @submit.prevent="registrarSaida">
          <div class="form-group">
            <label>Produto:</label>
            <select v-model="formSaida.produtoId" required>
              <option disabled :value="null">Selecione um produto</option>
              <option v-for="produto in listaProdutos" :key="produto.id" :value="produto.id">
                {{ produto.descricao }} (Estoque: {{ produto.quantidadeEstoque }})
              </option>
            </select>
          </div>
          <div class="form-group">
            <label>Quantidade a Retirar:</label>
            <input type="number" v-model.number="formSaida.quantidade" required min="1">
          </div>
          <div class="form-group">
            <label>Valor da Venda (por unidade):</label>
            <input type="number" step="0.01" v-model.number="formSaida.valorVenda" required>
          </div>
          <button type="submit">Registrar Saída</button>
        </form>
      </div>
    </div>
  </div>
</template>

<style scoped>
.container {
  max-width: 1200px;
  margin: auto;
  padding: 1rem;
}

h1{
  color:aqua;
  text-align: center;
}

h2 {
  text-align: center;
}
.movimentacoes-wrapper {
  display: flex;
  justify-content: space-around;
  gap: 2rem;
  margin-top: 2rem;
}
.form-section {
  width: 45%;
  border: 1px solid #ccc;
  padding: 1.5rem;
  border-radius: 8px;
  background-color: #1b1a1a;
}
.form-group {
  margin-bottom: 1rem;
}
label {
  display: block;
  margin-bottom: 0.5rem;
}
input, select {
  width: 100%;
  padding: 0.5rem;
  font-size: 1rem;
  box-sizing: border-box;
}
button {
  width: 100%;
  padding: 0.75rem;
  font-size: 1rem;
  cursor: pointer;
  background-color: #2c3e50;
  color: white;
  border: none;
  border-radius: 4px;
}
button:hover {
  background-color: #3a526a;
}
</style>