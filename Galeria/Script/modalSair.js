const botaoSair = document.getElementById("logout");     
const popupSair = document.getElementById("popupSair");      
const btnCancelarSair = document.getElementById("btnCancelarSair");
const btnConfirmarSair = document.getElementById("btnConfirmarSair");

// --- Abrir popup de sair ---
botaoSair.addEventListener("click", () => {
  popupSair.showModal();  // Exibe o dialog
});

// --- Cancelar / fechar ---
btnCancelarSair.addEventListener("click", () => {
  popupSair.close();
});

// --- Confirmar ação ---
btnConfirmarSair.addEventListener("click", () => {
  popupSair.close();
});

// --- Fechar clicando fora do conteúdo ---
popupSair.addEventListener("click", (e) => {
  // Se clicou FORA da caixa branca
  const dialogRect = popupSair.querySelector(".popup-sair-da-conta").getBoundingClientRect();

  const clickFora =
    e.clientX < dialogRect.left ||
    e.clientX > dialogRect.right ||
    e.clientY < dialogRect.top ||
    e.clientY > dialogRect.bottom;

  if (clickFora) popupSair.close();
});
