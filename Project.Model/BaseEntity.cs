﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Model
{
  public abstract class BaseEntity
  {
    [Key]
   [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int Id { get; set; }
  }
}
