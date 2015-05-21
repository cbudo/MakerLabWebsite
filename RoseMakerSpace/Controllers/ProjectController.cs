using RoseMakerSpace.Models;
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
                var student = db.get_Student_ByEmail(User.Identity.Name).FirstOrDefault();
                var Student_Projects = db.get_Students_projects(student.StudentID);
                var projects = db.get_Active_projects();
                var model = new ProjectIndexModel() { Projects = projects, CurrentStudentProjects = Student_Projects.ToList() };
                return View(model);
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
            db.new_project(project.Name, project.Description, project.Image_Gallery, DateTime.Now, DateTime.Now, 1);
            db.SubmitChanges();
            var projects = db.get_Active_projects();
            return View("Index", projects);
        }
        public ActionResult Details(int id)
        {
            var projectDetails = db.get_Project_details(id).FirstOrDefault();
            return View(projectDetails);

        }
        [Authorize]
        public ActionResult EditProject(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index", "Home");
            if (ExtFunctions.checkStudent())
            {
                // check if student is in the set of students returned by query
                if (!ExtFunctions.worksOnProject(id))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            var projectModel = db.get_Project_details(id).First();
            var extRecs = db.get_Project_Ext_Resources(id);
            var ML_Parts = db.get_Project_MLParts(id);
            var ML_Tools = db.get_Project_MLTools(id);
            List<SelectListItem> selectListRecs = new List<SelectListItem>();
            List<SelectListItem> selectListActiveRecs = new List<SelectListItem>();
            List<SelectListItem> selectListParts = new List<SelectListItem>();
            List<SelectListItem> selectListActiveParts = new List<SelectListItem>();
            List<SelectListItem> selectListTools = new List<SelectListItem>();
            List<SelectListItem> selectListActiveTools = new List<SelectListItem>();

            foreach (var extRec in extRecs)
            {
                if (extRec.FLAG == 0)
                {
                    selectListRecs.Add(new SelectListItem() { Text = extRec.Name, Value = extRec.ID.ToString(), Selected = false });
                }
                else
                {
                    selectListActiveRecs.Add(new SelectListItem() { Text = extRec.Name, Value = extRec.ID.ToString(), Selected = false });
                }
            }

            foreach (var MLPart in ML_Parts)
            {
                if (MLPart.FLAG == 0)
                {
                    selectListParts.Add(new SelectListItem() { Text = MLPart.Name, Value = MLPart.ID.ToString(), Selected = false });
                }
                else
                {
                    selectListActiveParts.Add(new SelectListItem() { Text = MLPart.Name, Value = MLPart.ID.ToString(), Selected = false });
                }
            }

            foreach (var MLTool in ML_Tools)
            {
                if (MLTool.FLAG == 0)
                {
                    selectListTools.Add(new SelectListItem() { Text = MLTool.Name, Value = MLTool.ID.ToString(), Selected = false });
                }
                else
                {
                    selectListActiveTools.Add(new SelectListItem() { Text = MLTool.Name, Value = MLTool.ID.ToString(), Selected = false });
                }
            }

            var projectRecs = new Models.ProjectExtRec() { };
            var model = new Models.ProjectModel() { projectID = projectModel.ID, project = projectModel, Project_MLParts = new ProjectMLParts() { CurrentMLParts = selectListActiveParts, MLParts = selectListParts }, Project_MLTools = new ProjectMakerLabTools() { CurrentMLTools = selectListActiveTools, MLTools = selectListTools }, projectRels = new ProjectExtRec() { ExtResources = selectListRecs, CurrentExtResources = selectListActiveRecs } };
            return View(model);
        }
        [HttpPost]
        public ActionResult EditProject(ProjectModel model, string btnSubmit)
        {
            if (ExtFunctions.checkStudent())
            {
                // check if student is in the set of students returned by query
                if (!ExtFunctions.worksOnProject(model.projectID))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            // call update project SPROC
            db.update_Project(model.projectID, model.project.Name, model.project.Description, model.project.Image_Gallery, model.project.DateAdded, DateTime.Now, model.project.Active);
            // return to project's profile page
            return RedirectToAction("EditProject");
        }
        [HttpPost]
        public ActionResult ProjectParts(ProjectModel model, string btnSubmit)
        {
            if (ExtFunctions.checkStudent())
            {
                // check if student is in the set of students returned by query
                if (!ExtFunctions.worksOnProject(model.projectID))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            switch (btnSubmit)
            {
                case "Add  MLPart >>":
                    // rearrange lists and return to edit project page
                    try
                    {
                        foreach (var skill in model.Project_MLParts.selectedMLParts)
                        {
                            db.AddProject_ML_Part(model.projectID, Convert.ToInt32(skill));
                        }
                    }
                    catch
                    {
                        ModelState.AddModelError("Add Error", "You must select a MakerLab Part to be added");
                    }
                    return RedirectToAction("EditProject");
                case "<< Remove ML Part":
                    // rearrange lists and return to edit project page
                    try
                    {
                        foreach (var skill in model.Project_MLParts.selectedMLPartsToRemove)
                        {
                            db.removeProject_ML_PART(model.projectID, Convert.ToInt32(skill));
                        }
                    }
                    catch
                    {
                        ModelState.AddModelError("Remove Error", "You must select a MakerLab Part to be Removed");
                    }
                    return RedirectToAction("EditProject");
                case "Add  ML Tool >>":
                    // rearrange lists and return to edit project page
                    try
                    {
                        foreach (var skill in model.Project_MLParts.selectedMLParts)
                        {
                            db.AddProject_ML_TOOL(model.projectID, Convert.ToInt32(skill));
                        }
                    }
                    catch
                    {
                        ModelState.AddModelError("Add Error", "You must select a MakerLab Tool to be added");
                    }
                    return RedirectToAction("EditProject");
                case "<< Remove ML Tool":
                    // rearrange lists and return to edit project page
                    try
                    {
                        foreach (var skill in model.Project_MLParts.selectedMLPartsToRemove)
                        {
                            db.removeProject_ML_TOOL(model.projectID, Convert.ToInt32(skill));
                        }
                    }
                    catch
                    {
                        ModelState.AddModelError("Remove Error", "You must select a MakerLab Tool to be Removed");
                    }
                    return RedirectToAction("EditProject");
                case "Add Resource >>":
                    // rearrange lists and return to edit project page
                    try
                    {
                        foreach (var skill in model.Project_MLParts.selectedMLParts)
                        {
                            db.AddProject_ExtResource(model.projectID, Convert.ToInt32(skill));
                        }
                    }
                    catch
                    {
                        ModelState.AddModelError("Add Error", "You must select an extRec to be added");
                    }
                    return RedirectToAction("EditProject");
                case "<< Remove Resource":
                    // rearrange lists and return to edit project page
                    try
                    {
                        foreach (var skill in model.Project_MLParts.selectedMLPartsToRemove)
                        {
                            db.remove_Project_extResource(model.projectID, Convert.ToInt32(skill));
                        }
                    }
                    catch
                    {
                        ModelState.AddModelError("Remove Error", "You must select an extRec to be Removed");
                    }
                    return RedirectToAction("EditProject");
                default:
                    break;
            }
            return RedirectToAction("EditProject");
        }
        public ActionResult AddRemStudents(int? ProjectID)
        {
            if (ProjectID.HasValue)
            {
                if (ExtFunctions.checkStudent())
                {
                    // check if student is in the set of students returned by query
                    if (!ExtFunctions.worksOnProject(ProjectID))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                var projectStudents = db.get_Students_WorkingON_projects(ProjectID);
                var model = new Models.AddStudentModel() { studentsOnProject = projectStudents, projectID = (int)ProjectID };
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult RemStudent(int studentId, int projectID)
        {
            if (ExtFunctions.checkStudent())
            {
                // check if student is in the set of students returned by query
                if (!ExtFunctions.worksOnProject(projectID))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            db.delete_Student_from_Project(studentId, projectID);
            return RedirectToAction("AddRemStudents", new { ProjectID = projectID });
        }
        public ActionResult AddStudent(AddStudentModel model)
        {
            if (ExtFunctions.checkStudent())
            {
                // check if student is in the set of students returned by query
                if (!ExtFunctions.worksOnProject(model.projectID))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            try
            {
                var student = db.get_Student_ByEmail(model.StudentName).FirstOrDefault();

                db.add_Student_to_Project(student.StudentID, model.projectID);
                return RedirectToAction("AddRemStudents", new { ProjectID = model.projectID });
            }
            catch
            {
                return RedirectToAction("AddRemStudents", new { ProjectID = model.projectID });
            }
        }
    }
}