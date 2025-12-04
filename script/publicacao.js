// Botão que abre popup
const botao = document.getElementById("BotaoPublicar");
const popup = document.getElementById("TelaPublicacao");
const botaoFechar = document.getElementById("btn-fechar");

// Abrir
botao.addEventListener("click", () => {
    popup.style.display = "flex";
});

botaoFechar.addEventListener("click", () => {
    popup.style.display = "none";
});


// Fechar clicando fora
popup.addEventListener("click", (e) => {
    if (e.target === popup) {
        popup.style.display = "none";
    }
});



    
     
