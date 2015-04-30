using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoseMakerSpace.Controllers
{
    public class ResourcesController : Controller
    {
        // GET: Resources
        public ActionResult Index()
        {
            return View("FAQ");
        }
        public ActionResult FAQ()
        {
            return View();
        }
    }
}