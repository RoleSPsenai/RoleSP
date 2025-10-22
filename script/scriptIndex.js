
//? =-=-=-=-=-=-==- GET TEXTO -=-=-=-=-=-=-=-
const casaAntonia_texto = document.getElementById('casaAntonia-texto');
const cafezal_texto = document.getElementById('cafezal-texto');
const cinemateca_texto = document.getElementById('cinemateca-texto');
const hiTea_texto = document.getElementById('hiTea-texto');
const jazz_texto = document.getElementById('jazz-texto');
const tartine_texto = document.getElementById('tartine-texto');
const london_texto = document.getElementById('london-texto');
const vila_texto = document.getElementById('vila-texto');
const kiki_texto = document.getElementById('kiki-texto');

//? =-=-=-=-=-=-==- GET IMG -=-=-=-=-=-=-=-
const casaAntonia_img = document.getElementById('casaAntonia-img');
const cafezal_img = document.getElementById('cafezal-img');
const cinemateca_img = document.getElementById('cinemateca-img');
const hiTea_img = document.getElementById('hiTea-img');
const jazz_img = document.getElementById('jazz-img');
const tartine_img = document.getElementById('tartine-img');
const london_img = document.getElementById('london-img');
const vila_img = document.getElementById('vila-img');
const kiki_img = document.getElementById('kiki-img');

//? =-=-=-=-=-=-==- GET Carrossel -=-=-=-=-=-=-=-
const casaAntonia_crl = document.getElementById('casaAntonia-crl');
const cafezal_crl = document.getElementById('cafezal-crl');
const cinemateca_crl = document.getElementById('cinemateca-crl');
const hiTea_crl = document.getElementById('hiTea-crl');
const jazz_crl = document.getElementById('jazz-crl');
const tartine_crl = document.getElementById('tartine-crl');
const london_crl = document.getElementById('london-crl');
const vila_crl = document.getElementById('vila-crl');
const kiki_crl = document.getElementById('kiki-crl');


//? =-=-=-=-=-=-==- Function UPDATE =-=-=-=-=-=-==-

function update(local) {
    document.querySelector('.fundo-img-local.ativo').classList.remove('ativo')
    document.querySelector('.avaliacao-section3.ativo').classList.remove('ativo')

    switch (local) {
        case 1:
            casaAntonia_texto.classList.add('ativo')
            casaAntonia_img.classList.add('ativo')
            break;
        case 2:
            cafezal_texto.classList.add('ativo')
            cafezal_img.classList.add('ativo')
            break;
        case 3:
            cinemateca_texto.classList.add('ativo')
            cinemateca_img.classList.add('ativo')
            break;
        case 4:
            hiTea_texto.classList.add('ativo')
            hiTea_img.classList.add('ativo')
            break;
        case 5:
            jazz_texto.classList.add('ativo')
            jazz_img.classList.add('ativo')
            break;
        case 6:
            tartine_texto.classList.add('ativo')
            tartine_img.classList.add('ativo')
            break;
        case 7:
            london_texto.classList.add('ativo')
            london_img.classList.add('ativo')
            break;
        case 8:
            vila_texto.classList.add('ativo')
            vila_img.classList.add('ativo')
            break;
        case 9:
            kiki_texto.classList.add('ativo')
            kiki_img.classList.add('ativo')
            break;
    }
}

//? =-=-=-=-=-=-==- ADD EVENT -=-=-=-=-=-=-=-

casaAntonia_crl.addEventListener('click', () => {
    update(1)
})

cafezal_crl.addEventListener('click', () => {
    update(2)
})

cinemateca_crl.addEventListener('click', () => {
    update(3)
})

hiTea_crl.addEventListener('click', () => {
    update(4)
})

jazz_crl.addEventListener('click', () => {
    update(5)
})

tartine_crl.addEventListener('click', () => {
    update(6)
})

london_crl.addEventListener('click', () => {
    update(7)
})

vila_crl.addEventListener('click', () => {
    update(8)
})

kiki_crl.addEventListener('click', () => {
    update(9)
})


//? =-=-=-=-=-=-==- Classe Local -=-=-=-=-=-=-=-=
class Local {
  constructor(id) {

    this.id = id;

    this.texto = document.getElementById(`${id}-texto`);
    this.img = document.getElementById(`${id}-img`);
    this.crl = document.getElementById(`${id}-crl`);
  }


  ativar() {
    this.texto.classList.add('ativo');
    this.img.classList.add('ativo');
  }


  desativar() {
    this.texto.classList.remove('ativo');
    this.img.classList.remove('ativo');
  }
}

//? =-=-=-=-=-=-==- Inicialização -=-=-=-=-=-=-=-=


const ids = [
  "casaAntonia", "cafezal", "cinemateca", "hiTea",
  "jazz", "tartine", "london", "vila", "kiki"
];


const locais = ids.map(id => new Local(id));


let localAtivo = null;

//? =-=-=-=-=-=-==- Função Principal -=-=-=-=-=-=-=-=
function update(novoId) {

  if (localAtivo) localAtivo.desativar();


  const novoLocal = locais.find(l => l.id === novoId);


  if (novoLocal) {
    novoLocal.ativar();
    localAtivo = novoLocal;
  }
}

//? =-=-=-=-=-=-==- Eventos de Clique -=-=-=-=-=-=-=-=

locais.forEach(local => {
  local.crl.addEventListener('click', () => update(local.id));
});

//? =-=-=-=-=-=-==- Local inicial (opcional) -=-=-=-=-=-=-=-=
update("kiki");