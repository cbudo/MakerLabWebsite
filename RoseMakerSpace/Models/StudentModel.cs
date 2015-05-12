using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoseMakerSpace.Models
{
    public class StudentModel
    {
    }
    public class SkillModel
    {
        public IEnumerable<string> selectedSkills { get; set; }
        public IEnumerable<SelectListItem> Skills { get; set; }
        
    }
}