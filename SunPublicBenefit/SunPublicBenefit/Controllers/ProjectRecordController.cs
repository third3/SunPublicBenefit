using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SunPublicBenefit.Controllers
{
    public class ProjectRecordController : Controller
    {
        // GET: ProjectRecord
        public ActionResult PersonalDonationRecord()
        {
            return View();
        }
    }
}