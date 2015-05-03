using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoseMakerSpace.Models
{
    public class ProjectModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgGallaryURL { get; set; }
    }
}