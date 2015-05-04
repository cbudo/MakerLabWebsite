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
            MakerLabDBDataContext db = new MakerLabDBDataContext();
            var projects = db.Projects.Where(p => p.STATUS == 1);
            return View(projects);
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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public void Create(Project project)
        {
            MakerLabDBDataContext db = new MakerLabDBDataContext();
            project.DateAdded = DateTime.Now.Date;
            project.STATUS = 1;
            project.LastModified = DateTime.Now;
            db.Projects.InsertOnSubmit(project);
            db.SubmitChanges();
        }
    }
}