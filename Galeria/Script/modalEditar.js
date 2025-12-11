document.addEventListener("DOMContentLoaded", () => {
  // Botões que abrem popup
  const botaoEditar = document.querySelectorAll(".editar-post");
  const popupEditar = document.getElementById("TelaEditar");
  const botaoFecharEditar = document.getElementById("BotaoFecharEditar");

  botaoEditar.forEach((btn) => {
    btn.addEventListener("click", () => {
      popupEditar.showModal();
    });
  });

  // Fechar no botão X
  botaoFecharEditar.addEventListener("click", () => {
    popupEditar.close(); // <-- CORRETO
  });

  // Fechar clicando fora
  popupEditar.addEventListener("click", (e) => {
    if (e.target === popupEditar) {
      popupEditar.close(); // <-- CORRETO
    }
  });

  // Labels animadas dos inputs
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