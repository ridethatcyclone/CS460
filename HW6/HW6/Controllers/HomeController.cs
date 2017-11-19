using HW6.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HW6.Controllers
{
    public class HomeController : Controller
    {
        //ProductsContext db = new ProductsContext();
        MenuCategoriesVM menuViewModel = new MenuCategoriesVM();

        //GET Index
        public ActionResult Index()
        {
            /*
            using (ProductsContext db = new ProductsContext())
            {
                var products = db.Products;
                return View(products.ToList());
            }
            */

            /*
            var Cat = new string[db.ProductCategories.Count()];
            for (int i = 0; i < db.ProductCategories.Count(); i++)
            {
                Cat[i] = db.ProductCategories.Where(p => p.ProductCategoryID == i).Select(p => p.Name).FirstOrDefault().ToString();
            }
            ViewBag.Categories = Cat;
            */
            using (ProductsContext db = new ProductsContext())
            {
                var Cat = new string[db.ProductCategories.Count()];
                for (int i = 1; i <= db.ProductCategories.Count(); i++)
                {
                    var x = db.ProductCategories.Where(p => p.ProductCategoryID == i).Select(p => p.Name).FirstOrDefault().ToString();
                    if (x != null) Cat[i - 1] = x;
                }
                ViewBag.Categories = Cat;
                
                for (int i = 1; i < db.ProductCategories.Count(); i++)
                {
                    IList<string> a = new List<string>();
                    foreach (var item in db.ProductSubcategories)
                    {
                        if (db.ProductSubcategories.Select(p => p.ProductSubcategoryID).Equals(i))
                        {
                            a.Add(db.ProductSubcategories.Select(p => p.Name).FirstOrDefault().ToString());
                        }
                    }
                    ViewData[i.ToString()] = a;
                }

                /*
                 * SUBCATEGORIES SETUP:
                 * [KEY: CATEGORY ID]
                 * [VALUE: STRING ARRAY]
                 * FIND NUMBER OF SUBCATEGORIES UNDER ONE IDNUMBER
                 * RUN THROUGH LOOP
                 * 
                 * FOR INT I = 1; 1-4
                 * IF SUBCATEGORY ID == I
                 * ADD TO LIST VIEWBAG[I.TOSTRING]
                 * 
                 * /
            }
            
            /*
            var Subcat = new string[db.ProductSubcategories.Count()];
            for (int i = 0; i < Subcat.Length; i++)
            {
                Subcat[i] = db.ProductSubcategories.Select(p => p.Name).ToString();
            }
            ViewBag.Subcategories = Subcat;
            */

                return View(menuViewModel);
            }

        }

       
    }
}