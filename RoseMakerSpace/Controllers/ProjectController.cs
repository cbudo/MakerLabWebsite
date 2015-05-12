using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoseMakerSpace.Controllers
{
    public class ProjectController : Controller
    {
        MakerLabDBDataContext db = new MakerLabDBDataContext();
        // GET: Project
        [Authorize]
        public ActionResult Index()
        {
            if (ExtFunctions.checkStudent())
            {
                var projects = db.get_Active_projects();
                return View(projects);
            }
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult Create()
        {
            if (ExtFunctions.checkStudent())
                return View();
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(Project project)
        {
            project.DateAdded = DateTime.Now.Date;

            project.LastModified = DateTime.Now;
            db.new_project(project.Name, project.Description, project.Image_Gallery, project.DateAdded, project.LastModified, 1);
            db.SubmitChanges();
            var projects = db.get_Active_projects();
            return View("Index", projects);
        }
        public ActionResult Details(int id)
        {
            var projectDetails = db.Projects.Where(p => p.ID == id).First();
            return View(projectDetails);
        }
    }
}