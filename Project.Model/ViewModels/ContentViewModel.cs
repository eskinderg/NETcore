using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Project.Model.Models;

namespace Project.Model.ViewModels
{
    //[DataContract]
    public class ContentViewModel : IValidatableObject
    {
        //[DataMember]
        public int Id          { get; set; }

        //[DataMember]
        public string Title    { get; set; }

        //[DataMember]
        public string Summary  { get; set; }

        //[DataMember]
        public int XmlConfigId { get; set; }

        //[DataMember]
        public int? FolderId   { get; set; }

        //[DataMember]
        public string Html     { get; set; }

        //[DataMember]
        public Folder Folder   { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Summary))
            {
                yield return new ValidationResult("Title or Summary cannot be emmpty ");
            }
            else if(FolderId == null)
                yield return new ValidationResult("Folder Id cannont be empty");
        }

    }
}
