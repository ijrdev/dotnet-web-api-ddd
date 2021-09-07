# .NET Web Api DDD

## Introdução

Dois motivos levaram ao desenvolvimento desse pequeno e simples projeto, são eles: Colocar em prática algumas coisas das quais foram aprendidas com a tecnologia e tentar aplicar o DDD (Domain Driven Design).
O intuito é apenas mostrar toda organização, estrutura e arquitetura, além de usar como guia e base para futuros projetos.

## Pré-Requisitos

 [![](https://img.shields.io/badge/.NET%20Core-v5.0.400-blue)](https://dotnet.microsoft.com/download)  [![](https://img.shields.io/badge/SQL%20Server-v15.0.2800-blue)](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) 

- Realizar a configuração de acesso do SQL Server nas configurações do projeto;
- Rodar os comandos de Migration para serem criadas as tabelas no banco de dados.

## O que foi aplicado/utilizado no projeto?

### .NET Web Api

DI - IoC - Data Annotation - Generic Types - Method Overloading  - Method Extension - Repository - Factory - Singleton - DTO - Autentication - Web Filters - Middlewares.

### Entity Framework

Development Approaches (Code First) - Migration - Mapping - LINQ - Eager Loading - Async Operations.

### Boas práticas com a intenção de melhorar o código

- Importação de pacotes que realmente serão utilizados;
- Instalação das dependências corretamente em seus devidos projetos;
- Referenciamento de forma concisa os projetos entre si;
- Padronização e organização das Exceptions;
- Padronização e organização das Responses e das Response Messages;
- Utilizações de Consts e Enums evitando o uso de números mágicos e strings soltas na aplicação;
- Padronização nos fluxos, onde o que é feito em determinado ponto de uma entidade, as demais deverão fazer e seguir o padrão estabelecido, assim, buscando uma organização e deixando o código mais legível.

##  O que o projeto faz?

Como mencionado acima que o propósito do projeto é apenas para colocar em prática os conhecimentos obtidos, o que ele realiza é bastante simples, basicamente são simples CRUD's de clientes, conta bancária e transações bancárias. Muitos detalhes foram deixados de lado para se ter um foco direcionado para o real objetivo da aplicação.

### Auth

- POST -  `/api/auth`

### Clients

- GET -  `/api/clients`
- POST -  `/api/clients`
- PUT -  `/api/clients/{id}`

### Accounts

- POST -  `/api/accounts`

### Accounts Transactions

- GET -  `/api/accountsTransactions/statements`
- POST -  `/api/accountsTransactions/deposit`
- POST -  `/api/accountsTransactions/withdraw`
- POST -  `/api/accountsTransactions/transfer`
