// -----------------------------
// EXCLUIR POST
// -----------------------------

let postParaExcluir = null;

// Abre popup de exclusão
function abrirPopupExcluir(post) {
    postParaExcluir = post;
    document.getElementById("popupExcluir").style.display = "flex";
}

// Botão "Não"
document.getElementById("btnCancelarExcluir").addEventListener("click", () => {
    document.getElementById("popupExcluir").style.display = "none";
    postParaExcluir = null;
});

// Botão "Sim"
document.getElementById("btnConfirmarExcluir").addEventListener("click", () => {

    if (postParaExcluir) {
        postParaExcluir.remove();
        postParaExcluir = null;
    }

    document.getElementById("popupExcluir").style.display = "none";
});
