using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace FullStackCRUDAppWithOnetoManyRelationship.Models.DomainModels
{
    public class Class
    {
        public int ClassId { get; set; }

        [StringLength(200, ErrorMessage = "Title Name may not exceed 100 characters.")]
        [Required(ErrorMessage = "Enter a Class Title.")]
        public string Title { get; set; } = string.Empty;


        [Range(200, 500, ErrorMessage = "Class Number must be between 100 and 500 characters.")]
        [Required(ErrorMessage = "Enter a Class Number.")]
        public int? Number { get; set; }

        [Display(Name = "Time")]
        [RegularExpression("^ [0-9]*$", ErrorMessage = "Please enter number only for class time")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "class time must be 4 Characters long.")]
        [Required(ErrorMessage = "Please enter Class Time (in military time format).")]
        public string MilitaryTime { get; set; } = string.Empty;


        public int TeacherId { get; set; } //foreign key properties
        [ValidateNever]
        public Teacher Teacher { get; set; } //navigation property
        public int DayId { get; set; }//foreign key properties
        [ValidateNever]
        public Day Day { get; set; } = null;//navigation property
    }
}
