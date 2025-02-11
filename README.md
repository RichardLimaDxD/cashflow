# Cashflow

## Seções do projeto

- [Descrição](#✔️-descrição)
- [Tecnologias](#🔨-tecnologias)
- [Instalação e Execução](#🚀-instalação-e-execução)
- [Funcionalidades](#💻-funcionalidades) 

## ✔️ Descrição
Cashflow é um projeto de gestão de fluxo de caixa que permite criar e organizar despesas de forma eficiente. Com ele, é possível gerar relatórios detalhados em PDF ou Excel, associar despesas a usuários específicos e categorizá-las por tags.

## 🔨 Tecnologias

- `ClosedXML`
- `AutoMapper`
- `BCrypt.Net-Next`
- `FluentValidation`
- `PDFsharp-MigraDoc`
- `Microsoft.EntityFrameworkCore`
- `System.IdentityModel.Tokens.Jwt`
- `Pomelo.EntityFrameworkCore.MySql`
- `Microsoft.EntityFrameworkCore.Tools`
- `Microsoft.EntityFrameworkCore.Design`
- `Microsoft.Extensions.DependencyInjection`
- `Microsoft.Extensions.Configuration.Binder`
- `Microsoft.AspNetCore.Authentication.JwtBearer`
- `Microsoft.Extensions.DependencyInjection.Abstractions`

## 🚀 Instalação e Execução

É necessário ter instalado em sua máquina o `SDK Dotnet 8` e `Docker`.
Para executar a aplicação localmente, siga estas etapas:

1. Clone este repositório no visual studio;
2. Abra o projeto e rode o `docker-compose`;

## 💻 Funcionalidades

| Método | Endpoint               | Responsabilidade                            | Autenticação                          |
| ------ | ---------------------- | ------------------------------------------- | ------------------------------------- |
| POST   | /login                 | Gera o token de autenticação                | Qualquer usuário, não necessita token |
| GET    | /user                  | Busca usuário por token                     | Qualquer usuário, obrigatório token   |
| POST   | /user                  | Criação de usuário                          | Qualquer usuário, não necessita token |
| PUT    | /user                  | Atualiza um usuário                         | Obrigatório token e dono da conta     |
| PUT    | /user/change-password  | Atualiza a senha do usuário logado          | Obrigatório token e dono da conta     |
| DELETE | /user                  | Deletar usuário                             | Obrigatório token e dono da conta     |
| POST   | /musics                | Criação da música                           | Usuário admin, obrigatório token      |
| GET    | /musics                | Lista todas as músicas                      | Qualquer usuário, não necessita token |
| GET    | /musics/:id            | Retornar uma música por id                  | Qualquer usuário, não necessita token |
| PATCH  | /musics/:id            | Atualiza uma música por id                  | Usuário admin, obrigatório token      |
| DELETE | /musics/:id            | Deletar música por id                       | Usuário admin, obrigatório token      |

