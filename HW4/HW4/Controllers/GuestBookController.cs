using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW4.Controllers
{
    public class GuestBookController : Controller
    {
        // GET: GuestBook
        public ActionResult Visitors()
        {
            return View();
        }
    }
}