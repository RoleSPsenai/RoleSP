
document.addEventListener('DOMContentLoaded', () => {

    const botaoConfig = document.getElementById('configuracao');
    const modalConfig = document.getElementById('config-modal');
    const botaoFechar = document.getElementById('btn-fechar-config');

    // Abrir popup
    botaoConfig.addEventListener('click', () => {
        modalConfig.showModal();
    });

    // Fechar popup
    botaoFechar.addEventListener('click', () => {
        modalConfig.close();
    });

});