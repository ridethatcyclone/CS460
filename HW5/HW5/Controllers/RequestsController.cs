using HW5.DAL;
using HW5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW5.Controllers
{
    public class RequestsController : Controller
    {
        private RequestContext db = new RequestContext();
        public ActionResult Index()
        {
            return View(db.Requests.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "FullName,DateOfBirth,CustomerID,StreetAddress,City,State,ZipCode,County")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(request);
        }
    }
}
