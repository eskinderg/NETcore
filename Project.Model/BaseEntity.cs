using System.ComponentModel.DataAnnotations;

namespace Project.Model
{
  public abstract class BaseEntity
  {
    [Key]
    public int Id { get; set; }
  }
}
