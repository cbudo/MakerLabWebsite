using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoseMakerSpace.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Project(int? ProjectKey)
        {
            if(ProjectKey.HasValue)
            {
                MakerLabDBDataContext db = new MakerLabDBDataContext();
                var project = db.Projects.Where(c => c.ID == ProjectKey);
                project.Cast<Models.ProjectModel>().ToList();
                return View("Project", project.First());
            }
            return View("Index");
        }
        public ActionResult Browse()
        {
            return View();
        }
    }
}