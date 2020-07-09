using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PartyNeighbors.Data;
using PartyNeighbors.Models.Neighborhood;
using PartyNeighbors.Services;

namespace PartyNeighbors.MVC.Controllers
{
    public class NeighborhoodsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private NeighborhoodService _neighborhoodService;
        private Guid _userId;

        // GET: Neighborhoods
        public ActionResult Index()
        {
            var neighborhoods = db.Neighborhoods.Include(n => n.State);
            return View(neighborhoods.ToList());
        }

        // GET: Neighborhoods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighborhood neighborhood = db.Neighborhoods.Find(id);
            if (neighborhood == null)
            {
                return HttpNotFound();
            }
            return View(neighborhood);
        }

        // GET: Neighborhoods/Create
        public ActionResult Create()
        {
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName");
            return View();
        }

        // POST: Neighborhoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NeighborhoodCreate neighborhood)
        {
            if (ModelState.IsValid)
            {
                _userId = Guid.Parse(User.Identity.GetUserId());
                _neighborhoodService = new NeighborhoodService(_userId);
                _neighborhoodService.CreateNeighborhood(neighborhood);
                return RedirectToAction("Index");
            }

            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", neighborhood.StateId);
            return View(neighborhood);
        }

        // GET: Neighborhoods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighborhood neighborhood = db.Neighborhoods.Find(id);
            if (neighborhood == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", neighborhood.StateId);
            return View(neighborhood);
        }

        // POST: Neighborhoods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NeighborhoodEdit neighborhood)
        {
            if (ModelState.IsValid)
            {
                _userId = Guid.Parse(User.Identity.GetUserId());
                _neighborhoodService = new NeighborhoodService(_userId);
                _neighborhoodService.EditNeighborhood(neighborhood);
                return RedirectToAction("Index");
            }
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", neighborhood.StateId);
            return View(neighborhood);
        }

        // GET: Neighborhoods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighborhood neighborhood = db.Neighborhoods.Find(id);
            if (neighborhood == null)
            {
                return HttpNotFound();
            }
            return View(neighborhood);
        }

        // POST: Neighborhoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Neighborhood neighborhood = db.Neighborhoods.Find(id);
            db.Neighborhoods.Remove(neighborhood);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddLocations(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighborhood neighborhood = db.Neighborhoods.Find(id);
            if (neighborhood == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name", neighborhood.LocationId);
            return View(neighborhood);
        }

        [HttpPost]
        public ActionResult AddLocations(NeighborhoodAddLocation locationToAdd)
        {
            if (ModelState.IsValid)
            {
                _userId = Guid.Parse(User.Identity.GetUserId());
                _neighborhoodService = new NeighborhoodService(_userId);
                _neighborhoodService.AddLocation(locationToAdd);
                return RedirectToAction("AddLocations"); // This line is what allows a location to be added without changing the page
            }
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name");
            return View("AddLocations");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
