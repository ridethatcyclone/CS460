using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW8.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            using (ArtInfoContext db = new ArtInfoContext())
            {
                List<Genre> genres = db.Genres.ToList();
                return View(genres);
            }
        }
        
    }
}