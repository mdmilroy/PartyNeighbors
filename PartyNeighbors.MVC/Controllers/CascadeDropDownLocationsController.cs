using PartyNeighbors.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyNeighbors.MVC.Controllers
{
    public class CascadeDropDownLocationsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public JsonResult GetLocationsList(int neighborhoodId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Neighborhood neighborhood = db.Neighborhoods.Find(neighborhoodId);
            List<Location> LocationsList = neighborhood.Locations.ToList();
            return Json(LocationsList, JsonRequestBehavior.AllowGet);
        }
    }
}