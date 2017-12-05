using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalExam.Controllers
{
    public class HomeController : Controller
    {
        private AntiquesDBContext db = new AntiquesDBContext();

        public ActionResult Index()
        {
            return View();
        }

        // GET: Bids/Create
        public ActionResult AddBid()
        {
            ViewBag.BuyerID = new SelectList(db.Buyers, "BuyerID", "Name");
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name");
            return View();
        }

        // POST: Bids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBid([Bind(Include = "BidID,ItemID,BuyerID,Price")] Bid bid)
        {
            bid.Timestamp = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Bids.Add(bid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BuyerID = new SelectList(db.Buyers, "BuyerID", "Name", bid.BuyerID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", bid.ItemID);
            return View(bid);
        }

    }
}