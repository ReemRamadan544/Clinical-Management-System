# 🏥 Clinical Management System — Full Stack (ASP.NET Core + Angular)

A complete full-stack **Clinical Management System** for managing patients, doctors, students, treatments, bookings, and administration.  
The backend is built with **ASP.NET Core Web API** and **Entity Framework Core**; the frontend is built with **Angular 17**.

---

## 📌 Features
### 🔹 Backend (ASP.NET Core)
- CRUD APIs for Admin, Doctor, Student, Treatment, Booking.
- Authentication & Authorization with JWT (Admin/Doctor/Student logins).
- EF Core with Code-First Migrations.
- Swagger API documentation.
- File upload (Excel import for students via EPPlus).

### 🔹 Frontend (Angular)
- Admin dashboard: manage doctors, patients/students, treatments, bookings.
- Doctor & Student login flows.
- Forms with validation & file upload.
- Role-based navigation (guards & interceptors ready).
- Responsive layout with Bootstrap & Angular Material.

---

## 🗂 Project Structure
BackendProject/ # ASP.NET Core Web API
Controllers/
Models/
DTO/
Data/ # DbContext + Migrations
Services/
Program.cs
appsettings.json

frontend/clinic/ # Angular 17 frontend
src/
app/
assets/
environments/
angular.json
package.json


---

## ⚙️ Setup & Run (Development)

### 1️⃣ Backend (ASP.NET Core)
**Prerequisites**
- .NET 6 SDK or later
- SQL Server LocalDB or any SQL Server instance

**Steps**
```bash
cd BackendProject/universty\ dental\ clinical
dotnet restore
dotnet ef database update
dotnet run
By default, runs at: https://localhost:7086

Note: Move sensitive configs (ConnectionString, JWT Key) from appsettings.json to User Secrets.

###2️⃣ Frontend (Angular)
**Prerequisites**
Node.js 18+
Angular CLI (npm install -g @angular/cli)

**Steps**
```bash
cd frontend/clinic
npm install
ng serve --open
Runs at: http://localhost:4200

🔗 Connecting Frontend to Backend
Edit:

ts
// src/environment.ts
export const environment = {
    baseUrl: "https://localhost:7086"
}
Change baseUrl for production builds.

🚀 Production Build
Frontend

bash
Copy
Edit
cd frontend/clinic
ng build --configuration production
Output in dist/clinic/.

Backend

bash
dotnet publish -c Release
Deploy to IIS, Azure, Docker, etc.

🛠 Recommended Improvements Before Deployment
Backend
Use User Secrets or environment variables for DB connection & JWT Key.

Add [Authorize] attributes for role-based access.

Enable CORS:

builder.Services.AddCors(o => o.AddPolicy("AllowFrontend",
    p => p.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()));
...
app.UseCors("AllowFrontend");
Frontend
Add AuthGuard to protect routes.

Add HttpInterceptor to attach JWT token automatically.

Create environment.prod.ts with production API URL.
