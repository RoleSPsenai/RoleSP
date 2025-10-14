const items = document.querySelectorall('item-section3');
const casaAntonia = document.querySelectorId('casaAntonia');
const cafezal = document.querySelectorId('cafezal');
const hiTea = document.querySelectorId('hiTea');
const jazz = document.querySelectorId('jazz');
const tertine = document.querySelectorId('tertine');
const london = document.querySelectorId('london');
const vila = document.querySelectorId('vila');
const kiki = document.querySelectorId('kiki');

let ativo = 0;
const total = items.length;

function update(local) {

    document.querySelector('.item-section3.ativo').classList.remove('ativo')
    document.querySelector('.avaliacao-section3.ativo').classList.remove('ativo')
}


casaAntonia.addEventListener ('click', () => {
    update(1)
})



