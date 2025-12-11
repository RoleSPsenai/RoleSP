document.addEventListener("DOMContentLoaded", () => {
    const telaPost = document.getElementById("TelaPost");
    const fecharPost = document.getElementById("FecharPost");

    // Elementos do modal
    const imagemLocal = document.getElementById("ImagemDoPost");
    const nomeLocal = document.getElementById("NomeDoLocal");
    const bairroLocal = document.getElementById("BairroDoLocal");
    const enderecoLocal = document.getElementById("EnderecoDoLocal");

    // Seleciona todos os posts
    const posts = document.querySelectorAll(".post");

    posts.forEach(post => {

        const imagem = post.querySelector(".foto-post");

        function abrirModal() {
            const imgSrc = post.dataset.img;
            const nome = post.dataset.nome;
            const bairro = post.dataset.bairro;
            const endereco = post.dataset.endereco;

            imagemLocal.src = imgSrc;
            nomeLocal.textContent = nome;
            bairroLocal.textContent = bairro;
            enderecoLocal.textContent = endereco;

            telaPost.showModal();
        }

        imagem.addEventListener("click", abrirModal);
        botao.addEventListener("click", abrirModal);
    });

    fecharPost.addEventListener("click", () => telaPost.close());

    // Favorito (Coração): manter selecionado ao clicar
    const favoritos = document.querySelectorAll(".icone-favorito");
    favoritos.forEach((btn) => {
        btn.addEventListener("click", () => {
            btn.classList.toggle("selected");
        });
    });

    // Favorito (Local): manter selecionado ao clicar
    const favoritosLocal = document.querySelectorAll(".icone-destino");
    favoritosLocal.forEach((btn) => {
        btn.addEventListener("click", () => {
            btn.classList.toggle("selected");
        });
    });
});