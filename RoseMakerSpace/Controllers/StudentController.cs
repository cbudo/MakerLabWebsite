using RoseMakerSpace.Models;
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
        [Authorize]
        public ActionResult Index()
        {
            if (ExtFunctions.checkStudent())
            {
                var students = db.Get_current_students();
                return View(students);
            }
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        [HttpGet]
        public ActionResult CreateStudentAccount()
        {
            string email;
            if(User.Identity.Name.IndexOf("@rose-hulman.edu")>0)
            {
                 email = User.Identity.Name;
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new CreateStudentModel() { Email = email };
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreateStudentAccount(CreateStudentModel model)
        {
            MakerLabDBDataContext db = new MakerLabDBDataContext();

            db.add_student(model.IDno, model.Email, model.FirstName, model.LastName, model.ClassYear);
            return RedirectToAction("Index","Home");
        }
        //public ActionResult Details(int id)
        //{
        //    if (ExtFunctions.checkStudent())
        //    {
        //        var student = db.Students.Where(m => m.StudentID == id);
        //        return View();
        //    }
        //    return RedirectToAction("Index", "Home");
        //}
        [Authorize]
        [HttpGet]
        public ActionResult EditStudent()
        {
            if (ExtFunctions.checkStudent())
            {
                MakerLabDBDataContext db = new MakerLabDBDataContext();

                var student = db.get_Student_ByEmail(User.Identity.Name).FirstOrDefault();
                var allskills = db.get_user_Skills(student.StudentID);
                List<SelectListItem> selectList = new List<SelectListItem>();
                List<SelectListItem> selectListActiveSkills = new List<SelectListItem>();

                foreach (var skill in allskills)
                {
                    if (skill.FLAG == 0)
                    {
                        selectList.Add(new SelectListItem() { Text = skill.Name, Value = skill.ID.ToString(), Selected = false });
                    }
                    else
                    {
                        selectListActiveSkills.Add(new SelectListItem() { Text = skill.Name, Value = skill.ID.ToString(), Selected = false });
                    }
                }
                var model = new Models.StudentModel() { StudentID = student.StudentID, student = student, skills = new Models.SkillModel() { Skills = selectList, CurrentSkills = selectListActiveSkills } };

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult EditSkill(Models.StudentModel model, string btnSubmit)
        {
            switch (btnSubmit)
            {
                case "Submit":
                    // call update student SPROC
                    db.Update_student(model.StudentID, model.student.StudentID, model.student.Email, model.student.FirstName, model.student.LastName, model.student.ClassYear);
                    // return to student's profile page
                    break;
                case ">>":
                    // rearrange lists and return to edit student page
                    try
                    {
                        foreach (var skill in model.skills.selectedSkills)
                        {
                            db.add_user_Skills(model.StudentID, Convert.ToInt32(skill));
                        }
                    }
                    catch
                    {
                        ModelState.AddModelError("Add Error", "You must select an extRec to be added");
                    }
                    return RedirectToAction("EditStudent");
                case "<<":
                    // rearrange lists and return to edit student page
                    try
                    {
                        foreach (var skill in model.skills.selectedSkillsToRemove)
                        {
                            db.remove_user_Skills(model.StudentID, Convert.ToInt32(skill));
                        }
                    }
                    catch
                    {
                        ModelState.AddModelError("Remove Error", "You must select an extRec to be Removed");
                    }
                    return RedirectToAction("EditStudent");
                default:
                    break;
            }
            return RedirectToAction("Profile");
        }
        public ActionResult Profile()
        {
            var model = db.get_Student_ByEmail(User.Identity.Name).FirstOrDefault();
            return View(model);
        }
    }
}