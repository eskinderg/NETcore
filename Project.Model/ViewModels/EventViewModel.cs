/* using Project.Model.Models; */
/* using System.Collections.Generic; */
//using System.Runtime.Serialization;

using System;

namespace Project.Model.ViewModels
{
  public class EventViewModel
  {
    public Guid   Id       { get; set; }
    public string Title    { get; set; }
    public bool   Complete { get; set; }

  }
}
