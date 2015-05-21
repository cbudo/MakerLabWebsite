using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoseMakerSpace.Models
{
    public class ProjectIndexModel
    {
        public List<get_Students_projectsResult> CurrentStudentProjects { get; set; }
        public IEnumerable<get_Active_projectsResult> Projects { get; set; }
    }
    public class ProjectModel
    {
        public int projectID { get; set; }
        public get_Project_detailsResult project { get; set; }
        public ProjectExtRec projectRels { get; set; }
        public ProjectMLParts Project_MLParts { get; set; }
        public ProjectMakerLabTools Project_MLTools { get; set; }
    }
    public class ProjectExtRec
    {
        public IEnumerable<string> selectedExtResources { get; set; }
        public IEnumerable<SelectListItem> ExtResources { get; set; }
        public IEnumerable<string> selectedExtResourcesToRemove { get; set; }
        public IEnumerable<SelectListItem> CurrentExtResources { get; set; }
    }
    public class ProjectMakerLabTools
    {
        public IEnumerable<string> selectedMLTools { get; set; }
        public IEnumerable<SelectListItem> MLTools { get; set; }
        public IEnumerable<string> selectedMLToolsToRemove { get; set; }
        public IEnumerable<SelectListItem> CurrentMLTools { get; set; }
    }
    public class ProjectMLParts
    {
        public IEnumerable<string> selectedMLParts { get; set; }
        public IEnumerable<SelectListItem> MLParts { get; set; }
        public IEnumerable<string> selectedMLPartsToRemove { get; set; }
        public IEnumerable<SelectListItem> CurrentMLParts { get; set; }
    }
    public class ExtRecs
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public short FLAG { get; set; }
    }
    public class AddStudentModel
    {
        public int projectID { get; set; }
        public string StudentName { get; set; }
        public IEnumerable<get_Students_WorkingON_projectsResult> studentsOnProject { get; set; }
    }
}