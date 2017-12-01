using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW8.Controllers;

namespace HW8.Views
{
    public class ClassificationsController : Controller
    {
        private ArtInfoContext db = new ArtInfoContext();

        // GET: Classifications
        public ActionResult Index()
        {
            var classifications = db.Classifications.Include(c => c.ArtWork).Include(c => c.Genre);
            return View(classifications.ToList());
        }
        
    }
}
