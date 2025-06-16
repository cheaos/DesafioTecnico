<script setup>
import { ref } from 'vue';
import axios from 'axios';
import { useRouter } from 'vue-router';

const router = useRouter();

/* vai guardar os dados do formulário*/
const novoProduto = ref({
  codigo: '',
  descricao: '',
  tipo: 'Eletronico', /* valor inicial */
  valorFornecedor: 0.0,
  quantidadeEstoque: 0
});

/* vai ser chamado qnd o formulario for enviado, ou seja quando clicar em cadastrar */
const cadastrarProduto = async () => {
  try {
    const apiUrl = 'https://localhost:7010/api/produtos'; 
    
    /* faz a requisição POST*/
    await axios.post(apiUrl, novoProduto.value);
    
    /* mensagem de erro ou acerto*/
    alert('Produto cadastrado com sucesso!');
    router.push('/'); /* vai redicecionar pra lista de produto*/
  } catch (error) {
    console.error("Erro ao cadastrar produto:", error);
    alert('Falha ao cadastrar o produto.');
  }
};
</script>

<!-- toda a parte HTML e CSS do site -->
<template>
  <div class="cadastro">
    <h1>Cadastrar Novo Produto</h1>
    <form @submit.prevent="cadastrarProduto">
      <div class="form-group">
        <label for="codigo">Código:</label>
        <input type="text" id="codigo" v-model="novoProduto.codigo" required>
      </div>
      <div class="form-group">
        <label for="descricao">Descrição:</label>
        <input type="text" id="descricao" v-model="novoProduto.descricao" required>
      </div>
      <div class="form-group">
        <label for="tipo">Tipo de Produto:</label>
        <select id="tipo" v-model="novoProduto.tipo">
          <option>Eletronico</option>
          <option>Eletrodomestico</option>
          <option>Movel</option>
        </select>
      </div>
      <div class="form-group">
        <label for="valorFornecedor">Valor do Fornecedor:</label>
        <input type="number" step="0.01" id="valorFornecedor" v-model.number="novoProduto.valorFornecedor" required>
      </div>
      <div class="form-group">
        <label for="quantidadeEstoque">Quantidade Inicial:</label>
        <input type="number" id="quantidadeEstoque" v-model.number="novoProduto.quantidadeEstoque" required>
      </div>
      <button type="submit">Cadastrar</button>
    </form>
  </div>
</template>

<style scoped>
.cadastro {
  max-width: 500px;
  margin: auto;
}
.form-group {
  margin-bottom: 1rem;
}
label {
  color:aqua;
  display: block;
  margin-bottom: 0.5rem;
}
input, select {
  width: 100%;
  padding: 0.5rem;
  font-size: 1rem;
}
h1 {
  color:rgb(128, 228, 228);
}
button {
  padding: 0.75rem 1.5rem;
  font-size: 1rem;
  cursor: pointer;
}
</style>