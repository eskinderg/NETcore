using System;
using System.Collections.Generic;

namespace Project.Model.Models
{
  public class Folder : BaseEntity
  {
    public string  Name                         { get; set; }
    public Guid    ParentId                     { get; set; }
    public virtual Folder Parent                { get; set; }
    public virtual ICollection<Folder> Children { get; set; }
  }
}
