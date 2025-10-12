document.addEventListener('DOMContentLoaded', function() {
  const botaoPost = document.getElementById('BotaoPost');
  const telaPost = document.getElementById('TelaPost');
  const fecharPost = document.getElementById('FecharPost');

  botaoPost.addEventListener('click', function() {
    telaPost.showModal();
  });

  fecharPost.addEventListener('click', function() {
    telaPost.close();
  });
});