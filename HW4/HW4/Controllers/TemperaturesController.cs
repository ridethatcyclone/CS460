using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW4.Controllers
{
    public class TemperaturesController : Controller
    {
        // GET: Temperatures
        public ActionResult Conversion()
        {
            string num = Request.QueryString["num"];
            string type = Request.QueryString["type"];
            double f, c, k;

            ViewBag.num = num;
            ViewBag.type = type;

            if (!String.IsNullOrEmpty(num))
            {
                if (type.StartsWith("f"))
                {
                    ViewBag.f = Convert.ToDouble(num);
                    ViewBag.c = (ViewBag.f - 32) * 5 / 9;
                    ViewBag.k = ViewBag.c + 273.15;
                    return View("Result");
                }

                else if (type[0] == 'c')
                {
                    ViewBag.c = Convert.ToDouble(num);
                    ViewBag.f = (ViewBag.c * 9 / 5) + 32;
                    ViewBag.k = ViewBag.c + 273.15;
                    return View("Result");
                }

                else if (type[0] == 'k')
                {
                    ViewBag.k = Convert.ToDouble(num);
                    ViewBag.c = ViewBag.k - 273.15;
                    ViewBag.f = (ViewBag.c * 9 / 5) + 32;
                    return View("Result");
                }

                else
                {
                    ViewBag.ErrorMessage("Invalid input");
                    return View();
                }

            }
            

            return View();
            
        }

        

    }
}