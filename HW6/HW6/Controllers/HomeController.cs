using HW6.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HW6.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// Index page
        /// </summary>
        /// <returns>Default index view</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Dynamically generates a table of items based on selections by the user
        /// </summary>
        /// <returns>Redirects to Index if no selections were made, otherwise returns a View using the dbContext</returns>
        public ActionResult Display()
        {
            string DisplaySubcategory = Request.QueryString["PID"];
            if (string.IsNullOrEmpty(DisplaySubcategory))
            {
                return RedirectToAction("Index");
            }

            using (ProductsContext db = new ProductsContext())
            {
                int id = db.ProductSubcategories.Where(p => p.Name.Equals(DisplaySubcategory)).Select(p => p.ProductCategoryID).FirstOrDefault();
                string DisplayCategory = db.ProductCategories.Where(p => p.ProductCategoryID == id).Select(p => p.Name).FirstOrDefault().ToString();
                ViewBag.DisplaySub = DisplaySubcategory; ViewBag.DisplayCat = DisplayCategory;
                int SubcategoryID = db.ProductSubcategories.Where(p => p.Name.Equals(DisplaySubcategory)).Select(p => p.ProductSubcategoryID).FirstOrDefault();

                ViewBag.SubID = SubcategoryID;
                ViewBag.PrimID = id;

                return View(db.Products.ToList());
            }
        }

        /// <summary>
        /// Displays the item selected by the user, along with any reviews
        /// </summary>
        /// <returns>Redirects to index if no selection was made, otherwise returns View using dbContext</returns>
        public ActionResult Item()
        {
            string id = Request.QueryString["product"];
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            using (ProductsContext db = new ProductsContext())
            {
                string itemName = db.Products.Where(p => p.ProductID.ToString().Equals(id)).Select(p => p.Name).FirstOrDefault().ToString();
                ViewBag.ItemName = itemName;
                return View(db.Products.ToList());
            }
        }

        /// <summary>
        /// Partial view to add a dynamic navbar to all pages
        /// </summary>
        /// <returns>A dynamically created navbar in a partial view made using the database</returns>
        [ChildActionOnly]
        public PartialViewResult GetNavbar()
        {
            using (ProductsContext db = new ProductsContext())
            {
                var Cat = new string[db.ProductCategories.Count()];
                for (int i = 1; i <= db.ProductCategories.Count(); i++)
                {
                    var x = db.ProductCategories.Where(p => p.ProductCategoryID == i).Select(p => p.Name).FirstOrDefault().ToString();
                    if (x != null)
                    {
                        Cat[i - 1] = x;
                        IList<string> a = new List<string>();
                        foreach (var item in db.ProductSubcategories)
                        {
                            if (item.ProductCategoryID.Equals(i))
                                a.Add(item.Name);
                        }
                        ViewData[x] = a;

                    }
                }
                ViewBag.Categories = Cat;
                return PartialView("_Navbar");
            }

        }




    }
}