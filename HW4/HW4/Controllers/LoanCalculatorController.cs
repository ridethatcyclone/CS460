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
                double D = ((Math.Pow(1 + I, TermLength.Value)) - 1) / (I * Math.Pow((1 + I), TermLength.Value));
                double Result = LoanAmount.Value / D;

                // Add to viewbag to be used on the page
                ViewBag.Result = Result.ToString("0.00");
                ViewBag.ShowAnswer = true;
                ViewBag.LoanAmount = LoanAmount.Value.ToString("0.00") ;
                ViewBag.InterestRate = InterestRate.Value;
                ViewBag.TermLength = TermLength.Value;
                ViewBag.TotalAmount = (Result * TermLength.Value).ToString("0.00");
            }
            return View();
        }
    }
}