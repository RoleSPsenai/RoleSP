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

// SELECT de filtros

let select = document.querySelector('.select'),
    optionsFiltersLabel = document.getElementById('optionsFiltersLabel'),
    selectValue = document.getElementById('selectValue'),
    option = document.querySelectorAll('.option input');

option.forEach(input => {
    input.addEventListener('click', event => {
        selectValue.textContent = input.dataset.lable;

        const isMouseClick =
        event.pointerType == 'mouse' ||
        event.pointerType == 'touch';

       isMouseClick && optionsFiltersLabel.click();
})
});
    

    
     
