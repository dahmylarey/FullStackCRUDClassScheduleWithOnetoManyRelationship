using System.ComponentModel.DataAnnotations;

namespace FullStackCRUDAppWithOnetoManyRelationship.Models.DomainModels
{
    public class Day
    {
        //constructor for initialized collection
        public Day() => Classes = new HashSet<Class>();
        public int DayId { get; set; }//primary keys

        [StringLength(10)]
        [Required()]
        public string Name { get; set; } = string.Empty;

        public ICollection<Class> Classes { get; set; } //navigations properties
    }
}
