document.addEventListener("DOMContentLoaded", () => {
  // popupPublicacao
  const botaoPublicacao = document.getElementById("BotaoPublicar");
  const popupPublicacao = document.getElementById("TelaPublicacao");
  const botaoPublicacaoFechar = document.getElementById("BotaoFecharPublicacao");
  
  botaoPublicacao.addEventListener("click", () => {
    popupPublicacao.showModal();
  });
  
  botaoPublicacaoFechar.addEventListener("click", () => {
    popupPublicacao.close();
  });
  
  // Fechar clicando fora
  popupPublicacao.addEventListener("click", (e) => {
    if (e.target === popupPublicacao) {
      popupPublicacao.close();
    }
  });

  const inputs = document.querySelectorAll(
    ".form-publicacao input, .form-publicacao textarea"
  );
  inputs.forEach((input) => {
    const setFocused = () => {
      const label = input.previousElementSibling;
      if (label && label.tagName.toLowerCase() === "label") {
        label.classList.add("focused");
      }
    };

    const removeFocused = () => {
      const label = input.previousElementSibling;
      if (label && label.tagName.toLowerCase() === "label") {
        if (input.value.trim() === "") {
          label.classList.remove("focused");
        }
      }
    };

    input.addEventListener("focus", setFocused);
    input.addEventListener("blur", removeFocused);

    // Se o input já tiver valor (ex.: preenchido por autocomplete), mantém o label flutuando
    if (input.value && input.value.trim() !== "") setFocused();
  });
});

//* AJAX para submissão do formulário de postagem */

document.addEventListener("DOMContentLoaded", () => {
    // Substitua '#formPostar' pelo ID real do seu formulário HTML
    const formPostar = document.querySelector("#formPostar");

    if (!formPostar) {
        console.error("Erro: Formulário de postagem não encontrado.");
        return;
    }

    formPostar.addEventListener("submit", function (e) {
        e.preventDefault();

        // FormData captura todos os campos (incluindo a imagem) automaticamente
        const formData = new FormData(formPostar);
        const erroElement = document.querySelector("#erroPostar");

        // Limpa mensagens de erro anteriores
        if (erroElement) erroElement.innerText = "";

        fetch("/Galeria/Postar", {
            method: "POST",
            body: formData
        })
        .then(res => {
            // Caso o servidor retorne um erro de sistema (500)
            if (!res.ok) {
                throw new Error("Erro no servidor ao processar a postagem.");
            }
            return res.json();
        })
        .then(resposta => {
            if (resposta.sucesso) {
                // Caso de sucesso: Mensagem amigável e recarregamento
                alert(resposta.mensagem);
                window.location.reload(); 
            } else {
                // Caso de erro validado pelo C#
                if (erroElement) {
                    erroElement.innerText = resposta.mensagem;
                    erroElement.style.color = "red";
                } else {
                    alert(resposta.mensagem);
                }
            }
        })
        .catch(err => {
            console.error("Erro na requisição:", err);
            if (erroElement) {
                erroElement.innerText = "Houve um problema ao conectar com o servidor.";
            }
        });
    });
});
