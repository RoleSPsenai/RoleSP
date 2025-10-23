
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