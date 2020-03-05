using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveCoding.Core
{
  public class Pupil
  {
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birhtdate { get; set; }

    public School School { get; set; }

    [NotMapped]
    public int Age => (int)DateTime.Now.Subtract(Birhtdate).TotalDays / 365;

    public override string ToString() => $"{FirstName} {LastName} {Age}";
  }
}
