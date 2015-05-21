using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using RoseMakerSpace.Models;


namespace RoseMakerSpace.Controllers
{
    public class ExtFunctions
    {
        public static bool checkStudent()
        {
            MakerLabDBDataContext db = new MakerLabDBDataContext();
            try
            {
                var user = HttpContext.Current.User;
                if (user.Identity.Name == "")
                {
                    return false;
                }
                if (System.Web.HttpContext.Current.Session["Student"] != null)
                {
                    if (System.Web.HttpContext.Current.Session["Student"] != null && (bool)System.Web.HttpContext.Current.Session["Student"])
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    var stu = db.get_Student_ByEmail(user.Identity.Name);
                    if (stu != null)
                    {
                        System.Web.HttpContext.Current.Session["Student"] = true;
                        System.Web.HttpContext.Current.Session["User"] = stu;
                        return true;
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Session["Student"] = false;
                        System.Web.HttpContext.Current.Session["User"] = null;
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        internal static bool worksOnProject(int? id)
        {
            if (id.HasValue)
            {
                var user = HttpContext.Current.User;
                MakerLabDBDataContext db = new MakerLabDBDataContext();
                var stu = db.get_Student_ByEmail(user.Identity.Name).FirstOrDefault();
                var projects = db.get_Students_projects(stu.StudentID);
                if (projects.Any(m=>m.ID==id))
                {
                    return true;
                }
                return false;

            }
            return false;
        }
    }
}