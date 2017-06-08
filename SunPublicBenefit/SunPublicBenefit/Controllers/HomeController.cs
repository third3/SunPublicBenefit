using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SunPublicBenefit.Controllers
{
    public class HomeController : ContextController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}