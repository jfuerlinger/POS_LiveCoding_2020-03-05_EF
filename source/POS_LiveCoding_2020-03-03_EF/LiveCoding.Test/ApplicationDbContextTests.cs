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
    public void SaveAsync_WithPupils_ShouldReturnTheSamePupilsOnFetch()
    {
      string dbName = Guid.NewGuid().ToString();

      using (ApplicationDbContext ctxSave = GetDbContext(dbName))
      {
        Pupil p1 = new Pupil(){FirstName = "Susi", LastName = "Mustermann", Age=16};
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
  }
}
