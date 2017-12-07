using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW7.Controllers
{
    public class HomeController : Controller
    {
        private SearchLogDBContext db = new SearchLogDBContext();

        public ActionResult Index()
        {
            string GiphyAPIKey = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyAPIKey"];
            ViewBag.GiphyKey = GiphyAPIKey;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            AddLog(search);
            return View();
        }

        public void AddLog(string search)
        {
            var log = new Search();
            log.SearchPhrase = search;
            log.Timestamp = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Searches.Add(log);
                db.SaveChanges();
            }
        }
        
    }
}