document.addEventListener("DOMContentLoaded", () => {
    // Seleciona todos os modais de Edição (baseado na classe que você adicionou no HTML)
    const popupsEditar = document.querySelectorAll("dialog.TelaEditar");

    popupsEditar.forEach((popup) => {
        // Busca os elementos internos deste popup específico
        const btnFechar = popup.querySelector(".fechar-modal");
        const caixaConteudo = popup.querySelector(".popup-content");

        // 1. Garante que o botão de fechar (X) funcione via JS também
        if (btnFechar) {
            btnFechar.addEventListener("click", () => {
                popup.close();
            });
        }

        // 2. Lógica para fechar ao clicar fora (Backdrop)
        popup.addEventListener("click", (e) => {
            // Se por algum motivo o conteúdo não for encontrado, para a execução
            if (!caixaConteudo) return;

            // Pega as medidas do quadrado branco (conteúdo)
            const rect = caixaConteudo.getBoundingClientRect();

            // Verifica se o clique do mouse foi fora das bordas do conteúdo
            const clicouFora =
                e.clientX < rect.left ||
                e.clientX > rect.right ||
                e.clientY < rect.top ||
                e.clientY > rect.bottom;

            if (clicouFora) {
                popup.close();
            }
        });
    });
});