using FullStackCRUDAppWithOnetoManyRelationship.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FullStackCRUDAppWithOnetoManyRelationship.Models.Configuration
{
    public class ClassConfig : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> entity)
        {
            entity.HasOne(c => c.Teacher)
                .WithMany(t => t.Classes)
                .OnDelete(DeleteBehavior.Restrict);//cant delete if teacher has classes

            //Teacher class
            entity.HasOne(c => c.Day)
                            .WithMany(d => d.Classes)
                            .OnDelete(DeleteBehavior.Restrict);//cant delete if day has classes


            // classes
            entity.HasData(
                new Class { ClassId = 1, Title = "Intro to C#", Number = 100, TeacherId = 1, DayId = 1, MilitaryTime = "0600" },
                new Class { ClassId = 2, Title = "Intro to Java Script", Number = 101, TeacherId = 2, DayId = 2, MilitaryTime = "0600" },
                new Class { ClassId = 3, Title = "Intro to Python", Number = 102, TeacherId = 3, DayId = 3, MilitaryTime = "0600" },
                new Class { ClassId = 4, Title = "Intro to Ruby", Number = 103, TeacherId = 4, DayId = 4, MilitaryTime = "0600" },
                new Class { ClassId = 5, Title = "Intro to Networking", Number = 104, TeacherId = 5, DayId = 5, MilitaryTime = "0600" },
                new Class { ClassId = 6, Title = "Intro to Hardware", Number = 105, TeacherId = 6, DayId = 6, MilitaryTime = "0600" },
                new Class { ClassId = 7, Title = "Intro to .Net MVC", Number = 106, TeacherId = 7, DayId = 7, MilitaryTime = "0600" }

                );

        }
    }
}
