using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW8.Controllers
{
    public class HomeController : Controller
    {
        private ArtInfoContext db = new ArtInfoContext();
        
        public ActionResult Index()
        {
            List<Genre> genres = db.Genres.ToList();
            return View(genres);
        }

        /*
        [HttpPost]
        public JsonResult Genres(string genre)
        {
            List<ArtWork> artworks = new List<ArtWork>();
            artworks = db.ArtWorks.ToList();
            return Json(artworks, JsonRequestBehavior.AllowGet);
        }
        */

        public JsonResult Genre(int id)
        {
            var artworks = db.Genres.Find(id)
                .Classifications
                .ToList()
                .OrderBy(x => x.ArtWork.Title)
                .Select(a => new { aw = a.ArtworkID, awa = a.ArtWork.ArtistID })
                .ToList();
            string[] artworkCreator = new string[artworks.Count()];
            for (int i = 0; i < artworkCreator.Length; ++i)
            {
                artworkCreator[i] = $"<ul>{db.ArtWorks.Find(artworks[i].aw).Title} by {db.Artists.Find(artworks[i].awa).Name}</ul>";
            }

            var data = new { arr = artworkCreator };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        

    }
}