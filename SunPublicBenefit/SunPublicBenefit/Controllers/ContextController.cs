using SunPublicBenefit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SunPublicBenefit.Controllers
{
    public class ContextController : Controller
    {
        // GET: Context
        public SunShineContainer sun = new SunShineContainer();
    }
}