using System;

namespace Project.Model.Models
{
  public class Note : BaseEntity
  {
    public string     Header        { get; set; }
    public virtual    Guid   UserId { get; set; }
    public string     Text          { get; set; }
    public string     Colour        { get; set; }
    public int        Height        { get; set; }
    public int        Width         { get; set; }
    public int        Left          { get; set; }
    public int        Top           { get; set; }
    public string     Selection     { get; set; }
    public bool?      Archived      { get; set; }
    public bool?      Active        { get; set; }
    public bool?      SpellCheck    { get; set; }
    public DateTime?  PinOrder      { get; set; }
    public DateTime   DateCreated   { get; set; }
    public  DateTime  DateModified  { get;  set; }
    public DateTime?  DateArchived  { get;  set; }

  }
}
