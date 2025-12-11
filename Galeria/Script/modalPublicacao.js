// Botão que abre popup
const botao = document.getElementById("BotaoPublicar");
const popup = document.getElementById("TelaPublicacao");
const botaoFechar = document.getElementById("btn-fechar");

// Abrir
botao.addEventListener("click", () => {
  popup.showModal();
});

botaoFechar.addEventListener("click", () => {
  popup.close();
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
});