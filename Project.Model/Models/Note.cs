namespace Project.Model.Models
{
  public class Note : BaseEntity
  {
    public string Header         { get; set; }
    public virtual string UserId { get; set; }
    public string Text           { get; set; }
    public string Colour         { get; set; }
    public int Height            { get; set; }
    public int Width             { get; set; }
    public int Left              { get; set; }
    public int Top               { get; set; }

  }
}
