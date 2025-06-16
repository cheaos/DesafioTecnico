<script setup>
import { ref, onMounted } from 'vue'
import axios from 'axios'

  /* variável para a lista de produtos*/
const produtos = ref([]);

  /* buscar os dados de produtos da API */
onMounted(async () => {
  try {
    const response = await axios.get('https://localhost:7010/api/produtos');
    produtos.value = response.data;
  } catch (error) {
    console.error("Erro ao buscar produtos:", error);
  }
});

  /* excluir o produto com base no ID*/
const excluirProduto = async (id) => {
  /* pede confirmação antes de excluir, p/segurança*/
  if (!confirm('Você tem certeza que deseja excluir este produto?')) {
    return;
  }

  try {
    /* monta o url da aAPI*/
    const apiUrl = `https://localhost:7010/api/produtos/${id}`;
    
    /* faz o delete pra API */
    await axios.delete(apiUrl);

    /* atualiza a lista removendo o produto da tela instantaneamente sem precisa recarregar página */
    produtos.value = produtos.value.filter(p => p.id !== id);
    
    alert('Produto excluído com sucesso!');

  } catch (error) {
    console.error("Erro ao excluir produto:", error);
    alert('Falha ao excluir o produto.');
  }
};

/* formatação do HTML do site, informando a table que é a lista de produtos e as informações que ela recebe, junto do botão "Excluir", tudo integrado com a API hehe*/

</script>

<template>
  <main>

    <h1>Lista de Produtos</h1>
    
    <table>
      <thead>
        <tr>
          <th>Código</th>
          <th>Descrição</th>
          <th>Estoque</th>
          <th>Valor do Fornecedor</th>
          <th>Ações</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="produto in produtos" :key="produto.id">
          <td>{{ produto.codigo }}</td>
          <td>{{ produto.descricao }}</td>
          <td>{{ produto.quantidadeEstoque }}</td>
          <td>{{ produto.valorFornecedor }}</td>
          <td>
            <button @click="excluirProduto(produto.id)">Excluir</button>
          </td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<style scoped>
      main 
      {
  position: relative;
      }
/* formatação da tabela */
table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 20px;
}
th {
  background-color: rgb(94, 171, 202);
  color: black;
  border: 1px solid #ddd;
  padding: 8px;
  text-align: left;
}
td {
  border: 1px solid #ddd;
  padding: 8px;
  text-align: left;
}
thead {
  background-color: #f2f2f2;
}

/* formatação para o botão de excluir */
button {
  padding: 5px 10px;
  cursor: pointer;
  background-color: #ff4d4d;
  color: white;
  border: none;
  border-radius: 4px;
}
button:hover {
  background-color: #cc0000;
}
</style>