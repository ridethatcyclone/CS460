using HW5.DAL;
using HW5.Models;
using System.Linq;
using System.Web.Mvc;

namespace HW5.Controllers
{
    public class RequestsController : Controller
    {
        // Create RequestContext item to access db
        private RequestContext db = new RequestContext();

        /// <summary>
        /// Index page displays the already submitted requests
        /// </summary>
        /// <returns>Index view using database</returns>
        public ActionResult Index()
        {
            return View(db.Requests.ToList());
        }

        /// <summary>
        /// Create page displays with a blank form
        /// </summary>
        /// <returns>Create page without any input</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create page posts form fields to databse
        /// </summary>
        /// <param name="request">Binds the form fields to an object to be added to the database</param>
        /// <returns>Redirects to Index if the form was filled out correctly, otherwise simply stays on the page with the current input</returns>
        [HttpPost]
        public ActionResult Create([Bind(Include = "FullName,DateOfBirth,CustomerID,StreetAddress,City,State,ZipCode,County")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(request);
        }
    }
}
