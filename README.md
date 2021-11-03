# eBank

Desafio técnico que consiste no desenvolvimento de uma aplicação web com cadastro de contas bancárias seguindo algumas premissas estabelecidas. O back-end do projeto foi elaborado 
em (Asp.Net Core 3.1 + SQL Server) com modelagem e design da arquitetura baseado no Domain Driven Design (DDD) com princípios SOLID.

# Rodar o Projeto (SQL Server)

- Sem o docker
  - Criar um banco de dados e alterar a "string" de conexão no arquivo "Startup.cs" em "eBank.AccountApi", "eBank.BankApi" e "eBank.OwnerApi";
- Com o docker
  - Acesse o prompt de comando navegando até a pasta principal do projeto onde tem o arquivo docker-compose.yml e digite "docker-compose -f docker-compose.yml up"

# Rodar o Projeto (Sistema)

- Selecionar o projeto "eBank.AccountApi" como "Set as StartUp Project";
- No Package Manage Console, selecionar o projeto "4.0-Infrastructure/4.1-Data/eBank.Infra.Data" como default project;
- Atualizar o banco com o seguinte comando no Package Manage Console
  - "add-migration InitialData"
  - "Update-Database"
- Acesse as propriedades da solução através do clique com botão direito na solution "eBank" -> properties -> Common Properties -> Startup Project: 
  - Multiple startup projects:
    - "eBank.AccountApi"
    - "eBank.BankApi"
    - "eBank.OwnerApi"
    - "eBank.FrontEnd.Web"


- Rodar o Projeto

# Detalhes
  - Alguns detalhes sobre o projeto estão sendo enviados em anexo por e-mail.

