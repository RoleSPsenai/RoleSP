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
