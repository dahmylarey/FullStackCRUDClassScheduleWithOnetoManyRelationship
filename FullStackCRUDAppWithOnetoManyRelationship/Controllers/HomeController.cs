using FullStackCRUDAppWithOnetoManyRelationship.Models.DataLayer;
using FullStackCRUDAppWithOnetoManyRelationship.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace FullStackCRUDAppWithOnetoManyRelationship.Controllers
{
    public class HomeController : Controller
    {
        //initialize the Repositories (classes)
        private Repository<Class> classes { get; set; }
        private Repository<Day> days { get; set; }



        public HomeController(ScheduleDBContext context)
        {
            //initialize the repositories with the given classes in the context
            classes = new Repository<Class>(context);
            days = new Repository<Day>(context);
        }

        public IActionResult Index(int id)
        {
            var dayOptions = new QueryOptions<Day>
            {
                OrderBy = d => d.DayId == id
            };

            var classOptions = new QueryOptions<Class>
            {
                Includes = "Teacher, Day"

            };

            if (id == 0)
            {
                classOptions.OrderBy = c => c.DayId;
                classOptions.ThenOrderBy = c => c.MilitaryTime;
            }
            else
            {
                classOptions.Where = c => c.DayId == id;
                classOptions.OrderBy = c => c.MilitaryTime;
            }

            //execute the query
            var dayList = days.List(dayOptions);
            var classList = classes.List(classOptions);


            //send data to the view
            ViewBag.Id = id;
            ViewBag.Days = dayList;

            return View(classList);
        }




    }
}
