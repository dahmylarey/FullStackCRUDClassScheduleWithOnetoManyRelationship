using FullStackCRUDAppWithOnetoManyRelationship.Models.Configuration;
using FullStackCRUDAppWithOnetoManyRelationship.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace FullStackCRUDAppWithOnetoManyRelationship.Models.DataLayer
{
    public class ScheduleDBContext : DbContext
    {
        public ScheduleDBContext(DbContextOptions<ScheduleDBContext> options) : base(options) { }


        public DbSet<Day> Days { get; set; } = null;
        public DbSet<Teacher> Teachers { get; set; } = null;
        public DbSet<Class> Classes { get; set; } = null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seed our Data or Apply Configuration for day
            modelBuilder.ApplyConfiguration(new DayConfig());
            modelBuilder.ApplyConfiguration(new TeacherConfig());
            modelBuilder.ApplyConfiguration(new ClassConfig());
        }
    }
}
