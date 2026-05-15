# SaigonRide — Distributed Vehicle Rental System

## Live Demo

```text
https://saigonride.onrender.com
```

## GitHub Repository

```text
https://github.com/WhyZynx/SaigonRide_SE_Project.git
```

---

# 1. Project Overview

SaigonRide is a distributed electric vehicle rental management system developed using ASP.NET Core MVC and Entity Framework Core.

The system allows users to:

* Rent electric vehicles
* Return vehicles between stations
* View station inventory
* Track rental sessions
* Calculate rental pricing automatically

The project also provides an admin management system for:

* Vehicle management
* Station management
* Rental monitoring
* Revenue and dashboard analytics

This project was implemented as a Tier-3 Software Engineering Final Project.

---

# 2. Problem Statement

Urban vehicle rental systems often face problems such as:

* Poor vehicle distribution
* Low station inventory visibility
* Manual rental management
* Inconsistent pricing logic
* Weak transaction validation
* Difficulty synchronizing rental operations

SaigonRide was developed to solve these issues by providing:

* Real-time station monitoring
* Smart rental validation
* Battery-aware rental management
* Flexible pricing strategy calculation
* Transaction-safe rental processing
* Scalable service-based architecture

---

# 3. Main Features

## User Features

### Vehicle Rental

* View available stations
* Browse available vehicles
* Start rental sessions
* End rental sessions
* Return vehicles to stations

### Validation & Safety

* Prevent low battery rentals
* Prevent multiple active rentals
* Validate station capacity
* Vehicle status synchronization

### Pricing

* Automatic rental calculation
* Discount incentives for low-capacity stations
* Final pricing summary

---

## Admin Features

### Vehicle Management

* Create vehicle
* Update vehicle
* Delete vehicle
* Assign vehicles to stations
* Monitor battery levels
* Track vehicle status

### Station Management

* Create station
* Update station
* Delete station
* View inventory status
* Monitor station capacity
* Detect low inventory stations

### Dashboard & Analytics

* Revenue overview
* Vehicle statistics
* Rental analytics
* Active rental tracking
* Real-time synchronization

---

# 4. Technology Stack

## Backend

* ASP.NET Core MVC
* Entity Framework Core
* SQL Server
* LINQ
* Dependency Injection

## Frontend

* Razor Views
* Bootstrap
* JavaScript
* jQuery

## Security

* BCrypt password hashing
* Session authentication
* Role-based authorization

## Development Tools

* Visual Studio 2022
* SQL Server Management Studio
* Git & GitHub

---

# 5. Core Modules

## Vehicle Management

Handles:

* Vehicle lifecycle
* Vehicle status updates
* Battery validation
* Station assignment

Important rule:

```text
Vehicles below 20% battery cannot be rented.
```

---

## Station Management

Handles:

* Inventory management
* Capacity monitoring
* Low inventory detection
* Full station validation

Important methods:

* GetFillPercent()
* IsLowCapacity()
* IsFull()

---

## Rental Lifecycle

Rental flow:

1. User selects station
2. User selects vehicle
3. System validates rental conditions
4. Rental record created
5. Vehicle status changes to InUse
6. User returns vehicle
7. Pricing calculated
8. Rental completed

Important rules:

* One active rental per user
* Battery must be above 20%
* Transactions must remain consistent

---

## Pricing Strategy

The system uses the Strategy Pattern for pricing calculation.

Pricing includes:

* Base rental amount
* Discount incentives
* Final amount calculation

Discount rule:

```text
Returning vehicles to low-capacity stations applies a 15% discount.
```

---

# 6. Project Structure

```text
SaigonRideProject/
│
├── Controllers/
├── Models/
├── Services/
├── ViewModels/
├── Views/
├── Data/
├── Migrations/
├── wwwroot/
└── Program.cs
```

---

# 7. Environment Variables

Update `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=SaigonRideDB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

---

# 8. Installation Guide

## Requirements

* Visual Studio 2022
* .NET 8 SDK
* SQL Server

---

## Step 1 — Clone Repository

```bash
git clone https://github.com/WhyZynx/SaigonRide_SE_Project.git
```

---

## Step 2 — Configure Database

Update:

```text
appsettings.json
```

Configure:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=SaigonRideDB;Trusted_Connection=True;TrustServerCertificate=True"
}
```

---

## Step 3 — Run Migration

```bash
Update-Database
```

---

## Step 4 — Run Project

```bash
dotnet run
```

---

# 9. Deployment

## Render Deployment

Production URL:

```text
https://saigonride.onrender.com
```

## Build Release Version

```bash
dotnet publish -c Release
```

---

# 10. Testing Accounts

The system includes seeded demo accounts.

## Admin Account

```text
Email: admin@saigonride.com
Password: 123456
Role: Admin
```

## Local User Account

```text
Email: nguyenvana@gmail.com
Password: 123456
Role: User
```

## Tourist User Account

```text
Email: johnsmith@gmail.com
Password: 123456
Role: User
```

---

# 11. Included Seed Data

The database includes:

* Demo users
* Demo stations
* Demo vehicles
* Demo rentals
* Demo transactions
* Battery level scenarios
* Pricing scenarios

---

# 12. Quick Testing Flow

## User Rental Flow

1. Login with a user account
2. Open station list
3. Select available vehicle
4. Start rental session
5. Verify vehicle status changes to `InUse`
6. Return vehicle to another station
7. Verify pricing result
8. Verify discount for low-capacity station

---

## Admin Testing Flow

1. Login with admin account
2. Open dashboard
3. Manage stations
4. Manage vehicles
5. View active rentals
6. Monitor revenue statistics

---

# 13. Validation Rules

## Rental Validation

```text
BatteryLevel > 20%
```

## Business Rules

* One active rental per user
* Vehicles below 20% battery cannot be rented
* Full stations cannot receive returned vehicles
* Vehicle status synchronizes automatically
* Pricing incentives apply dynamically

---

# 14. Design Patterns Used

## MVC Pattern

Used for:

* Separation of concerns
* Clean architecture

## Strategy Pattern

Used for:

* Flexible pricing logic
* Customer pricing strategies

## Service Layer Pattern

Used for:

* Business logic separation
* Reusable services

---

# 15. Unit Testing

Tested areas:

* Rental validation
* Pricing calculation
* Station capacity logic
* Vehicle status synchronization

---

# 16. Contributors

Project developed for:

```text
Software Engineering Final Project
Tier-3 ASP.NET MVC System
```

---

# 17. Conclusion

SaigonRide demonstrates a distributed vehicle rental system with:

* Real-time station management
* Smart rental validation
* Flexible pricing strategies
* Transaction consistency
* Clean MVC architecture
* Service-based business logic

The project successfully fulfills the software engineering requirements for a scalable and maintainable rental management platform.
