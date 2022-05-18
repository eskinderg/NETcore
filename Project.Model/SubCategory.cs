using Project.Model.Models;
using System.Collections.Generic;

namespace Project.Model
{
  public class SubCategory
  {

    public int Id                                 { get; set; }

    public string Name                            { get; set; }

    public virtual IEnumerable<Category> Category { get; set; }

  }
}
