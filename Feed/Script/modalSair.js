const botaoSair = document.getElementById("logout");
const popupSair = document.getElementById("popupSair");
const btnCancelarSair = document.getElementById("btnCancelarSair");
const btnConfirmarSair = document.getElementById("btnConfirmarSair");

// Abrir popup
botaoSair.addEventListener("click", () => {
  popupSair.showModal();
});

// Cancelar
btnCancelarSair.addEventListener("click", () => {
  popupSair.close();
});

// Confirmar
btnConfirmarSair.addEventListener("click", () => {
  popupSair.close();
});

// Fechar clicando fora da caixa
popupSair.addEventListener("click", (e) => {
  const content = popupSair.querySelector(".popup-content");
  const rect = content.getBoundingClientRect();

  const clickFora =
    e.clientX < rect.left ||
    e.clientX > rect.right ||
    e.clientY < rect.top ||
    e.clientY > rect.bottom;

  if (clickFora) {
    popupSair.close();
  }
});