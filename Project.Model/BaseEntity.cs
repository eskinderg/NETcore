using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Model
{
  public abstract class BaseEntity : IBaseEntity
  {
    [Key]
    public Guid Id { get; set; }
  }
}
