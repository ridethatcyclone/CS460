using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW4.Controllers
{
    public class LoanCalculatorController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ShowAnswer = false;
            return View();
        }

        [HttpPost]
        public ActionResult Index(double? LoanAmount, double? InterestRate, double? TermLength)
        {
            if (LoanAmount == null || InterestRate == null || TermLength == null)
            {
                ViewBag.ErrorMessage = "Inputs aren't valid. Please fill out all fields";
                ViewBag.ShowAnswer = false;
            }
            else
            {
                // Calculations
                double IR = InterestRate.Value / 100;
                double I = IR / 12;
                double D = ((Math.Pow(1 + I, 360)) - 1) / (I * Math.Pow((1 + I), 360));
                double Result = LoanAmount.Value / D;

                // Add to viewbag to be used on the page
                ViewBag.Result = Result.ToString("0.##");
                ViewBag.ShowAnswer = true;
                ViewBag.LoanAmount = LoanAmount.Value.ToString("0.##") ;
                ViewBag.InterestRate = InterestRate.Value;
                ViewBag.TermLength = TermLength.Value;
                ViewBag.TotalAmount = (LoanAmount.Value + (LoanAmount.Value * I)).ToString("0.##");
            }
            return View();
        }
    }
}