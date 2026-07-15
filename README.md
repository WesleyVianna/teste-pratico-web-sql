# 📍 **Sistema de Pontos Turísticos**

Aplicação web desenvolvida em ASP.NET Core MVC para cadastro, visualização e gerenciamento de pontos turísticos, com integração à API do IBGE para carregamento dinâmico de estados e cidades.

O projeto foi desenvolvido como parte de um teste prático, priorizando organização, clareza de código, separação de responsabilidades e boas práticas de desenvolvimento.

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
(Ou utilize a porta informada no terminal durante a execução da aplicação.)


## 🌎 **Integração com a API do IBGE**

A aplicação consome a API oficial do IBGE para:

- Listar os estados brasileiros.
- Carregar cidades dinamicamente conforme o estado selecionado.

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

✔️ Cadastro de Ponto Turístico;

✔️ Listagem em formato de cards;

✔️ Visualização de detalhes;

✔️ Edição de registros;

✔️ Exclusão com confirmação;

✔️ Validações com DataAnnotations;

✔️ Validações visuais com Bootstrap;

✔️ Layout responsivo;

✔️ Integração com a API do IBGE;


🗂️ Estrutura do Projeto

- Controllers — Responsáveis pelo processamento das requisições e controle do fluxo da aplicação;
- Models — Contêm as entidades e validações da aplicação;
- Views — Responsáveis pela interface com o usuário utilizando Razor;
- Data — Contexto do banco de dados utilizando Entity Framework Core;
- wwwroot — Arquivos estáticos, como CSS, JavaScript e imagens.


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