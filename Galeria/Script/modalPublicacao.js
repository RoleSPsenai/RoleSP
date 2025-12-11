document.addEventListener("DOMContentLoaded", () => {
  // Botão que abre popupPost
  const botaoPost = document.getElementById("BotaoPublicar");
  const popupPost = document.getElementById("TelaPublicacao");
  const botaoPostFechar = document.getElementById("BotaoFecharPublicacao");
  
  // Abrir - mostrar o popupPost alterando display
  botaoPost.addEventListener("click", () => {
    popupPost.showModal();
  });
  
  botaoPostFechar.addEventListener("click", () => {
    popupPost.closeModal();
  });
  
  // Fechar clicando fora
  popupPost.addEventListener("click", (e) => {
    if (e.target === popupPost) {
      popupPost.closeModal();
    }
  });

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