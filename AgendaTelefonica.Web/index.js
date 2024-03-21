export const handleGet = async () => {
  try {
    const response = await fetch("http://localhost:5266/api/contato");
    if (!response.ok) {
      throw new Error("HTTP error " + response.status);
    }
    const data = await response.json();
    return data;
  } catch (error) {
    console.log("Contato Não Encontrado: " + error.message);
  }
};

const dados = document.getElementById("dados");

const contatos = await handleGet();

// Limpa os dados existentes
dados.innerHTML = "";

// Cria a tabela e adiciona cabeçalhos
const table = document.createElement("table");
const thead = document.createElement("thead");
const tbody = document.createElement("tbody");
const headers = [
  "ID",
  "Nome",
  "Idade",
  "ID Tel",
  "Número",
  "ID Contato",
  "Ações",
];
const tr = document.createElement("tr");

headers.forEach((header) => {
  const th = document.createElement("th");
  th.textContent = header;
  tr.appendChild(th);
});

thead.appendChild(tr);
table.appendChild(thead);

// Itera sobre cada contato
contatos.forEach((contato) => {
  const tr = document.createElement("tr");

  // Cria um novo elemento para cada propriedade do contato
  const id = document.createElement("td");
  const nome = document.createElement("td");
  const idade = document.createElement("td");

  // Define o texto de cada elemento
  id.textContent = contato.id;
  nome.textContent = contato.nome;
  idade.textContent = contato.idade;

  // Adiciona os elementos à linha da tabela
  tr.appendChild(id);
  tr.appendChild(nome);
  tr.appendChild(idade);

  // Itera sobre cada telefone do contato
  contato.telefone.forEach((telefone) => {
    // Cria um novo elemento para cada propriedade do telefone
    const idTel = document.createElement("td");
    const numero = document.createElement("td");
    const idContato = document.createElement("td");

    // Define o texto de cada elemento
    idTel.textContent = telefone.id;
    numero.textContent = telefone.numero;
    idContato.textContent = telefone.idContato;

    // Adiciona os elementos à linha da tabela
    tr.appendChild(idTel);
    tr.appendChild(numero);
    tr.appendChild(idContato);
  });

  // Cria botões de editar e excluir
  const actions = document.createElement("td");
  const editBtn = document.createElement("button");
  const deleteBtn = document.createElement("button");

  editBtn.textContent = "Editar";
  deleteBtn.textContent = "Excluir";

  // Adiciona os botões à linha da tabela
  actions.appendChild(editBtn);
  actions.appendChild(deleteBtn);
  tr.appendChild(actions);

  // Adiciona a linha à tabela
  tbody.appendChild(tr);
});

// Adiciona a tabela à div de dados
table.appendChild(tbody);
dados.appendChild(table);
