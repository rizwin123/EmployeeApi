# Employee API

A containerized ASP.NET Core Web API demonstrating CQRS/MediatR patterns, EF Core with SQL Server, unit testing with xUnit + Moq, and Docker multi-stage builds.

## Features

- **CRUD Endpoints**: GET all, GET by ID, POST create, PUT update, DELETE
- **MediatR/CQRS**: Queries and Commands decoupled from Controllers
- **EF Core**: Entity Framework Core with SQL Server + migrations
- **Unit Tests**: xUnit + in-memory database, 100% handler coverage
- **Docker**: Multi-stage Dockerfile, docker-compose for local dev
- **CI/CD**: GitHub Actions build and test pipeline

## Tech Stack

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core 8.0.26
- MediatR 12.4.1
- xUnit + Moq
- Azure SQL Edge (Docker)
- Docker & docker-compose

## Project Structure