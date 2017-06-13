using SunPublicBenefit.Models;
using System;
using System.Collections.Generic;
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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Project project)
        {
            string msg = "no";
           // sun.ProjectSet.Add(project);
            //int result = sun.SaveChanges();
            //if (result > 1)
            //{
            //    //msg = "ok";
            //    Response.Redirect("Project/Create");
            //}
            return Content(msg);
        }
    }
}