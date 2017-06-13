using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SunPublicBenefit.Models;

namespace SunPublicBenefit.Controllers
{
    public class HomeController : ContextController
    {
        SunPublicBenefitDBContextOne db = new SunPublicBenefitDBContextOne();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult PersonalCenter()
        {
            return View();
        }
    }
}