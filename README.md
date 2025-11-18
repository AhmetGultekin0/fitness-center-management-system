# Fitness Center Management & Appointment System

A modern web-based management system for fitness centers built with ASP.NET Core MVC, featuring AI-powered workout recommendations and comprehensive appointment management.

## 🎯 Project Overview

This system enables fitness centers to manage their services, trainers, member appointments, and provide personalized AI-driven exercise recommendations. The platform streamlines operations for both gym administrators and members while offering intelligent fitness planning.

### 🏢 Gym Management
- Multi-gym support with individual configurations
- Operating hours and service type management (fitness, yoga, pilates, etc.)
- Service duration and pricing configuration

### 👨‍🏫 Trainer Management
- Trainer profiles with specialization areas (muscle building, weight loss, yoga, etc.)
- Service type assignments per trainer
- Availability scheduling system

### 📅 Appointment System
- Member appointment booking based on trainer availability
- Conflict detection and validation
- Detailed appointment records (service, duration, price, trainer info)
- Appointment approval workflow

### 📊 Reporting & REST API
- RESTful API with LINQ-based filtering
- Trainer listing and availability queries
- Member appointment history
- Date-based availability searches

### 🤖 AI Integration
- AI-powered workout recommendations
- Body type analysis (photo upload or manual input: height/weight/body type)
- Personalized diet and exercise plan suggestions
- Visual transformation predictions

## 🛠️ Technology Stack

- **Framework:** ASP.NET Core MVC (LTS)
- **Language:** C#
- **Database:** SQL Server / PostgreSQL
- **ORM:** Entity Framework Core
- **Query:** LINQ
- **Frontend:** HTML5, CSS3, JavaScript, jQuery
- **UI Framework:** Bootstrap 5
- **AI Service:** OpenAI API / Custom ML Model

## 🔐 Security Features

- Role-based authorization (Admin, Member)
- Secure user authentication
- Client-side and server-side data validation
- Protected admin panel

## 📋 Prerequisites

- .NET SDK (LTS version)
- SQL Server / PostgreSQL
- Visual Studio 2022 or VS Code
- Git

## 🚀 Getting Started

1. Clone the repository
```bash
git clone https://github.com/AhmetGultekin0/fitness-center-management-system.git
cd fitness-center-management-system
```

2. Configure the database connection in `appsettings.json`

3. Run database migrations
```bash
dotnet ef database update
```

4. Run the application
```bash
dotnet run
```

5. Navigate to `https://localhost:5001`


## 🎓 Academic Project

This project is developed as part of the Web Programming course at Sakarya University.

## 📝 License

This project is developed for educational purposes.


---

**Note:** This is an academic project developed for the 2025-2026 Fall Semester Web Programming course.
