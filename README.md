
O RolêSP é uma aplicação web responsiva desenvolvida em ASP.NET Core MVC (.NET 9.0) voltada à descoberta, organização e compartilhamento de lugares alternativos em São Paulo.

Indo além dos pontos turísticos tradicionais, a plataforma resolve a dificuldade de encontrar e registrar "cantinhos especiais" recomendados por moradores e visitantes — como cafeterias autorais, livrarias independentes, museus, espaços culturais, restaurantes e áreas de natureza — centralizando fotos, endereços e avaliações em uma experiência simples com feed e galeria pessoal.

Nota sobre as branches do repositório: Atualmente, o código-fonte completo da aplicação MVC encontra-se na branch Feature-MVC (as branches main e develop contêm apenas o commit inicial).

Funcionalidades

Com base na implementação presente na branch Feature-MVC, a aplicação conta com os seguintes recursos:

Landing Page Institucional e Vitrine Interativa (/LandingPage)

Apresentação da proposta da plataforma e carrossel com as 6 categorias principais (Cafeterias, Museus, Restaurantes, Natureza, Livrarias e Cultura).
Vitrine interativa de Melhores Lugares com troca dinâmica de imagem e descrição dos estabelecimentos em destaque.
Modal de cadastro rápido integrado via Fetch API (POST /Cadastro/Criar).

Cadastro e Autenticação de Usuários (/Cadastro e /Login)

Criação de conta com validação de campos obrigatórios, confirmação de senha e verificação de e-mail duplicado no banco de dados.
Atribuição automática de avatar padrão (iconUserDefault.png) e criptografia de senhas em SHA-256 (HashService).
Login por e-mail e senha com controle de sessão via ASP.NET Core Session e encerramento de sessão (GET /Login/Sair).

Galeria Pessoal e Publicação de Locais (/Galeria)

Rota protegida por sessão autenticada que exibe o perfil do usuário e a grade de suas publicações armazenadas no SQL Server (imagens salvas como VARBINARY(MAX) e renderizadas em Base64).
Publicação de novos locais (POST /Galeria/Postar): envio assíncrono (FormData) com upload de imagem, seleção de categoria (Filtro), nome do estabelecimento, endereço completo e avaliação textual — cadastrando ou reutilizando registros nas tabelas Endereco e Locais.
Autocompletar de endereço com ViaCEP: preenchimento automático de rua, bairro, cidade e estado a partir do CEP, além de busca reversa de CEP por endereço.
Visualização detalhada e Exclusão (POST /Galeria/Excluir): modais nativos (<dialog>) para visualizar foto, endereço e comentário de cada postagem e confirmar a exclusão de itens.
Edição de postagens e Configurações de perfil: interfaces modais (TelaEditar e TelaConfiguracao) estruturadas na view de galeria (com a action de edição no controller ainda em implementação).

Feed de Exploração (/Home)

Interface de exploração com campo de busca, menu lateral de filtros por categoria, seção de Recomendação Mensal, botões de favoritar/marcar destino e modal de detalhes do local. (Atualmente renderizado com cards de demonstração na view, enquanto FeedController.cs encontra-se em transição para consulta dinâmica ao banco de dados).
Tecnologias Utilizadas
Back-end
.NET 9.0 (net9.0) e C#
ASP.NET Core MVC (Controllers, Razor Views e Session Middleware)
Entity Framework Core 8.0.10
Microsoft.EntityFrameworkCore.SqlServer (8.0.10)
Microsoft.EntityFrameworkCore.Design (8.0.10)
Microsoft.EntityFrameworkCore.Tools (8.0.10)
Scaffolding: Microsoft.VisualStudio.Web.CodeGeneration.Design (8.0.0)
Segurança: System.Security.Cryptography (hash SHA256 em Services/HashService.cs)
Front-end e Estilização
Razor (.cshtml) e HTML5 (com uso de elementos nativos <dialog>)
CSS3 customizado com variáveis CSS (:root), Flexbox e tipografia Nunito (Google Fonts)
JavaScript Vanilla (ES6+) com Fetch API e FormData
Bibliotecas cliente (wwwroot/lib/): Bootstrap, jQuery, jQuery Validation e jQuery Validation Unobtrusive
Integração Externa: API pública ViaCEP
 para consulta de endereços
Banco de Dados
Microsoft SQL Server (DbRoleSP)
Tabelas modeladas em DbRoleSP.sql: Usuario, Endereco, Filtro, Locais, Post, Destino e Favorito
Ferramentas e Build
.NET CLI (dotnet)
Visual Studio / VS Code (RoleSP.sln e RoleSP.csproj)
Estrutura de Pastas

Organização principal dos arquivos do projeto na branch Feature-MVC:

