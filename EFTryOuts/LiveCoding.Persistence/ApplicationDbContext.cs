using System;
using LiveCoding.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LiveCoding.Persistence
{
  public class ApplicationDbContext : DbContext
  {
    public DbSet<Pupil> Pupils { get; set; }
    public DbSet<School> Schools { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public ApplicationDbContext()
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
