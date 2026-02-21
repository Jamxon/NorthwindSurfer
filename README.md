# NorthwindSurfer Console App (.NET + Dapper)

## 📌 Project haqida

Bu loyiha **.NET Console Application** bo'lib, Northwind database bilan
ishlaydi.\
Dapper ORM orqali CRUD operatsiyalar bajariladi.

Loyiha quyidagi modullar bilan ishlaydi:

-   Categories
-   Customers
-   Products (Category join bilan)
-   Orders (Customer join bilan)

Console menu orqali barcha CRUD amallarni bajarish mumkin.

------------------------------------------------------------------------

## 🛠 Texnologiyalar

-   C# (.NET)
-   Dapper
-   SQL Server
-   Console App (menu based)
-   ADO.NET connection

------------------------------------------------------------------------

## 📂 Project struktura

    NorthwindSurfer
     ├── Data
     │    └── DbContext.cs
     │
     ├── Model
     │    ├── Categories.cs
     │    ├── Customers.cs
     │    ├── Products.cs
     │    └── Orders.cs
     │
     ├── Service
     │    ├── CategoryService.cs
     │    ├── CustomerService.cs
     │    ├── ProductService.cs
     │    └── OrderService.cs
     │
     └── Program.cs

------------------------------------------------------------------------

## ⚙️ Database sozlash

### SQL Server connection string:

DbContext.cs ichida:

``` csharp
public string connectionString =
"Server=localhost;Database=NorthWind;Trusted_Connection=True;TrustServerCertificate=True;";
```

Agar SQL login ishlatsang:

    Server=localhost;
    Database=NorthWind;
    User Id=sa;
    Password=1234;
    TrustServerCertificate=True;

------------------------------------------------------------------------

## 📦 NuGet paketlar

Quyidagilar o'rnatilishi kerak:

    Dapper
    Microsoft.Data.SqlClient

Visual Studio:

    Tools → NuGet Package Manager → Manage NuGet Packages

------------------------------------------------------------------------

## 🚀 Run qilish

Visual Studio:

    Ctrl + F5

yoki terminal:

    dotnet run

------------------------------------------------------------------------

## 🧭 Console Menu

Program ishga tushganda:

    1) Categories
    2) Customers
    3) Orders
    4) Products
    0) Exit

Har bir bo'limda:

    1 Create
    2 List
    3 Get by id
    4 Update
    5 Delete

CRUD to'liq ishlaydi.

------------------------------------------------------------------------

## 🔗 JOIN ishlatilgan joylar

### Products → Category

    Product ichida Category qaytadi

### Orders → Customer

    Order ichida Customer qaytadi

Dapper multi-mapping ishlatilgan.

------------------------------------------------------------------------

## 🧠 Arxitektura

Bu loyiha **Service based architecture**:

-   DbContext → connection
-   Service → CRUD logic
-   Program.cs → UI/menu

Clean va sodda structure.

------------------------------------------------------------------------

## 🔥 Keyingi upgrade qilish mumkin

Agar projectni professional darajaga olib chiqmoqchi bo'lsang:

-   Repository pattern
-   Unit of Work
-   Dependency Injection
-   Logging (Serilog)
-   Web API versiya
-   Clean Architecture
-   Minimal API

------------------------------------------------------------------------

## 👨‍💻 Author

Jamshidbek (Backend Developer)

.NET + Laravel backend developer uchun practice loyiha.
