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


        //Add Teachers
        [HttpGet]
        public ViewResult Add() => View();

        [HttpPost]
        public IActionResult Add(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teachers.Insert(teacher);
                teachers.save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(teacher);
            }

        }


        //Delete Teacher

        [HttpGet]
        public ViewResult Delete(int id) => View(teachers);

        [HttpPost]
        public RedirectToActionResult Delete(Teacher teacher)
        {

            teachers.Delete(teacher);
            teachers.save();
            return RedirectToAction("Index");

        }

    }
}
