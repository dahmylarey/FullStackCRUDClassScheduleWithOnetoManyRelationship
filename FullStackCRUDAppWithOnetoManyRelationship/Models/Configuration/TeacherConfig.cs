using FullStackCRUDAppWithOnetoManyRelationship.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace FullStackCRUDAppWithOnetoManyRelationship.Models.Configuration
{
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Teacher> entity)
        {
            entity.HasData(
                new Teacher { TeacherId = 1, FirstName = "John", LastName = "Doe" },
                new Teacher { TeacherId = 2, FirstName = "Jane", LastName = "Smith" },
                new Teacher { TeacherId = 3, FirstName = "Bob", LastName = "Johnson" },
                new Teacher { TeacherId = 4, FirstName = "Alice", LastName = "Williams" }
            );
        }
    }
}
