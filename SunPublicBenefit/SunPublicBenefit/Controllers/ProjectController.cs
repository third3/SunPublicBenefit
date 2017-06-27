using SunPublicBenefit.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SunPublicBenefit.Controllers
{
    public class ProjectController : ContextController
    {
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SingleProject()
        {
            return View();
        }
        public ActionResult UnBeneficenceProject()
        {
            return View();
        }
        public ActionResult BeneficenceProject()
        {
            return View();
        }
        public ActionResult PublicfiguresProject()
        {
            return View();
        }


    }
}