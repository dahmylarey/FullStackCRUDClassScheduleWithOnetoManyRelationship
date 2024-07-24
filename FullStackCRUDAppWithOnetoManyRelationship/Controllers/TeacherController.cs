using FullStackCRUDAppWithOnetoManyRelationship.Models.DataLayer;
using FullStackCRUDAppWithOnetoManyRelationship.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace FullStackCRUDAppWithOnetoManyRelationship.Controllers
{
    public class TeacherController : Controller
    {
        //initialize the repository
        private Repository<Teacher> teachers { get; set; }

        //initialize the db context
        public TeacherController(ScheduleDBContext ctx) => teachers = new Repository<Teacher>(ctx);


        public ViewResult Index()
        {
            var options = new QueryOptions<Teacher>
            {
                OrderBy = t => t.LastName
            };

            return View(teachers.List(options));
        }
    }
}
