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
using PartyNeighbors.Models.Resident;
using PartyNeighbors.Services;

namespace PartyNeighbors.MVC.Controllers
{
    [Authorize]
    public class ResidentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ResidentService _residentService;
        private Guid _userId;

        // GET: Residents
        public ActionResult Index()
        {
            var residents = db.Residents.Include(r => r.Neighborhood);
            return View(residents.ToList());
        }

        // GET: Residents/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resident resident = db.Residents.Find(id);
            if (resident == null)
            {
                return HttpNotFound();
            }
            return View(resident);
        }

        // GET: Residents/Create
        public ActionResult Create()
        {
            ViewBag.NeighborhoodId = new SelectList(db.Neighborhoods, "NeighborhoodId", "Name");
            return View();
        }

        // POST: Residents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResidentCreate resident)
        {
            if (ModelState.IsValid)
            {
                _userId = Guid.Parse(User.Identity.GetUserId());
                _residentService = new ResidentService(_userId);
                _residentService.CreateResident(resident);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.NeighborhoodId = new SelectList(db.Neighborhoods, "NeighborhoodId", "Name", resident.NeighborhoodId);
            return View(resident);
        }

        // GET: Residents/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resident resident = db.Residents.Find(id);
            if (resident == null)
            {
                return HttpNotFound();
            }
            ViewBag.NeighborhoodId = new SelectList(db.Neighborhoods, "NeighborhoodId", "Name", resident.NeighborhoodId);
            return View(resident);
        }

        // POST: Residents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ResidentEdit resident)
        {
            if (ModelState.IsValid)
            {
                _userId = Guid.Parse(User.Identity.GetUserId());
                _residentService = new ResidentService(_userId);
                _residentService.EditResident(resident);
                return RedirectToAction("Index");
            }
            ViewBag.NeighborhoodId = new SelectList(db.Neighborhoods, "NeighborhoodId", "Name", resident.NeighborhoodId);
            return View(resident);
        }

        // GET: Residents/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resident resident = db.Residents.Find(id);
            if (resident == null)
            {
                return HttpNotFound();
            }
            return View(resident);
        }

        // POST: Residents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Resident resident = db.Residents.Find(id);
            db.Residents.Remove(resident);
            db.SaveChanges();
            return RedirectToAction("Index");
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
