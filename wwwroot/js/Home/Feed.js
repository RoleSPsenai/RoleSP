// post.js ATUALIZADO
document.addEventListener("DOMContentLoaded", function () {
    const telaPost = document.getElementById("TelaPost");
    const fecharPost = document.getElementById("FecharPost");

    // Elementos do modal existentes
    const imagemLocal = document.getElementById("ImagemDoPost");
    const nomeLocal = document.getElementById("NomeDoLocal");
    const bairroLocal = document.getElementById("BairroDoLocal");
    const enderecoLocal = document.getElementById("EnderecoDoLocal");
    
    // NOVOS Elementos do modal para Avaliação/Comentário
    const notaDoAutor = document.getElementById("NotaDoAutor");
    const comentarioDoAutor = document.getElementById("ComentarioDoAutor");

    // Seleciona todos os posts
    const posts = document.querySelectorAll(".post");

    posts.forEach(post => {

        const imagem = post.querySelector(".foto-post");
        const botao = post.querySelector(".icone-informacao");

        function abrirModal() {
            // Captura todos os dados dos atributos data-
            const imgSrc = post.dataset.img;
            const nome = post.dataset.nome;
            const bairro = post.dataset.bairro;
            const endereco = post.dataset.endereco;
            
            // NOVOS DADOS
            const nota = post.dataset.nota; 
            const comentario = post.dataset.comentario;

            // Preenche os campos do modal
            imagemLocal.src = imgSrc;
            nomeLocal.textContent = nome;
            bairroLocal.textContent = bairro;
            enderecoLocal.textContent = endereco;
            
            // Preenche os NOVOS campos
            notaDoAutor.textContent = nota;
            comentarioDoAutor.textContent = comentario;

            telaPost.showModal();
        }

        imagem.addEventListener("click", abrirModal);
        botao.addEventListener("click", abrirModal);
    });

    fecharPost.addEventListener("click", () => telaPost.close());
});