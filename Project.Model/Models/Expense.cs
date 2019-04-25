using Project.Model.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Model
{

    public class Expense : BaseEntity
    {

        [Required]
        [DataType(DataType.Date)]
        public DateTime? Date            { get; set; }

        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string Description        { get; set; }

        public virtual Category Category { get; set; }

        [DataType(DataType.Currency)]
        public float? Amount             { get; set; }

    }
}
