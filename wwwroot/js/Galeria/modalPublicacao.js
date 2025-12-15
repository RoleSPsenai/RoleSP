// Botão que abre popup
const botao = document.getElementById("BotaoPublicar");
const popup = document.getElementById("TelaPublicacao");
const botaoFechar = document.getElementById("BotaoFecharPublicacao");

// Abrir
botao.addEventListener("click", () => {
  popup.style.display = "flex";
});

botaoFechar.addEventListener("click", () => {
  popup.style.display = "none";
});

// Fechar clicando fora
popup.addEventListener("click", (e) => {
  if (e.target === popup) {
    popup.style.display = "none";
  }
});

// Floating labels: adiciona/remove classe focused no label quando o input ganha/perde foco
document.addEventListener("DOMContentLoaded", () => {
  const inputs = document.querySelectorAll(
    ".form-publicacao input, .form-publicacao textarea"
  );
  inputs.forEach((input) => {
    const setFocused = () => {
      const label = input.previousElementSibling;
      if (label && label.tagName.toLowerCase() === "label") {
        label.classList.add("focused");
      }
    };

    const removeFocused = () => {
      const label = input.previousElementSibling;
      if (label && label.tagName.toLowerCase() === "label") {
        if (input.value.trim() === "") {
          label.classList.remove("focused");
        }
      }
    };

    input.addEventListener("focus", setFocused);
    input.addEventListener("blur", removeFocused);

    // Se o input já tiver valor (ex.: preenchido por autocomplete), mantém o label flutuando
    if (input.value && input.value.trim() !== "") setFocused();
  });

  // Sistema de avaliação com estrelas
  const estrelas = document.querySelectorAll(".estrela");
  let avaliacaoSelecionada = 0;

  estrelas.forEach((estrela) => {
    // Hover: mostrar até a estrela selecionada
    estrela.addEventListener("mouseenter", () => {
      const value = parseInt(estrela.getAttribute("data-value"));
      estrelas.forEach((e, idx) => {
        if (idx < value) {
          e.classList.add("hover");
        } else {
          e.classList.remove("hover");
        }
      });
    });

    // Click: selecionar a avaliação
    estrela.addEventListener("click", () => {
      avaliacaoSelecionada = parseInt(estrela.getAttribute("data-value"));
      estrelas.forEach((e, idx) => {
        if (idx < avaliacaoSelecionada) {
          e.classList.add("selected");
        } else {
          e.classList.remove("selected");
        }
      });
    });
  });

  // Sair do container de estrelas: limpar hover mas manter selected
  const avaliacaoEstrela = document.querySelector(".avaliacaoEstrela");
  if (avaliacaoEstrela) {
    avaliacaoEstrela.addEventListener("mouseleave", () => {
      estrelas.forEach((e) => {
        e.classList.remove("hover");
      });
    });
  }

  // Favorito (coração): manter selecionado ao clicar
  const favoritos = document.querySelectorAll(".favorito");
  favoritos.forEach((btn) => {
    btn.addEventListener("click", () => {
      btn.classList.toggle("selected");
    });
  });
});


//* API VIACEP

const eNumero = (numero) => /^[0-9]+$/.test(numero);
const cepValido = (cep) => cep.length === 8 && eNumero(cep);

const limparFormulario = () => {
  document.getElementById("rua").value = "";
  document.getElementById("bairro").value = "";
  document.getElementById("cidade").value = "";
  document.getElementById("estado").value = "";
};

const preencherFormulario = (endereco) => {
  document.getElementById("rua").value = endereco.logradouro || "";
  document.getElementById("bairro").value = endereco.bairro || "";
  document.getElementById("cidade").value = endereco.localidade || "";
  document.getElementById("estado").value = endereco.uf || "";
};

const pesquisarCep = async () => {
  const cep = document.getElementById("cep").value.replace("-", "");

  if (!cepValido(cep)) return;

  const url = `https://viacep.com.br/ws/${cep}/json/`;

  try {
    const dados = await fetch(url);
    const endereco = await dados.json();

    if (!endereco.erro) {
      preencherFormulario(endereco);
    }
  } catch (e) {
    console.log("Erro ao buscar CEP:", e);
  }
};

const buscarCepPorEndereco = async () => {
  const estado = document.getElementById("estado").value.trim();
  const cidade = document.getElementById("cidade").value.trim();
  const rua = document.getElementById("rua").value.trim();

  if (!estado || !cidade || !rua) return;

  const url = `https://viacep.com.br/ws/${estado}/${cidade}/${rua}/json/`;

  try {
    const resposta = await fetch(url);
    const dados = await resposta.json();

    if (Array.isArray(dados) && dados.length > 0) {
      document.getElementById("cep").value = dados[0].cep;
    }
  } catch (e) {
    console.log("Erro ao buscar CEP por endereço:", e);
  }
};

document.getElementById("cep").addEventListener("focusout", pesquisarCep);
document.getElementById("rua").addEventListener("focusout", buscarCepPorEndereco);
document.getElementById("cidade").addEventListener("focusout", buscarCepPorEndereco);
document.getElementById("estado").addEventListener("focusout", buscarCepPorEndereco);

async function enviarFormulario(e) {
    // 1. BLOQUEIA o envio padrão e o redirecionamento
    e.preventDefault(); 
    
    console.log("Iniciando envio via Fetch...");

    const form = e.target;
    const notificacao = document.getElementById("notificacao");
    const popup = document.getElementById("TelaPublicacao");
    
    // Captura os dados (incluindo a imagem)
    const formData = new FormData(form);

    if (notificacao) {
        notificacao.innerText = "Publicando...";
        notificacao.style.color = "blue";
    }

    try {
        // Envia para a URL gerada pelo ASP.NET (form.action)
        const resposta = await fetch(form.action, {
            method: "POST",
            body: formData
        });

        if (!resposta.ok) {
            throw new Error("Erro de rede ou servidor.");
        }

        const resultado = await resposta.json();

        if (resultado.sucesso) {
            // SUCESSO
            alert(resultado.mensagem);
            form.reset();
            
            if (popup) {
                // Se for a tag <dialog>, usa .close(). Se for div comum, usa style.display
                typeof popup.close === "function" ? popup.close() : popup.style.display = "none";
            }
            
            // Recarrega para mostrar a foto nova
            window.location.reload();
        } else {
            // ERRO VALIDADO PELO C#
            if (notificacao) {
                notificacao.innerText = resultado.mensagem;
                notificacao.style.color = "red";
            }
        }
    } catch (erro) {
        console.error("Erro fatal:", erro);
        if (notificacao) {
            notificacao.innerText = "Erro ao conectar com o servidor.";
            notificacao.style.color = "red";
        }
    }
}