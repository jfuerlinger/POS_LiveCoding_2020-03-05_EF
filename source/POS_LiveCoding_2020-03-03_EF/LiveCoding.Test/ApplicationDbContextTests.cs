using System;
using System.Linq;
using LiveCoding.Core;
using LiveCoding.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LiveCoding.Test
{
  [TestClass]
  public class ApplicationDbContextTests
  {
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

    [TestMethod]
    public void SaveChanges_WithPupils_ShouldReturnTheSameNumberOfPupilsOnFetch()
    {
      string dbName = Guid.NewGuid().ToString();

      using (ApplicationDbContext ctxSave = GetDbContext(dbName))
      {
        Pupil p1 = new Pupil() { FirstName = "Susi", LastName = "Mustermann", Age = 16 };
        Pupil p2 = new Pupil() { FirstName = "Hansi", LastName = "Mair", Age = 15 };

        ctxSave.Pupils.Add(p1);
        ctxSave.Pupils.Add(p2);
        ctxSave.SaveChanges();
      }

      int cntOfPupils;
      using (ApplicationDbContext ctxFetch = GetDbContext(dbName))
      {
        cntOfPupils = ctxFetch.Pupils.Count();
      }

      Assert.AreEqual(2, cntOfPupils);
    }

    [TestMethod]
    public void SaveChanges_AddCity_ShouldReturnEqualCityAsSaved()
    {
      string dbName = Guid.NewGuid().ToString();

      City marchtrenk = new City() { Name = "Marchtrenk", ZipCode = 4614 };
      using (ApplicationDbContext ctxSave = GetDbContext(dbName))
      {
        ctxSave.Cities.Add(marchtrenk);
        ctxSave.SaveChanges();
      }

      City cityFromDb;
      using (ApplicationDbContext ctxFetch = GetDbContext(dbName))
      {
        cityFromDb = ctxFetch.Cities.Single();
      }

      Assert.IsNotNull(cityFromDb);
      Assert.AreEqual(marchtrenk.Name, cityFromDb.Name);
      Assert.AreEqual(marchtrenk.ZipCode, cityFromDb.ZipCode);
      Assert.AreNotSame(marchtrenk, cityFromDb);
    }
  }
}
