# 📦 Catálogo de Vendas - Clean Architecture com ASP.NET Core

Este repositório contém uma aplicação de **Catálogo de Vendas** desenvolvida com **ASP.NET Core MVC**, utilizando os princípios da **Clean Architecture** para garantir um código bem estruturado, modular e fácil de manter.

## 🚀 Sobre o Projeto

O projeto foi criado com base nos conceitos da **Clean Architecture**, que visa organizar a estrutura do software de forma que seja fácil de entender, modificar e escalar conforme o crescimento da aplicação. Com isso, evitamos um código acoplado e garantimos maior flexibilidade para futuras mudanças.

O sistema permite a gestão de produtos, categorias e estoque, oferecendo uma solução robusta para catálogos de vendas.

## 🔧 Tecnologias Utilizadas

- **ASP.NET Core MVC** - Framework para desenvolvimento web  
- **.NET 7, .NET 8 e .NET 9..** - Suporte a múltiplas versões do .NET  
- **Entity Framework Core** - ORM para acesso a dados  
- **CQRS (Command Query Responsibility Segregation)** - Separação entre leitura e escrita  
- **Injeção de Dependência (IoC)** - Para melhor organização do código  
- **Repository Pattern** - Camada de abstração para manipulação de dados  
- **Domain Driven Design (DDD)** - Organização do domínio da aplicação  
- **Swagger** - Documentação automática da API  

## 🏗 Arquitetura do Projeto

O projeto é dividido em **cinco camadas**, cada uma com uma responsabilidade específica:

1. **Domain** - Contém as entidades e regras de negócio da aplicação.  
2. **Application** - Responsável pelos casos de uso e comunicação com o domínio.  
3. **Infrastructure** - Implementação de acesso a dados e integrações externas.  
4. **IoC (Inversion of Control)** - Configuração da injeção de dependências.  
5. **Presentation** - Camada responsável pela interface do usuário, desenvolvida com **ASP.NET Core MVC**.  

## 🛠 Funcionalidades

✅ Cadastro e gerenciamento de produtos  
✅ Cadastro e gerenciamento de categorias  
✅ Controle de estoque  
✅ Separação de responsabilidades conforme a **Clean Architecture**  
✅ Aplicação das boas práticas de **DDD, CQRS e Repository Pattern**  

## 🎯 Objetivo
Este projeto tem como objetivo demonstrar a aplicação dos conceitos de Clean Architecture na prática, tornando o desenvolvimento mais modular e seguindo as melhores práticas do mercado.
