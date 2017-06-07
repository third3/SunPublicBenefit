using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SunPublicBenefit.Models;

namespace SunPublicBenefit.Controllers
{
    public class User1Controller : Controller
    {
        private SunShineContainer db = new SunShineContainer();

        // GET: User1
        public ActionResult Index()
        {
            return View(db.User1Set.ToList());
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
