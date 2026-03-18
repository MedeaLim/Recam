🏡 Recam — Real Estate Media Delivery Platform

A scalable backend system designed to support real estate media workflows, enabling efficient management of property listings, media assets, and agent interactions.

Designed and implemented following enterprise-level backend architecture practices.

🚀 Overview

Recam provides a structured backend solution for managing real estate data and media delivery processes.
The system focuses on clean architecture, maintainability, and scalability, supporting multiple user roles and business workflows.

Key capabilities include:

Property listing lifecycle management

Media asset handling and organization

Agent collaboration and contact management

Secure authentication and role-based authorization

🧱 System Architecture

The project follows a layered architecture pattern:

Controller
↓
Application Service Layer
↓
Domain Logic
↓
Repository Layer
↓
Data Access (EF Core)
↓
SQL Server
Design Principles

Separation of concerns

Dependency Injection (DI)

SOLID principles

Clean layering between business logic and infrastructure

🔐 Authentication & Security

JWT-based authentication

Role-based access control (RBAC)

ASP.NET Identity integration

Secure endpoint protection

📦 Core Modules
🔹 Authentication & User Management

Handles user identity, authentication, and access control.

🔹 Listing Management

Manages property data and lifecycle transitions.

🔹 Media Management

Handles media upload, storage abstraction, and retrieval.

🔹 Agent Management

Supports agent-related workflows and listing associations.

🗄️ Data Management

Primary database:

SQL Server

Key entities:

User (Identity-based)

ListingCase

MediaAsset

Agent

CaseContact

StatusHistory

⚙️ Technology Stack
Backend

ASP.NET Core Web API (.NET 8)

Entity Framework Core

SQL Server

Supporting Tools

AutoMapper

FluentValidation

Swagger / OpenAPI

🛠️ Getting Started
1️⃣ Clone Repository
git clone https://github.com/your-username/recam.git
cd recam
2️⃣ Configure Environment

Update the database connection string in:

appsettings.json

Example:

Server=localhost,1433;Database=RecamDb;User Id=sa;Password=YourPassword;
3️⃣ Run Database Migration
dotnet ef database update

If needed, create migration:

dotnet ef migrations add InitialCreate
4️⃣ Run Backend API
dotnet run

API will be available at:

https://localhost:xxxx

Swagger UI:

https://localhost:xxxx/swagger
5️⃣ (Optional) Run Frontend

If frontend (React + Vite) is included:

cd frontend
npm install
npm run dev
🧩 Development Workflow

The project follows a structured Git workflow:

Issue → Branch → Commit → Pull Request → Merge

Milestones are used to group related features and track progress.

📈 Project Status

✅ Authentication & authorization completed

✅ Listing management completed

✅ Media management core features implemented

🔄 Agent management in progress

⏳ Preview and delivery features planned

🔮 Future Enhancements

Listing preview aggregation layer

Cloud storage integration (e.g., Azure Blob Storage)

Media selection and presentation logic

File packaging and delivery

Unit testing and performance optimization

👤 Author

Medea Lin
Bachelor of Advanced Computing — University of Sydney
Major: Software Development