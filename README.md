# LiveCoding (2020-03-03: Entity Framework Core

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

### Connection String

```json
{ 
    "ConnectionStrings": 
    { 
    "DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LiveCoding_2020035;Integrated Security=True;" 
    }
}
```