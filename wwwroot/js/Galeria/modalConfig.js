document.addEventListener("DOMContentLoaded", () => {
    const botaoConfig = document.getElementById("BotaoConfiguracao");
    const modalConfig = document.getElementById("TelaConfiguracao");
    const botaoFecharConfig = document.getElementById("BotaoFecharConfiguracao");

    // Abrir popup
    botaoConfig.addEventListener("click", () => {
        modalConfig.showModal();
    });

    // Fechar popup
    botaoFecharConfig.addEventListener("click", () => {
        modalConfig.close();
    });
});

// Obtém referências para os elementos
const fileInput = document.getElementById("fileInput");
const openExplorerLink = document.getElementById("openExplorerLink");

// Adiciona um ouvinte de evento de clique ao link
openExplorerLink.addEventListener("click", function (event) {
    event.preventDefault();
    fileInput.click();
});

// Opcional: Você pode adicionar um ouvinte de evento 'change' ao input para saber quando um arquivo foi selecionado
fileInput.addEventListener("change", function () {
    if (this.files && this.files.length > 0) {
        console.log("Arquivo selecionado:", this.files[0].name);
        alert("Você selecionou o arquivo: " + this.files[0].name);
    }
});