# Clean Architecture 101

A modern .NET application demonstrating Clean Architecture principles with MediatR, Docker containers, and SQL Server.

## 🏗️ Architecture Overview

This project follows Clean Architecture principles, ensuring:
- Independence of framework
- Testability
- Independence of UI
- Independence of Database
- Independence of any external agency

### Layer Structure
```
src/
├── Core/
│   ├── Domain
│   └── Application
└── External/
    ├── Infrastructure
    └── API
```

## 🚀 Key Features

- Clean Architecture implementation
- CQRS pattern using MediatR
- Docker containerization
- SQL Server database
- RESTful API endpoints
- Dependency Injection
- Domain-Driven Design principles

## 🛠️ Technology Stack

- .NET 7.0+
- MediatR for CQRS
- Entity Framework Core
- SQL Server
- Docker & Docker Compose
- Swagger/OpenAPI

## 🏃‍♂️ Getting Started

### Prerequisites

- Docker Desktop
- .NET 7.0 SDK
- Visual Studio 2022 or VS Code

### Running the Application

1. Clone the repository
```bash
git clone https://github.com/yourusername/CleanArchitecture101.git
```

2. Navigate to the project directory
```bash
cd CleanArchitecture101
```

3. Start the containers
```bash
docker-compose up -d
```

4. The API will be available at: `http://localhost:5000`
5. Swagger documentation: `http://localhost:5000/swagger`

## 🏛️ Architecture Details

### Domain Layer
- Contains enterprise logic and types
- No dependencies on other layers
- Includes entities, value objects, and domain events

### Application Layer
- Contains business logic
- Implements CQRS with MediatR
- Defines interfaces for external dependencies

### Infrastructure Layer
- Implements interfaces defined in the Application layer
- Contains database context, migrations, and external service implementations
- Handles data persistence and external communications

### API Layer
- Handles HTTP requests and responses
- Contains controllers and middleware
- Manages API versioning and documentation

## 📝 Design Decisions

- **CQRS with MediatR**: Separates read and write operations
- **Docker Containers**: Ensures consistent development and deployment environments
- **Clean Architecture**: Maintains separation of concerns and dependency flow
- **Domain-Driven Design**: Focus on core domain logic and business rules

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Open a pull request

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details