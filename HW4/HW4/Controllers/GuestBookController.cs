using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HW4.Controllers
{
    public class GuestBookController : Controller
    {
        [HttpGet]
        public ActionResult Visitors()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Visitors(FormCollection form)
        {

            foreach (var value in form)
            {
                if (value == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.FirstName = form["FirstName"];
            ViewBag.LastName = form["LastName"];
            ViewBag.Time = DateTime.Now;

            return View();
        }
    }
}