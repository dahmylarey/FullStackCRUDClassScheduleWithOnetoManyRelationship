using System.ComponentModel.DataAnnotations;

namespace FullStackCRUDAppWithOnetoManyRelationship.Models.DomainModels
{
    public class Teacher
    {
        public Teacher() => new HashSet<Teacher>();//constructor for initialized collection
        public int TeacherId { get; set; } //primary key

        [Display(Name = "First Name")]
        [StringLength(100, ErrorMessage = "First Name may not exceed 100 characters")]
        [Required(ErrorMessage = "Enter a first name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "Last Name may not exceed 100 characters")]
        [Required(ErrorMessage = "Last Name may not exceed 100 characters")]
        public string LastName { get; set; }

        //readonly string Properties;
        public string FullName => $"{FirstName} {LastName}";


        public ICollection<Class> Classes { get; set; }
    }
}

