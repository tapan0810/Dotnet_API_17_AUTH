🚀 Dotnet_API_17 – Authentication API (.NET 8 Web API)

A clean and structured ASP.NET Core Web API project implementing JWT-based Authentication with Login and Registration functionality.

📌 Features

✅ User Registration

✅ User Login

✅ JWT Token Generation

✅ Password Hashing

✅ Layered Architecture (Controller → Service → Data → Entities)

✅ Entity Framework Core with Migrations

✅ Clean Dependency Injection

🏗️ Project Structure
Dotnet_API_17
│
├── Controllers
│   └── AuthController.cs
│
├── Service
│   ├── IAuthService.cs
│   └── AuthService.cs
│
├── Entities
│   ├── Models
│   └── Dtos
│
├── Data
│   └── ApplicationDbContext.cs
│
├── Helper
│   └── JwtHelper
│
├── Migrations
│
├── Program.cs
└── appsettings.json
🔐 Authentication Flow
1️⃣ Register

User sends:

{
  "username": "testuser",
  "password": "123456"
}

Password is hashed.

User is saved to database.

Returns success response.

2️⃣ Login

User sends:

{
  "username": "testuser",
  "password": "123456"
}

Password is verified.

If valid → JWT token is generated.

Token is returned to the client.

📮 API Endpoints
🔹 Register
POST /api/Auth/Register

Response

200 OK → User created

400 BadRequest → Username already exists

🔹 Login
POST /api/Auth/Login

Response

200 OK → JWT Token

400 BadRequest → Invalid credentials

⚙️ Configuration
🔑 JWT Configuration (appsettings.json)
"Jwt": {
  "Key": "your_super_secret_key_here",
  "Issuer": "DotnetAPI",
  "Audience": "DotnetAPIUsers"
}
🧠 Technologies Used

ASP.NET Core Web API

Entity Framework Core

SQL Server

JWT Authentication

Dependency Injection

Clean Architecture Principles

🛠️ How to Run the Project
1️⃣ Clone the Repository
git clone <your-repository-url>
cd Dotnet_API_17
2️⃣ Update Database
dotnet ef database update
3️⃣ Run the Application
dotnet run

Swagger UI will be available at:

https://localhost:<port>/swagger
🛡️ Security Implemented

Password Hashing

JWT Token Expiry

Token Validation Middleware

Secure Authentication Flow

🚀 Future Improvements

🔥 Role-Based Authorization

🔥 Refresh Tokens

🔥 Email Verification

🔥 Rate Limiting

🔥 Logging with Serilog

🔥 Global Exception Handling Middleware

🔥 Docker Support

👨‍💻 Author

Developed as part of a structured .NET backend learning and authentication implementation project.
