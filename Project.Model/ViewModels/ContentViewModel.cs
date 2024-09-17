using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Project.Model.Models;

namespace Project.Model.ViewModels
{
  public class ContentViewModel : IValidatableObject
  {
    public int    Id          { get; set; }
    public string Title       { get; set; }
    public string Summary     { get; set; }
    public int    XmlConfigId { get; set; }
    public Guid   FolderId    { get; set; }
    public string Html        { get; set; }
    public Folder Folder      { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if (string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Summary))
      {
        yield return new ValidationResult("Title or Summary cannot be empty ");
      }
      else if(FolderId ==  Guid.Empty)
        yield return new ValidationResult("Folder Id cannont be empty");
    }

  }
}
