# 🏡 Recam — Real Estate Media Delivery Platform

A scalable backend system for managing real estate listings, media assets, and agent workflows.

---

## 🚀 Quick Start

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/your-username/recam.git
cd recam
```

---

### 2️⃣ Configure Database

Edit:

```bash
Recam.API/appsettings.json
```

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=RecamDb;User Id=sa;Password=YourPassword;TrustServerCertificate=True;Encrypt=False"
}
```

---

### 3️⃣ Apply Migrations

```bash
dotnet ef database update \
--project Recam.DataAccess \
--startup-project Recam.API
```

---

### 4️⃣ Run Backend API

```bash
dotnet run --project Recam.API
```

---

### 5️⃣ Open Swagger

```
https://localhost:xxxx/swagger
```

---

### 6️⃣ Run Frontend (Optional)

```bash
cd frontend
npm install
npm run dev
```

---

## 🧱 Architecture

```
Controller
↓
Service Layer
↓
Repository Layer
↓
EF Core (DbContext)
↓
SQL Server
```

---

## 🔐 Features

- JWT Authentication  
- Role-Based Authorization  
- Listing Management  
- Media Upload & Storage  
- Agent Contact Management  

---

## ⚙️ Tech Stack

- ASP.NET Core (.NET 8)
- Entity Framework Core
- SQL Server
- AutoMapper
- FluentValidation
- Swagger

---

## 📈 Status

- Auth Module ✅  
- Listing Module ✅  
- Media Module ✅  
- Agent Module 🔄  
- Preview Module ⏳  

---

## 👤 Author

Medea Lin  
University of Sydney — Software Development  