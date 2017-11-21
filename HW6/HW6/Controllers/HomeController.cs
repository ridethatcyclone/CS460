using HW6.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            //Get subcategory name from query string
            string DisplaySubcategory = Request.QueryString["PID"];

            //Check validity
            if (string.IsNullOrEmpty(DisplaySubcategory))
            {
                return RedirectToAction("Index");
            }

            using (ProductsContext db = new ProductsContext())
            {
                //Getting the Category and Subcategory ID Numbers (as well as the names, for the heading)
                int id = db.ProductSubcategories.Where(p => p.Name.Equals(DisplaySubcategory)).Select(p => p.ProductCategoryID).FirstOrDefault();
                string DisplayCategory = db.ProductCategories.Where(p => p.ProductCategoryID == id).Select(p => p.Name).FirstOrDefault().ToString();
                int SubcategoryID = db.ProductSubcategories.Where(p => p.Name.Equals(DisplaySubcategory)).Select(p => p.ProductSubcategoryID).FirstOrDefault();

                //Names
                ViewBag.DisplaySub = DisplaySubcategory;
                ViewBag.DisplayCat = DisplayCategory;

                //Numbers
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
            //Get id from query string
            string id = Request.QueryString["product"];

            //Make sure the user actually input a request and I didn't just launch from the display page again
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }            

            using (ProductsContext db = new ProductsContext())
            {
                //Getting item Product ID
                int pid = int.Parse(id);
                ViewBag.ItemID = pid;

                //Getting item name
                string itemName = db.Products.Where(p => p.ProductID == pid).Select(p => p.Name).FirstOrDefault().ToString();
                ViewBag.ItemName = itemName;

                //Getting item description
                try {
                    int pmid = (int)db.Products.Where(p => p.ProductID == pid).Select(p => p.ProductModelID).FirstOrDefault();
                    int descid = (int)db.ProductModelProductDescriptionCultures.Where(p => p.ProductModelID == pmid).Select(p => p.ProductDescriptionID).First();
                    string desc = db.ProductDescriptions.Where(p => p.ProductDescriptionID == descid).Select(p => p.Description).FirstOrDefault().ToString();
                    ViewBag.ItemDescription = desc;
                } catch
                {
                    ViewBag.ItemDescription = null;
                }
                
                //Getting item price
                decimal price = db.Products.Where(p => p.ProductID == pid).Select(p => p.ListPrice).FirstOrDefault();
                ViewBag.ItemPrice = price;

                //Getting item color
                try {
                    string color = db.Products.Where(p => p.ProductID == pid).Select(p => p.Color).FirstOrDefault().ToString();
                    ViewBag.ItemColor = color;
                } catch
                {
                    ViewBag.ItemColor = null;
                }
                
                //CHECK IF ITEM HAS REVIEWS
                ViewBag.HasReviews = false;
                foreach (var item in db.ProductReviews)
                {
                    if (item.ProductID == pid)
                    {
                        ViewBag.HasReviews = true;
                        break;
                    }
                }

                return View(db.ProductReviews.ToList());
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
                //Create the categories array
                var Cat = new string[db.ProductCategories.Count()];

                //Loop through and generate the category and its subcategories. Subcategories are added as a list to ViewData.
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

        public ActionResult Create()
        {
            string id = Request.QueryString["product"];
            
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }


            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ReviewerName, EmailAddress, Rating, Comments")] ProductReview review)
        {
            string spid = Request.QueryString["product"];
            int pid = int.Parse(spid);
            using (ProductsContext db = new ProductsContext())
            {
                DateTime now = DateTime.Now;
                review.ReviewDate = now;
                review.ModifiedDate = now;
                review.ProductID = pid;
                review.Product = db.Products.Where(p => p.ProductID == pid).FirstOrDefault();

                if (ModelState.IsValid)
                {
                    db.ProductReviews.Add(review);
                    db.SaveChanges();
                    return RedirectToAction("Item", new { product = review.ProductID});
                }

                return View(review);
            }
                
        }




    }
}