using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoseMakerSpace.Controllers
{
    public class StudentController : Controller
    {
        MakerLabDBDataContext db = new MakerLabDBDataContext();
        // GET: Student
        public ActionResult Index()
        {
            var students = db.Get_current_students();
            return View(students);
        }
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student model)
        {
            return RedirectToAction("Index");
        }
    }
}