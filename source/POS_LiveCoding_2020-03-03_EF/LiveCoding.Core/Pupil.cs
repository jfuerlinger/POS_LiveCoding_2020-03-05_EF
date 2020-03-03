namespace LiveCoding.Core
{
  public class Pupil
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    
    public City Location { get; set; }

    public override string ToString() => $"{Id} {FirstName} {LastName} {Age}";
  }
}
