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
        public ActionResult Details(int id)
        {
            if (ExtFunctions.checkStudent())
            {
                var student = db.Students.Where(m => m.StudentID == id);
                return View();
            }
            return RedirectToAction("Index","Home");
        }
        [Authorize]
        [HttpGet]
        public ActionResult AddSkill()
        {
            if(ExtFunctions.checkStudent())
            {
                var student = (RoseMakerSpace.Student) Session["User"];
                var allskills = db.Skills;
                var studentSkills = db.Student_Skills.Where(m => m.Student_ID == student.StudentID);
                List<SelectListItem> selectList = new List<SelectListItem>();
                foreach(var skill in allskills)
                {
                    bool selected = null != studentSkills.Where(m=>m.Student_Skill1==skill.ID).FirstOrDefault();
                    selectList.Add(new SelectListItem() { Text = skill.Name, Value = skill.ID.ToString(), Selected = selected });
                }
                var model = new Models.SkillModel() { Skills = selectList };

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult AddSkill(IEnumerable<string> selectedSkills)
        {
            return RedirectToAction("Profile");
        }
    }
}