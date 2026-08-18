# Personal Blogging Platform API

A RESTful Web API for managing a personal blogging platform, built using **ASP.NET Core**, **C#**, **ADO.NET**, and **SQL Server**.

The project is designed using a **Layered Architecture** to provide a clean, maintainable, and scalable structure while separating business logic, data access, domain models, and API responsibilities.

## 📌 Project Overview

The **Personal Blogging Platform API** provides a backend system for managing blog articles through a set of RESTful API endpoints.

The API allows users to:

* Create new articles
* Retrieve all articles
* Retrieve a specific article by ID
* Update existing articles
* Delete articles
* Store article information in SQL Server
* Execute database operations using Stored Procedures

The project focuses on applying practical **Software Engineering principles**, including separation of concerns, dependency injection, interfaces, DTOs, layered architecture, and clean database access using ADO.NET.

---

## 🏗️ Architecture

The project follows a **Layered Architecture** consisting of the following layers:

```text
Personal Blogging Platform API
│
├── Blog.Application
│   ├── DTOs
│   ├── Interfaces
│   └── Services
│
├── Blog.Domain
│   ├── Entities
│   └── Interfaces
│
├── Blog.Infrastructure
│   └── Data Access
│
└── Personal Blogging Platform API
    ├── Controllers
    ├── Program.cs
    └── appsettings.json
```

### 1. Blog.Domain

The Domain layer contains the core business entities and domain-related interfaces.

Responsibilities include:

* Defining application entities
* Representing the core business model
* Defining contracts used by other layers
* Keeping the core domain independent from infrastructure and API concerns

Example:

```text
Blog.Domain
├── Entities
│   └── Article.cs
│
└── Interfaces
```

---

### 2. Blog.Application

The Application layer contains the application's business logic and contracts.

Responsibilities include:

* DTO definitions
* Application interfaces
* Business services
* Validation and application-level operations
* Communication between the API and infrastructure layers

Example:

```text
Blog.Application
├── DTOs
│   └── ArticleDTO.cs
│
├── Interfaces
│
└── Services
```

---

### 3. Blog.Infrastructure

The Infrastructure layer is responsible for communicating with the database.

The project uses **ADO.NET** instead of Entity Framework Core.

Responsibilities include:

* SQL Server database access
* `SqlConnection`
* `SqlCommand`
* Executing Stored Procedures
* Mapping database results to application/domain objects
* Implementing data access interfaces

Example:

```text
Blog.Infrastructure
└── Data
    └── ArticleRepository.cs
```

---

### 4. Blog.API

The API layer is responsible for exposing the application's functionality through HTTP endpoints.

Responsibilities include:

* HTTP requests and responses
* Controllers
* Routing
* Dependency Injection configuration
* Returning appropriate HTTP status codes
* Connecting the API layer with the Application layer

Example:

```text
Personal Blogging Platform API
├── Controllers
│   └── ArticlesController.cs
├── Program.cs
└── appsettings.json
```

---

# 🛠️ Technologies Used

* **C#**
* **ASP.NET Core Web API**
* **.NET**
* **ADO.NET**
* **SQL Server**
* **T-SQL**
* **Stored Procedures**
* **RESTful API**
* **Dependency Injection**
* **DTOs**
* **Layered Architecture**
* **SOLID Principles**
* **Git & GitHub**

---

# 🗄️ Database

The project uses **Microsoft SQL Server** as the database system.

Database operations are implemented using **Stored Procedures** instead of writing SQL queries directly inside controllers or services.

The main Stored Procedures include:

```text
SP_Articles_GetAll
SP_Articles_GetById
SP_Articles_Add
SP_Articles_Update
SP_Articles_Delete
```

This approach helps keep database logic separated from the API and business logic.

---

# 📝 Articles

The main entity in the system is the `Article`.

An article contains information such as:

* Article ID
* Title
* Content
* Author
* Publication date
* Tags

Example:

```json
{
  "articleId": 1,
  "title": "Introduction to ASP.NET Core",
  "content": "ASP.NET Core is a cross-platform framework...",
  "author": "Ali",
  "publishedDate": "2026-08-18",
  "tags": "ASP.NET Core,C#,API"
}
```

---

# 🔌 API Endpoints

The API follows REST principles.

## Get All Articles

```http
GET /api/Articles
```

Returns all available articles.

---

## Get Article By ID

```http
GET /api/Articles/{id}
```

Returns a specific article using its ID.

Example:

```http
GET /api/Articles/1
```