text
RoleSP/
├── Controllers/
│   ├── CadastroController.cs      # Cadastro de novos usuários (JSON/AJAX)
│   ├── FeedController.cs          # Esboço da integração dinâmica do feed com o banco
│   ├── GaleriaController.cs       # Listagem, publicação e exclusão de posts do usuário
│   ├── HomeController.cs          # View do feed e verificação de acesso por sessão
│   ├── LandingPageController.cs   # Página inicial pública e redirecionamento de acesso
│   └── LoginController.cs         # Autenticação por e-mail/senha e logout
├── Data/
│   └── AppDbContext.cs            # Contexto do Entity Framework Core (mapeamento SQL Server)
├── Models/
│   ├── Avaliacao.cs               # Entidade de avaliação
│   ├── Endereco.cs                # Entidade de endereço (Rua, Bairro, Cidade, CEP)
│   ├── ErrorViewModel.cs          # Modelo padrão de erro do ASP.NET Core MVC
│   ├── Filtro.cs                  # Entidade de categorias/filtros de locais
│   ├── GaleriaViewModel.cs        # ViewModel consolidado para a tela de Galeria
│   ├── Locai.cs                   # Entidade de locais vinculados a endereço e filtro
│   ├── Post.cs                    # Entidade de postagens (imagem binária + avaliação)
│   └── Usuario.cs                 # Entidade de usuários e relacionamentos
├── Properties/
│   └── launchSettings.json        # Perfis de execução local (HTTP :5181 / HTTPS :7098)
├── Services/
│   └── HashService.cs             # Geração de hash SHA-256 para senhas
├── Views/
│   ├── Galeria/Index.cshtml       # Galeria do usuário e modais (Publicar, Editar, Excluir, Config)
│   ├── Home/index.cshtml          # Feed principal com categorias, recomendações e detalhes
│   ├── LandingPage/Index.cshtml   # Página institucional, carrosséis e modal de cadastro
│   ├── Login/index.cshtml         # Tela de login
│   ├── _ViewImports.cshtml        # Diretivas globais das views Razor
│   └── _ViewStart.cshtml          # Configuração inicial de layout das views
├── wwwroot/
│   ├── assets/                    # Logos, ícones, mascote e imagens dos locais
│   ├── css/                       # Folhas de estilo globais e por módulo (Home, Galeria, Login, LandingPage)
│   ├── js/                        # Scripts de carrossel, modais, AJAX e integração ViaCEP
│   └── lib/                       # Dependências estáticas (Bootstrap, jQuery, jQuery Validation)
├── DbRoleSP.sql                   # Script DDL/DML para criação do banco DbRoleSP e carga de filtros
├── Program.cs                     # Ponto de entrada, DI (DbContext, Session) e roteamento MVC
├── appsettings.json               # Configurações da aplicação e string de conexão
├── appsettings.Development.json   # Sobrescrita de logs para ambiente de desenvolvimento
├── RoleSP.csproj                  # Definição do projeto .NET 9.0 e pacotes NuGet
└── RoleSP.sln                     # Solution do projeto
Pré-requisitos e Instalação
Pré-requisitos
.NET 9.0 SDK
Microsoft SQL Server (LocalDB, SQL Server Express ou instância em container Docker)
Git
1. Clonar o repositório e selecionar a branch MVC
bash
git clone https://github.com/RoleSPsenai/RoleSP.git
cd RoleSP
git checkout Feature-MVC
2. Criar o banco de dados

Execute o script DbRoleSP.sql na sua instância do SQL Server (via SQL Server Management Studio, Azure Data Studio ou sqlcmd). O script cria o banco DbRoleSP, todas as tabelas relacionais e popula os 6 registros iniciais da tabela Filtro (cafeteria, museu, restaurantes, natureza, livraria, cultura).

Exemplo via sqlcmd:

bash
sqlcmd -S localhost -E -i DbRoleSP.sql
3. Configurar a string de conexão e variáveis de ambiente

O projeto não utiliza arquivos .env; as configurações são gerenciadas via appsettings.json e variáveis de ambiente do ASP.NET Core.

Ajuste a chave ConnectionStrings:ConexaoPadrao no arquivo appsettings.json para apontar para o seu servidor SQL Server local:

json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "ConexaoPadrao": "Server=localhost;Database=DbRoleSP;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}

Alternativa com autenticação SQL ou variáveis de ambiente: caso utilize usuário e senha no SQL Server ou prefira não alterar appsettings.json, sobrescreva a conexão por variável de ambiente:

ASPNETCORE_ENVIRONMENT: ambiente de execução (ex.: Development, já definido em Properties/launchSettings.json).
ConnectionStrings__ConexaoPadrao: string de conexão completa (ex.: Server=localhost;Database=DbRoleSP;User Id=sa;Password=SuaSenhaForte;TrustServerCertificate=True;).
4. Restaurar dependências e executar localmente
bash
dotnet restore
dotnet run

Por padrão, a aplicação será iniciada nos endereços definidos em Properties/launchSettings.json:

HTTP: http://localhost:5181
HTTPS (perfil https): https://localhost:7098

A rota inicial padrão carrega LandingPageController.Index (/).

Scripts Disponíveis

Como o projeto utiliza o ecossistema .NET (RoleSP.csproj), a execução e o build são realizados por meio da CLI do dotnet:

Comando	Descrição
dotnet restore	Restaura os pacotes NuGet declarados em RoleSP.csproj.
dotnet run	Compila e inicia a aplicação localmente utilizando o perfil http (http://localhost:5181).
dotnet run --launch-profile https	Inicia a aplicação utilizando o perfil https (https://localhost:7098 e http://localhost:5181).
dotnet watch run	Executa a aplicação em modo de desenvolvimento com recarregamento automático ao salvar alterações.
dotnet build	Compila a solução e valida erros de sintaxe/tipagem sem iniciar o servidor.
dotnet publish -c Release -o ./publish	Gera o artefato otimizado de produção na pasta ./publish.

Observação: no momento, o repositório não possui um projeto dedicado de testes automatizados (como xUnit, NUnit ou MSTest).

Contribuição e Licença
Como contribuir
Faça um fork do repositório.
Crie uma branch descritiva a partir da branch de trabalho atual (Feature-MVC ou develop):
bash
git checkout -b feature/minha-melhoria
Realize suas alterações seguindo o padrão de commits do projeto:
bash
git commit -m "feat: adiciona edição de postagens na galeria"
Envie sua branch para o repositório remoto:
bash
git push origin feature/minha-melhoria
Abra um Pull Request detalhando as mudanças propostas.
Licença

Este repositório ainda não possui um arquivo de licença (LICENSE) definido. (Os arquivos de licença presentes em wwwroot/lib/ aplicam-se exclusivamente às bibliotecas de terceiros Bootstrap e jQuery).
