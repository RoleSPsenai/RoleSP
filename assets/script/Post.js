document.addEventListener("DOMContentLoaded", () => {
    // Favorito (coração): manter selecionado ao clicar
    const favoritos = document.querySelectorAll(".icone-favorito");
    favoritos.forEach((btn) => {
        btn.addEventListener("click", () => {
            btn.classList.toggle("selected");
        });
    });
});

document.addEventListener("DOMContentLoaded", () => {
    // Favorito (coração): manter selecionado ao clicar
    const favoritos = document.querySelectorAll(".icone-destino");
    favoritos.forEach((btn) => {
        btn.addEventListener("click", () => {
            btn.classList.toggle("selected");
        });
    });
});