---

## Create Article

```http
POST /api/Articles
```

Creates a new article.

Example request:

```json
{
  "title": "Building REST APIs with ASP.NET Core",
  "content": "In this article, we will learn how to build RESTful APIs...",
  "author": "Ali",
  "tags": "ASP.NET Core,API,C#"
}
```

The API returns an appropriate HTTP response containing the newly created resource.

---

## Update Article

```http
PUT /api/Articles/{id}
```

Updates an existing article.

Example:

```http
PUT /api/Articles/1
```

---

## Delete Article

```http
DELETE /api/Articles/{id}
```

Deletes an existing article.

Example:

```http
DELETE /api/Articles/1
```

---

# 🔄 Request Flow

A typical request follows this flow:

```text
Client
   │
   ▼
Controller
   │
   ▼
Application Service
   │
   ▼
Repository / Data Access
   │
   ▼
ADO.NET
   │
   ▼
SQL Server
   │
   ▼
Stored Procedure
```

For example, when creating an article:

```text
POST /api/Articles
        │
        ▼
ArticlesController
        │
        ▼
ArticleService
        │
        ▼
ArticleRepository
        │
        ▼
SqlCommand
        │
        ▼
SP_Articles_Add
        │
        ▼
SQL Server
```

This separation makes the application easier to maintain, test, and extend.

---

# 🧩 Dependency Injection

The project uses **Dependency Injection** to reduce coupling between components.

Instead of creating dependencies directly inside controllers or services, dependencies are provided by the ASP.NET Core Dependency Injection container.

For example:

```csharp
public ArticlesController(IArticleService articleService)
{
    _articleService = articleService;
}
```

This improves:

* Maintainability
* Testability
* Flexibility
* Separation of Concerns

---

# 📦 DTOs

The project uses **Data Transfer Objects (DTOs)** to control the data exchanged between the API and clients.

DTOs help prevent exposing internal domain models directly through the API.

Example:

```csharp
public class ArticleDTO
{
    public int ArticleId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string? Tags { get; set; }
}
```

---

# 🔐 Configuration

Database configuration is stored in the application's configuration files.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "your-connection-string"
  }
}
```

Sensitive information such as database passwords should not be committed to GitHub.

For development environments, sensitive configuration should be managed using appropriate environment-specific configuration or secret-management mechanisms.

---

# 🧪 Testing the API

The API can be tested using tools such as:

* Swagger / OpenAPI
* Postman
* Visual Studio
* `.http` files

Example:

```http
GET https://localhost:xxxx/api/Articles
```

---

# 📁 Project Structure

```text
Personal Blogging Platform API
│
├── Blog.Application
│   ├── DTOs
│   ├── Interfaces
│   └── Services
│
├── Blog.Domain
│   ├── Entities
│   └── Interfaces
│
├── Blog.Infrastructure
│   ├── Data
│   └── Repositories
│
├── Personal Blogging Platform API
│   ├── Controllers
│   │   └── ArticlesController.cs
│   ├── Properties
│   ├── Program.cs
│   ├── appsettings.json
│   └── Blog.API.csproj
│
├── SQL
│   ├── Tables
│   │   └── Articles.sql
│   │
│   └── StoredProcedures
│       ├── SP_Articles_GetAll.sql
│       ├── SP_Articles_GetById.sql
│       ├── SP_Articles_Add.sql
│       ├── SP_Articles_Update.sql
│       └── SP_Articles_Delete.sql
│
└── README.md
```

---

# 🎯 Project Goals

The main goals of this project are to:

* Build a complete RESTful Web API
* Apply Layered Architecture
* Practice ASP.NET Core Web API development
* Work with SQL Server and ADO.NET
* Implement database operations using Stored Procedures
* Apply SOLID principles
* Practice Dependency Injection
* Separate business logic from data access
* Build maintainable and scalable backend software
* Gain practical experience with Git and GitHub

---

# 🚀 Future Improvements

Possible future enhancements include:

* User authentication and authorization
* JWT authentication
* Role-based access control
* Article categories
* Comments system
* Likes and reactions
* Pagination
* Searching and filtering
* Sorting
* Image/file uploads
* Global exception handling
* Logging
* API versioning
* Unit and integration testing
* Docker support
* CI/CD pipeline

---

# 👨‍💻 Author

**Ali Al-Aidi**

Software Engineering graduate interested in backend development, software architecture, and building scalable web applications.

---

## 📄 License

This project is created for educational and development purposes.
