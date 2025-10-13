const modalLogin = document.getElementById('login-modal');
const modalCadastro = document.getElementById('cadastro-modal');

const botaoLogin = document.getElementById('btn-abrir-login');
const botaoCadastro = document.getElementById('btn-abrir-cadastro');

const botaoFecharLogin = document.getElementById('btn-fechar-login');
const botaoFecharCadastro = document.getElementById('btn-fechar-cadastro');

// Abrir o modal de login
botaoLogin.addEventListener('click', () => {
  modalCadastro.close();
  modalLogin.showModal();
});

// Fechar o modal de login
botaoFecharLogin.addEventListener('click', () => {
  modalLogin.close();
});

// Abrir o modal de cadastro
botaoCadastro.addEventListener('click', () => {
  modalLogin.close();
  modalCadastro.showModal();
});

// Fechar o modal de cadastro
botaoFecharCadastro.addEventListener('click', () => {
  modalCadastro.close();
});

// Trocar para cadastro a partir do login
const linkAbrirCadastro = document.querySelector('#login-modal .abrir-modal-cadastro');
if (linkAbrirCadastro) {
  linkAbrirCadastro.addEventListener('click', (e) => {
    e.preventDefault();
    modalLogin.close();
    modalCadastro.showModal();
  });
}

// Trocar para login a partir do cadastro
const linkAbrirLogin = document.querySelector('#cadastro-modal .abrir-modal-login');
if (linkAbrirLogin) {
  linkAbrirLogin.addEventListener('click', (e) => {
    e.preventDefault();
    modalCadastro.close();
    modalLogin.showModal();
  });
}