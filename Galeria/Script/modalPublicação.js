// Botão que abre popup
const botao = document.getElementById("BotaoPublicar");
const popup = document.getElementById("TelaPublicacao");
const botaoFechar = document.getElementById("btn-fechar");

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