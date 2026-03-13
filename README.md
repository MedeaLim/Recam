# Recam

Recam is a full-stack real estate media management platform.

This project demonstrates a modern full-stack architecture using a React frontend and an ASP.NET Core backend with SQL Server and MongoDB.

---

# Tech Stack

## Frontend
- React
- TypeScript
- Vite

## Backend
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- MongoDB

---

# Project Structure

```
Recam
│
├── Recam.API          # ASP.NET Core Web API
├── Recam.Services     # Business logic layer
├── Recam.Repository   # Data access abstraction
├── Recam.DataAccess   # EF Core + DbContext
├── Recam.Models       # Domain models
├── Recam.Common       # Shared configuration classes
│
└── frontend           # React frontend application
```

---

# Running the Project

## 1️⃣ Start Backend

```bash
cd Recam.API
dotnet run
```

Backend runs at:

```
http://localhost:5197
```

Swagger UI:

```
http://localhost:5197/swagger
```

---

## 2️⃣ Start Frontend

```bash
cd frontend
npm install
npm run dev
```

Frontend runs at:

```
http://localhost:5173
```

---

# API Example

Health check endpoint:

```
GET /api/health
```

Example response:

```
Healthy
```

---

# Architecture

The backend follows a layered architecture:

```
Controller
   ↓
Services
   ↓
Repository
   ↓
Database
```

This design improves separation of concerns and maintainability.

---

# Development Status

Milestone 1 Completed:

- Backend API setup
- SQL Server integration with Entity Framework Core
- MongoDB integration
- Layered backend architecture
- React frontend setup
- API communication between frontend and backend
- Environment configuration
- Project documentation

---

# Future Development

Planned features include:

- Listing management API
- Image upload and storage
- React listing pages
- Authentication and authorization