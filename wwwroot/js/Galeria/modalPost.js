document.addEventListener("DOMContentLoaded", function () {
    
    /* A lógica de ABRIR o modal agora está direto no HTML (Index.cshtml)
       nos botões com onclick="document.getElementById('...').showModal()"
    */

    // Seleciona TODOS os modais da página (Detalhes, Editar, Excluir, etc)
    const dialogs = document.querySelectorAll("dialog");

    dialogs.forEach(dialog => {
        // Adiciona evento para fechar ao clicar no "fundo escuro" (Backdrop)
        dialog.addEventListener("click", (e) => {
            // Se o clique foi no elemento dialog (e não no conteúdo dele)
            if (e.target === dialog) {
                dialog.close();
            }
        });

        // (Opcional) Se você quiser garantir que os botões de fechar (X) funcionem via JS também,
        // embora o seu HTML já tenha onclick="close()" neles.
        const btnsFechar = dialog.querySelectorAll(".botao-fechar-modal, .btn-cancelar, .fechar-modal");
        btnsFechar.forEach(btn => {
            btn.addEventListener("click", () => dialog.close());
        });
    });
});