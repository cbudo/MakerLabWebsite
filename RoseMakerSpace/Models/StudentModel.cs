using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoseMakerSpace.Models
{
    public class StudentModel
    {
        public SkillModel skills { get; set; }
        public get_Student_ByEmailResult student { get; set; }
        public int StudentID { get; set; }
    }
    public class SkillModel
    {
        public IEnumerable<string> selectedSkills { get; set; }
        public IEnumerable<SelectListItem> Skills { get; set; }
        public IEnumerable<string> selectedSkillsToRemove { get; set; }
        public IEnumerable<SelectListItem> CurrentSkills { get; set; }
    }
    public class CreateStudentModel
    {
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Class Year")]
        public short ClassYear { get; set; }

        [Display(Name = "Student ID Number")]
        public int IDno { get; set; }
    }
}