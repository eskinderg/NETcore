using Project.Model.Models;
using System.Collections.Generic;

namespace Project.Model.ViewModels
{
  public class FolderViewModel
  {
    public int Id                               { get; set; }

    public string Name                          { get; set; }

    public int? ParentId                        { get; set; }

    public virtual Folder Parent                { get; set; }

    public virtual ICollection<Folder> Children { get; set; }
  }
}
