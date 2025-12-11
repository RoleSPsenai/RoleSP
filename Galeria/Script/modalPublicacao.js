document.addEventListener("DOMContentLoaded", () => {
  // popupPublicacao
  const botaoPublicacao = document.getElementById("BotaoPublicar");
  const popupPublicacao = document.getElementById("TelaPublicacao");
  const botaoPublicacaoFechar = document.getElementById("BotaoFecharPublicacao");
  
  botaoPublicacao.addEventListener("click", () => {
    popupPublicacao.showModal();
  });
  
  botaoPublicacaoFechar.addEventListener("click", () => {
    popupPublicacao.close();
  });
  
  // Fechar clicando fora
  popupPublicacao.addEventListener("click", (e) => {
    if (e.target === popupPublicacao) {
      popupPublicacao.close();
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