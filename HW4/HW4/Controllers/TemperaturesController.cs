using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW4.Controllers
{
    public class TemperaturesController : Controller
    {
        // GET: Temperatures
        public ActionResult Conversion()
        {
            return View();
        }
    }
}