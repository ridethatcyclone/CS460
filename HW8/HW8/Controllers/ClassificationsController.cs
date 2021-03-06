﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW8.Controllers;

namespace HW8.Views
{
    public class ClassificationsController : Controller
    {
        private ArtInfoContext db = new ArtInfoContext();

        // GET: Classifications
        public ActionResult Index()
        {
            var classifications = db.Classifications.Include(c => c.ArtWork).Include(c => c.Genre);
            return View(classifications.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classification classification = db.Classifications.Find(id);
            if (classification == null)
            {
                return HttpNotFound();
            }
            return View(classification);
        }

    }
}
