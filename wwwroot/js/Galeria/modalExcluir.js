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

function enviarExclusao(e, idPost) {
    // 1. Impede o recarregamento padrão da página
    e.preventDefault();

    // 2. Captura o formulário específico pelo ID único
    const form = document.getElementById(`formExcluir-${idPost}`);
    const modal = document.getElementById(`popupExcluir-${idPost}`);

    // 3. Prepara os dados (mesmo padrão do FormData)
    const formData = new FormData(form);

    // 4. Envia via AJAX (Fetch)
    fetch('/Galeria/Excluir', {
        method: 'POST',
        body: formData
    })
    .then(resposta => resposta.json())
    .then(dados => {
        if (dados.sucesso) {
            // Sucesso!
            modal.close(); // Fecha o modal
            
            // Opcional: Alerta suave
            // alert(dados.mensagem); 

            // ATUALIZA A TELA:
            // Como removemos um item, o ideal é recarregar para atualizar a grid
            window.location.reload(); 
        } else {
            // Erro: Mostra a mensagem que veio do Controller (ex: erro de banco)
            alert(dados.mensagem);
        }
    })
    .catch(erro => {
        console.error('Erro na requisição:', erro);
        alert("Ocorreu um erro de conexão.");
    });
}