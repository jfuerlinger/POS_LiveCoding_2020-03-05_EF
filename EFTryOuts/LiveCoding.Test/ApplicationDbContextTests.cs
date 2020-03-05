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
    public void SaveChanges_AddOnePupil_ShouldBeTheSameOnRetrieal()
    {
      string dbName = Guid.NewGuid().ToString();

      // Arrange
      using (ApplicationDbContext ctx = GetDbContext(dbName))
      {

        Pupil p1 = new Pupil()
        {
          FirstName = "Oscar",
          LastName = "Yim",
          Birhtdate = new DateTime(1997, 06, 24),
        };

        ctx.Pupils.Add(p1);
        // Act
        ctx.SaveChanges();
      }

      using (ApplicationDbContext ctx = GetDbContext(dbName))
      {
        // Assert
        Pupil actual = ctx.Pupils.Single();

        Assert.IsNotNull(actual);
        Assert.AreEqual("Oscar", actual.FirstName);
      }
    }
  }
}
