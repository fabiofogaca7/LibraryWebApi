# API de Biblioteca

Este projeto é uma API RESTful para gerenciar uma coleção de livros. Ele permite adicionar, visualizar, atualizar, excluir e buscar livros por nome ou autor. A autenticação JWT foi implementada para proteger os endpoints da API.

## Tecnologias Utilizadas

* **ASP.NET Core Web API** (.NET 8.0) - Framework para construir a API.
* **Entity Framework Core InMemory** - Provedor de banco de dados em memória para persistência de dados durante o teste.
* **AutoMapper** - Biblioteca para mapear objetos entre diferentes camadas (DTOs e Entidades).
* **Swashbuckle.AspNetCore** - Ferramenta para gerar a documentação OpenAPI (Swagger) e a interface de teste da API.
* **JSON Web Tokens (JWT)** - Padrão para criar tokens de acesso seguros para autenticação.

## Pré-requisitos

* **SDK do .NET 8.0** ou superior.
* **Visual Studio 2022** ou outro editor de código compatível com .NET.

## Como Clonar o Repositório

1.  Abra o seu terminal (Git Bash no Windows, Terminal no macOS/Linux).
2.  Navegue até o diretório onde você deseja clonar o projeto.
3.  Execute o seguinte comando:

    ```bash
    git clone https://github.com/fabiofogaca7/LibraryWebApi
    cd LibraryWebApi
    ```

## Como Construir o Projeto

Você pode construir o projeto usando o Visual Studio ou a linha de comando do .NET CLI:

**Usando o Visual Studio:**

1.  Abra o arquivo de solução `LibraryWebApi.sln` no Visual Studio.
2.  No menu **Build**, selecione **Construir Solução**.

**Usando a Linha de Comando (.NET CLI):**

1.  Abra o seu terminal na raiz do diretório do projeto (`LibraryWebApi`).
2.  Execute o seguinte comando:

    ```bash
    dotnet build
    ```

## Como Executar a Aplicação

Você pode executar a API usando o Visual Studio ou a linha de comando do .NET CLI:

**Usando o Visual Studio:**

1.  No Visual Studio, certifique-se de que o projeto `LibraryWebApi` esteja selecionado como o projeto de inicialização.
2.  Pressione **Ctrl+F5** (Iniciar sem depurar) ou clique no botão "Play" (IIS Express).

**Usando a Linha de Comando (.NET CLI):**

1.  Abra o seu terminal na raiz do diretório do projeto (`LibraryWebApi`).
2.  Execute o seguinte comando:

    ```bash
    dotnet run
    ```

A API estará rodando em uma porta local (geralmente `https://localhost:<porta>`). A porta exata será exibida na saída do terminal ou na janela do Visual Studio.

## Como Testar a API

A API inclui a documentação interativa do Swagger UI, que permite explorar e testar os endpoints diretamente no seu navegador.

1.  Abra o seu navegador e navegue para o seguinte endereço (substitua `<porta>` pela porta em que a sua API está rodando):

    ```
    https://localhost:<porta>/swagger
    ```

2.  **Autenticação:**
    * Clique no botão "Authorize" no topo da página do Swagger UI.
    * Na janela modal, insira suas credenciais de teste (usuário: `fabio`, senha: `password123`) e clique em "Authorize".
    * Copie o token JWT gerado.
    * Cole o token no campo de autorização para os endpoints protegidos.

3.  **Endpoints:**
    * **`POST /api/auth/login`**: Endpoint para obter um token JWT fornecendo nome de usuário e senha.
    * **`GET /api/Book`**: Retorna a lista de todos os livros (requer autenticação).
    * **`GET /api/Book/{id}`**: Retorna um livro específico pelo ID (requer autenticação).
    * **`POST /api/Book`**: Adiciona um novo livro (requer autenticação).
    * **`PUT /api/Book/{id}`**: Atualiza um livro existente (requer autenticação).
    * **`DELETE /api/Book/{id}`**: Exclui um livro (requer autenticação).
    * **`GET /api/Book/searchByName?query={bookName}`**: Busca livros por nome (requer autenticação).
    * **`GET /api/Book/searchByAuhor?query={bookAuthor}`**: Busca livros por autor (requer autenticação).

## Dados de Exemplo

A API é inicializada com alguns livros de exemplo no banco de dados em memória:

* Dom Quixote - Miguel de Cervantes
* Cem Anos de Solidão - Gabriel García Márquez
* 1984 - George Orwell
* Fogo & Sangue - Geaorge R.R. Martin
* O Acerto de Contas de Uma Mãe - Sue Klebold
* Poesias - Edgar Allan Poe

## Observações

* Este projeto utiliza o Entity Framework InMemory para simular um banco de dados. Os dados serão perdidos quando a aplicação for encerrada.
* A autenticação JWT é implementada com uma chave secreta configurada em `appsettings.json`. Em um ambiente de produção, essa chave deve ser armazenada de forma mais segura.
