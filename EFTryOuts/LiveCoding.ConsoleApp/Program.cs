using System;
using System.Linq;
using System.Net.Mime;
using LiveCoding.Core;
using LiveCoding.Persistence;

namespace LiveCoding.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      CreateDbWithData();
      FetchDataFromDb();
    }

    private static void FetchDataFromDb()
    {
      using (ApplicationDbContext ctx = new ApplicationDbContext())
      {
        var pupils = ctx.Pupils
          //.Where(p => p.FirstName == "Pascal");
          .Where(p => p.Birhtdate == new DateTime(1989, 12, 27));

        foreach (Pupil p in pupils)
        {
          Console.WriteLine(p);
        }
      }
    }

    private static void CreateDbWithData()
    {
      using (ApplicationDbContext ctx = new ApplicationDbContext())
      {
        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();


        School htlLeonding = new School()
        {
          Principal = "Wolfgang Holzer",
          Name = "HTL Leonding",
          Schooltype = Schooltype.Htl,
          City = "Leonding",
          PostalCode = 4060,
          Street = "Limesstraße 12",
        };

        Pupil p1 = new Pupil()
        {
          FirstName = "Oscar",
          LastName = "Yim",
          Birhtdate = new DateTime(1997, 06, 24),
          School = htlLeonding
        };

        ctx.Pupils.Add(p1);
        ctx.Schools.Add(htlLeonding);

        ctx.SaveChanges();
      }
    }
  }
}
