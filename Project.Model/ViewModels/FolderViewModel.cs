using Project.Model.Models;
using System.Collections.Generic;
//using System.Runtime.Serialization;

namespace Project.Model.ViewModels
{
  //[DataContract]
  public class FolderViewModel
  {
    //[DataMember]
    public int Id                               { get; set; }

    //[DataMember]
    public string Name                          { get; set; }

    //[DataMember]
    public int? ParentId                        { get; set; }

    //[DataMember]
    public virtual Folder Parent                { get; set; }

    //[DataMember]
    public virtual ICollection<Folder> Children { get; set; }
  }
}
