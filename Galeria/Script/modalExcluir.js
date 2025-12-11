const botoesExcluir = document.querySelectorAll(".excluir-post");

// Popup de exclusão
const popupExcluir = document.getElementById("popupExcluir");
const btnCancelarExcluir = document.getElementById("btnCancelarExcluir");
const btnConfirmarExcluir = document.getElementById("btnConfirmarExcluir");

// Abrir popup de exclusão
botoesExcluir.forEach((btn) => {
    btn.addEventListener("click", () => {
        popupExcluir.showModal();
    });
});

// Fechar popup clicando em "Não"
btnCancelarExcluir.addEventListener("click", () => {
    popupExcluir.close();
});

// Confirmar exclusão
btnConfirmarExcluir.addEventListener("click", () => {
    popupExcluir.close();
});


popupExcluir.addEventListener("click", (e) => {
    const caixa = popupExcluir.querySelector(".popup-excluir-content");
    const r = caixa.getBoundingClientRect();

    const clicouFora =
        e.clientX < r.left ||
        e.clientX > r.right ||
        e.clientY < r.top ||
        e.clientY > r.bottom;

    if (clicouFora) popupExcluir.close();
});