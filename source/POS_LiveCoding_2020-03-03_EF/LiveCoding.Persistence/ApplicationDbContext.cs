using System;
using LiveCoding.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LiveCoding.Persistence
{
  public class ApplicationDbContext : DbContext
  {
    #region Properties 
    public DbSet<Pupil> Pupils { get; set; }

    public DbSet<City> Cities { get; set; }
    #endregion

    public ApplicationDbContext()
    {
      
    }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
      : base(options)
    {
      
    }

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
  }
}
