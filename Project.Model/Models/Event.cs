
namespace Project.Model.Models
{
  public class Event : BaseEntity
  {
    public string  Title       { get; set; }
    public bool    Complete    { get; set; }
    public virtual string UserID { get; set; }
  }
}
