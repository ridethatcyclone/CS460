using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW8.Controllers;

namespace HW8.Views.Home
{
    public class ArtWorksController : Controller
    {
        private ArtInfoContext db = new ArtInfoContext();

        // GET: ArtWorks
        public ActionResult Index()
        {
            var artWorks = db.ArtWorks.Include(a => a.Artist);
            return View(artWorks.ToList());
        }
        
    }
}
