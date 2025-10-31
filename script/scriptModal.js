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
  updateBodyOverflow();
});

// Fechar o modal de login
botaoFecharLogin.addEventListener('click', () => {
  modalLogin.close();
  updateBodyOverflow();
});

// Abrir o modal de cadastro
botaoCadastro.addEventListener('click', () => {
  modalLogin.close();
  modalCadastro.showModal();
  updateBodyOverflow();
});

// Fechar o modal de cadastro
botaoFecharCadastro.addEventListener('click', () => {
  modalCadastro.close();
  updateBodyOverflow();
});

// Trocar para cadastro a partir do login
const linkAbrirCadastro = document.querySelector('#login-modal .abrir-modal-cadastro');
if (linkAbrirCadastro) {
  linkAbrirCadastro.addEventListener('click', (e) => {
    e.preventDefault();
    modalLogin.close();
    modalCadastro.showModal();
    updateBodyOverflow();
  });
}

// Trocar para login a partir do cadastro
const linkAbrirLogin = document.querySelector('#cadastro-modal .abrir-modal-login');
if (linkAbrirLogin) {
  linkAbrirLogin.addEventListener('click', (e) => {
    e.preventDefault();
    modalCadastro.close();
    modalLogin.showModal();
    updateBodyOverflow();
  });
}

// Floating labels: adiciona/remova classe `focused` no label quando o input ganha/perde foco
document.addEventListener('DOMContentLoaded', () => {
  const inputs = document.querySelectorAll('.form-modal input');
  inputs.forEach(input => {
    const setFocused = () => {
      const label = input.previousElementSibling;
      if (label && label.tagName.toLowerCase() === 'label') {
        label.classList.add('focused');
      }
    };

    const removeFocused = () => {
      const label = input.previousElementSibling;
      if (label && label.tagName.toLowerCase() === 'label') {
        if (input.value.trim() === '') {
          label.classList.remove('focused');
        }
      }
    };

    input.addEventListener('focus', setFocused);
    input.addEventListener('blur', removeFocused);

    // Se o input já tiver valor (ex.: preenchido por autocomplete), mantém o label flutuando
    if (input.value && input.value.trim() !== '') setFocused();
  });
});

  // Mantém o overflow do body hidden enquanto algum dialog estiver aberto
  function updateBodyOverflow() {
    const anyOpen = document.querySelectorAll('dialog[open]').length > 0;
    document.body.style.overflow = anyOpen ? 'hidden' : '';
  }

  // Garante atualização caso o modal seja fechado por métodos nativos (esc, backdrop, etc.)
  if (modalLogin) modalLogin.addEventListener('close', updateBodyOverflow);
  if (modalCadastro) modalCadastro.addEventListener('close', updateBodyOverflow);