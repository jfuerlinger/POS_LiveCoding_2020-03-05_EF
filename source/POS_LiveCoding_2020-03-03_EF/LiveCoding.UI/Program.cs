using System;
using System.Net.Mime;
using LiveCoding.Core;
using LiveCoding.Persistence;

namespace LiveCoding.UI
{
  class Program
  {
    static void Main(string[] args)
    {
      InitDb();
      QueryDb();
    }

    private static void QueryDb()
    {
      using (ApplicationDbContext ctx = new ApplicationDbContext())
      {
        Console.WriteLine("Schüler: ");
        foreach (Pupil pupil in ctx.Pupils)
        {
          Console.WriteLine(pupil);
        }
      }
     }

    private static void InitDb()
    {
      using (ApplicationDbContext ctx = new ApplicationDbContext())
      {
        Console.WriteLine("Ensure deleted ...");
        ctx.Database.EnsureDeleted();

        Console.WriteLine("Ensure created ...");
        ctx.Database.EnsureCreated();

        City linz = new City() {Name = "Linz", ZipCode = 4020};
        City wels = new City() {Name = "Wels", ZipCode = 4060};

        Pupil p1 = new Pupil() {FirstName = "Susi", LastName = "Mustermann", Age = 15, Location = wels};
        Pupil p2 = new Pupil() {FirstName = "Franz", LastName = "Prokop", Age = 17, Location = linz};
        Pupil p3 = new Pupil() {FirstName = "Susanne", LastName = "Mair", Age = 16, Location = linz};

        ctx.Pupils.Add(p1);
        ctx.Pupils.Add(p2);
        ctx.Pupils.Add(p3);

        ctx.SaveChanges();
      }
    }
  }
}
