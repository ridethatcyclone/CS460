using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HW6.Controllers
{
    public class HomeController : Controller
    {
        ProductsContext db = new ProductsContext();

        //GET Index
        public ActionResult Index()
        {
            /*
            List<string> Categories = new List<string>();
            for (int i = 1; i <= db.ProductCategories.Count(); i++)
            {
                Categories.Add(db.ProductCategories.Where(p => p.ProductCategoryID == i).Select(p => p.Name).ToString());
            }
            ViewData["Categories"] = new SelectList(Categories);
            */



            /*
            ViewBag.Categories = new string[4];
            for (int i = 0; i < db.ProductCategories.Count(); i++)
            {
                ViewBag.Categories[i] = db.ProductCategories.Select(p => p.Name).ToString();
            }
            */

            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}