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
        public ActionResult Index()
        {
            var projects = db.get_Active_projects();
            return View(projects);
        }
        public ActionResult Project(int? ProjectKey)
        {
            if(ProjectKey.HasValue)
            {
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
        public ActionResult Create(Project project)
        {
            project.DateAdded = DateTime.Now.Date;
            
            project.LastModified = DateTime.Now;
            db.new_project(project.Name, project.Description, project.Image_Gallery, project.DateAdded, project.LastModified, 1);
            db.SubmitChanges();
            var projects = db.get_Active_projects();
            return View("Index",projects);
        }
        public ActionResult Details(int id)
        {
            var projectDetails = db.Projects.Where(p => p.ID == id).First();
            return View(projectDetails);
        }
    }
}