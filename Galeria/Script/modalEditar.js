// BOTÃO QUE ABRE O POPUP DE EDITAR
const botoesEditar = document.querySelectorAll(".editar-post");
const popupEditar = document.getElementById("TelaEditar");
const botaoFecharEditar = document.getElementById("btn-fechar-editar");

// Abrir popup ao clicar em "Editar"
botoesEditar.forEach((btn) => {
  btn.addEventListener("click", () => {
    popupEditar.style.display = "flex";
  });
});

// Fechar no botão X
botaoFecharEditar.addEventListener("click", () => {
  popupEditar.style.display = "none";
});

// Fechar clicando fora do conteúdo
popupEditar.addEventListener("click", (e) => {
  if (e.target === popupEditar) {
    popupEditar.style.display = "none";
  }
});

document.addEventListener("DOMContentLoaded", () => {
  const inputs = document.querySelectorAll(
    "#TelaEditar input, #TelaEditar textarea"
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

    if (input.value && input.value.trim() !== "") setFocused();
  });
});
