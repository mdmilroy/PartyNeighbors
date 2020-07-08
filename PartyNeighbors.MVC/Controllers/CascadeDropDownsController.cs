using PartyNeighbors.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyNeighbors.MVC.Controllers
{
    public class CascadeDropDownsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: CascadeDropDowns
        public ActionResult Index()
        {
            List<Neighborhood> NeighborhoodList = db.Neighborhoods.ToList();
            ViewBag.NeighborhoodList = new SelectList(NeighborhoodList, "NeighborhoodId", "Name");
            return View();
        }

        public JsonResult GetLocationsList(int NeighborhoodId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var neighborhood = db.Neighborhoods.Find(NeighborhoodId);
            List<Location> LocationList = neighborhood.Locations.ToList();
            return Json(LocationList, JsonRequestBehavior.AllowGet);
        }
    }
}