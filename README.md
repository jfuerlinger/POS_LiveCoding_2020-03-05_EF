# LiveCoding (2020-03-03): Entity Framework Core

## Project structure

* Class library (core)
   1. `LiveCoding.Core`
   2. `LiveCoding.Persistence`
* Console app (core)
   1. `LiveCoding.UI`

## Cheat Sheet

### NuGet Packages

| Paket                                   | Core | Persistence | UI |
|:----------------------------------------|:----:|:-----------:|:--:|
| Microsoft.EntityFrameworkCore           |  -   |     Ja      | Ja |
| Microsoft.EntityFrameworkCore.Tools     |  -   |     Ja      | -  |
| Microsoft.EntityFrameworkCore.SqlServer |  -   |     Ja      | Ja |
| Microsoft.Extensions.Configuration.Json |  -   |     Ja      | Ja |

### Connection String (SQL Server)

```json
{ 
    "ConnectionStrings": 
    { 
    "DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LiveCoding_2020035;Integrated Security=True;" 
    }
}
```

### ApplicationDbContext.OnConfiguring

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = configuration["ConnectionStrings:DefaultConnection"];

        optionsBuilder.UseSqlServer(connectionString);
    }
}
```

### DbContext Options for testing 

```csharp
private ApplicationDbContext GetDbContext(string dbName)
{
    // Build the ApplicationDbContext 
    //  - with InMemory-DB
    return new ApplicationDbContext(
        new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(dbName)
            .EnableSensitiveDataLogging()
            .Options);
}
```

### DbContext constructor for testing

```csharp
public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
{   
}
```
