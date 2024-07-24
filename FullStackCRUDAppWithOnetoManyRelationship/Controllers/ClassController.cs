using FullStackCRUDAppWithOnetoManyRelationship.Models.DataLayer;
using FullStackCRUDAppWithOnetoManyRelationship.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace FullStackCRUDAppWithOnetoManyRelationship.Controllers
{
    public class ClassController : Controller
    {
        //initialize class Repository
        private Repository<Class> Classes { get; set; }
        private Repository<Teacher> teachers { get; set; }
        private Repository<Day> days { get; set; }

        public ClassController(ScheduleDBContext ctx)
        {
            //initialize class Db-context constructor
            Classes = new Repository<Class>(ctx);
            teachers = new Repository<Teacher>(ctx);
            days = new Repository<Day>(ctx);
        }

        //Home redirect Route
        public RedirectToActionResult Index() => RedirectToAction("Index", "Home");

        [HttpGet]
        public ViewResult Add()
        {
            this.LoadViewBag("Add");
            return View("AddEdith", new Class());
        }

        //Post/Save into db 
        [HttpPost]
        public IActionResult Add(Class c)
        {
            bool isAdd = c.ClassId == 0;

            if (ModelState.IsValid)
            {
                //insert in class c
                if (isAdd)
                    Classes.Insert(c);
                else Classes.Update(c);
            }
            else
            {
                //if not valid
                string operation = (isAdd) ? "add" : "Edith";
                this.LoadViewBag(operation);
                return View("AddEdith", c);
            }

            return View();
        }

        //Edit Class

        [HttpGet]
        public ViewResult Edit(int id)
        {
            this.LoadViewBag("Edith");
            var c = this.GetClass(id);
            return View("AddEdith", c);
        }


        //Delete a Class
        [HttpGet]
        public ViewResult Delete(int id)
        {
            var c = this.GetClass(id);
            return View(c);

        }


        //helper method
        private Class GetClass(int id)
        {
            var classOptions = new QueryOptions<Class>
            {
                Includes = "Teacher, Day"
            };
            return Classes.Get(classOptions) ?? new Class();
        }


        private void LoadViewBag(string operation)
        {
            ViewBag.Days = days.List(new QueryOptions<Day>
            {
                OrderBy = d => d.DayId,

            });
            ViewBag.Teachers = teachers.List(new QueryOptions<Teacher>
            {
                OrderBy = t => t.LastName
            });
            ViewBag.Operation = operation;
        }

    }
}
