// Botão que abre popup
const botao = document.getElementById("BotaoPublicar");
const popup = document.getElementById("TelaPublicacao");

// Abrir
botao.addEventListener("click", () => {
    popup.style.display = "flex";
});

// Fechar clicando fora
popup.addEventListener("click", (e) => {
    if (e.target === popup) {
        popup.style.display = "none";
    }
});


    
     
