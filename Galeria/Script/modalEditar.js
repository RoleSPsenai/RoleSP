// -----------------------------
// EDITAR POST
// -----------------------------

let postEmEdicao = null;

// Abrir popup
function abrirPopupEditar(post) {
    postEmEdicao = post;

    const popupEditar = document.getElementById("TelaEditar");
    popupEditar.style.display = "flex";  // EXATAMENTE igual ao popup de publicação

    // Preenche campos
    document.getElementById("localEditar").value =
        post.querySelector(".legenda-foto").innerText || "";

    document.getElementById("comentarioEditar").value =
        post.dataset.comentario || "";

    document.getElementById("inputCepEditar").value =
        post.dataset.cep || "";

    document.getElementById("bairroEditar").value =
        post.dataset.bairro || "";

    document.getElementById("ruaEditar").value =
        post.dataset.rua || "";

    document.getElementById("cidadeEditar").value =
        post.dataset.cidade || "";

    // Filtro
    const selectFiltro = document.querySelector("#TelaEditar select");
    selectFiltro.value = post.dataset.filtro || "cafeteria";

    // Alterar imagem
    const imgInputEditar = document.getElementById("imgInputEditar");
    imgInputEditar.onchange = function () {
        const arquivo = imgInputEditar.files[0];
        if (arquivo) {
            const img = post.querySelector(".foto-post");
            img.src = URL.createObjectURL(arquivo);
        }
    };
}

// FECHAR popup ao clicar no X
document.getElementById("btn-fechar-editar").addEventListener("click", () => {
    document.getElementById("TelaEditar").style.display = "none";
});

// FECHAR clicando fora
document.getElementById("TelaEditar").addEventListener("click", (e) => {
    if (e.target.id === "TelaEditar") {
        document.getElementById("TelaEditar").style.display = "none";
    }
});

// SALVAR ALTERAÇÕES
document.getElementById("BotaoSalvarEdicao").addEventListener("click", () => {
    if (!postEmEdicao) return;

    postEmEdicao.querySelector(".legenda-foto").innerText =
        document.getElementById("localEditar").value;

    postEmEdicao.dataset.comentario =
        document.getElementById("comentarioEditar").value;

    postEmEdicao.dataset.cep =
        document.getElementById("inputCepEditar").value;

    postEmEdicao.dataset.bairro =
        document.getElementById("bairroEditar").value;

    postEmEdicao.dataset.rua =
        document.getElementById("ruaEditar").value;

    postEmEdicao.dataset.cidade =
        document.getElementById("cidadeEditar").value;

    postEmEdicao.dataset.filtro =
        document.querySelector("#TelaEditar select").value;

    // FECHA POPUP
    document.getElementById("TelaEditar").style.display = "none";
});

// Tornar global para o galeria.js
window.abrirPopupEditar = abrirPopupEditar;
