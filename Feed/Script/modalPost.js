document.addEventListener("DOMContentLoaded", function () {
    const telaPost = document.getElementById("TelaPost");
    const fecharPost = document.getElementById("FecharPost");

    // Elementos do modal
    // const imagemLocal = document.getElementById("ImagemDoPost");
    // const nomeLocal = document.getElementById("NomeDoLocal");
    // const bairroLocal = document.getElementById("BairroDoLocal");
    // const enderecoLocal = document.getElementById("EnderecoDoLocal");
    
    const imagemPost = document.getElementById("ImagemDoPost");
    const legendaPost = document.getElementById("LegendaPost");
    const nomeLocal = document.getElementById("NomeDoLocal");
    const enderecoLocal = document.getElementById("EnderecoDoLocal");
    // const nomeUsuario = document.getElementById("NomeUsuario");
    // const fotoUsuario = document.getElementById("FotoUsuario");

    // Seleciona todos os posts
    const posts = document.querySelectorAll(".post");

    posts.forEach(post => {

        const imagem = post.querySelector(".foto-post");
        const botao = post.querySelector(".icone-informacao");

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
});

