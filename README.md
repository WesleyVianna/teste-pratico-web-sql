# 📍 **Sistema de Pontos Turísticos**

Aplicação web desenvolvida em ASP.NET Core MVC para cadastro, visualização e gerenciamento de pontos turísticos, com integração à API do IBGE para carregamento dinâmico de estados e cidades.

Projeto desenvolvido como teste prático, com foco em organização, clareza de código e boas práticas de desenvolvimento.

# 🛠️ **Tecnologias Utilizadas**

- .NET SDK 10.0.101
- ASP.NET Core MVC
- Entity Framework Core
- SQLite
- Bootstrap
- API do IBGE
- HTML5, CSS3 e JavaScript
- Git (Conventional Commits)

### ▶️ **Clone o repositório**
```bash
git clone https://github.com/WesleyVianna/teste-pratico-web-sql.git
```

### 📂 **Acesse a pasta do projeto**
```bash
cd teste-pratico-web-sql
```

## **Execute o projeto**
```bash
dotnet run
```

## 📂 **Acesse no navegador**
```bash
http://localhost:5000
```
(ou a porta exibida no terminal)


## 🌎 **Integração com a API do IBGE**

A aplicação consome a API oficial do IBGE para:

- Listar estados brasileiros
- Carregar cidades dinamicamente conforme o estado selecionado

**Endpoints utilizados**

Estados
```bash
https://servicodados.ibge.gov.br/api/v1/localidades/estados
```

Cidades por estado
```bash
https://servicodados.ibge.gov.br/api/v1/localidades/estados/{UF}/municipios
```

🧾 Funcionalidades Implementadas

✔️ Cadastro de Ponto Turístico

✔️ Listagem em formato de cards

✔️ Visualização de detalhes

✔️ Edição de registros

✔️ Exclusão com confirmação

✔️ Validações com DataAnnotations

✔️ Validações visuais com Bootstrap

✔️ Layout responsivo

✔️ Integração com API externa


🗂️ Estrutura do Projeto

- Controllers — Controle das requisições e regras de negócio
- Models — Entidades e validações
- Views — Interface com o usuário (Razor)
- Data — Contexto do banco de dados (Entity Framework)
- wwwroot — Arquivos estáticos (CSS, JS, imagens)

📂 Estrutura do Repositório

Além da aplicação web em ASP.NET Core MVC, este repositório contém pastas adicionais referentes aos testes práticos solicitados.

🗄️ Teste Prático de Conhecimento em SQL

Comandos SQL solicitados no teste:

- SELECT
- INSERT
- UPDATE
- DELETE

Os comandos foram organizados de forma clara, seguindo o enunciado proposto, com foco em legibilidade e boas práticas em SQL.

🧠 Teste Prático de Lógica

Contém o arquivo referente ao teste de lógica sobre a troca de um pneu furado, com:

- Resolução passo a passo dos problemas propostos

Essas pastas foram adicionadas com o objetivo de centralizar todas as entregas do teste prático em um único repositório, facilitando a avaliação técnica.

📌 Observações Finais

O projeto segue o padrão MVC.
Código organizado e de fácil manutenção.
Uso de boas práticas de versionamento (Conventional Commits).
Foco em clareza, organização e legibilidade para avaliação técnica.

👤 Autor

Wesley Vianna
```bash
GitHub: https://github.com/WesleyVianna
```