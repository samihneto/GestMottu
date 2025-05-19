# CP2 - Advanced Business Development with .NET - 2025

## Projeto: API RESTful para Gestão de Motos - Mottu

Este projeto é o 2° Checkpoint da disciplina **Advanced Business Development with .NET** e tem como objetivo desenvolver uma **API RESTful** utilizando **.NET 8** e **banco de dados Oracle**.

## Integrantes

- Felipe Levy Stephens Fidelix - RM556426
- Jennifer Suzuki  - RM554661
- Samir Hage Neto - RM557260

---

## Proposta do Projeto

Criar uma API que permita a gestão completa das motos da empresa, com funcionalidades para cadastrar, consultar, atualizar e deletar registros, além de buscar motos por características específicas.

---

## Funcionalidades

- CRUD completo para entidades do domínio, com tratamento adequado das respostas HTTP:
  - `GET`, `POST`, `PUT`, `DELETE`
- Implementação de relacionamentos entre entidades (ainda em desenvolvimento)
- Validação e regras de negócio incorporadas às entidades
- Uso de DTOs para entrada e saída de dados
- Mapeamento automático de objetos com AutoMapper
- Conexão com banco Oracle usando EF Core
- Migrations para versionamento e evolução do banco de dados
- Variáveis de ambiente para configuração segura da string de conexão
- Documentação interativa via Swagger/OpenAPI

---

## Estrutura do Projeto

- **Domain**: Entidades, agregados e regras de negócio  
- **Application**: Serviços, DTOs, interfaces e casos de uso  
- **Infrastructure**: Implementação de persistência, DbContext, repositórios  
- **Presentation**: API Controllers e configuração do endpoint REST  

---

## Tecnologias Utilizadas

- .NET 8  
- C#  
- Entity Framework Core (EF Core)  
- Oracle Database  
- Swagger / OpenAPI  
- AutoMapper  
- Visual Studio 2022  

---

## Rotas Disponíveis

| Método | Endpoint           | Descrição                       |
|--------|--------------------|--------------------------------|
| GET    | /api/motos         | Lista todas as motos            |
| GET    | /api/motos/{id}    | Consulta moto por ID            |
| GET    | /api/motos/buscar  | Busca motos por modelo (query) |
| POST   | /api/motos         | Cadastra nova moto              |
| PUT    | /api/motos/{id}    | Atualiza dados de uma moto      |
| DELETE | /api/motos/{id}    | Remove uma moto pel
