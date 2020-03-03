using System.Collections.Generic;

namespace LiveCoding.Core
{
  public class City
  {
    public int Id { get; set; }
    public int ZipCode { get; set; }
    public string Name { get; set; }

    public IList<Pupil> Pupils { get; set; }

    public override string ToString() => $"{ZipCode} {Name}";
  }
}




