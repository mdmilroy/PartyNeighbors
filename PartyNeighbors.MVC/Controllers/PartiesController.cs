using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using PartyNeighbors.Data;
using PartyNeighbors.Models.Party;
using PartyNeighbors.Services;

namespace PartyNeighbors.MVC.Controllers
{
    [Authorize]
    public class PartiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private PartyService _partyService;
        private Guid _userId;
        private Neighborhood neighborhood = new Neighborhood();

        // GET: Parties
        public ActionResult Index()
        {
            var parties = db.Parties;
            return View(parties.ToList());
        }

        // GET: Parties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Party party = db.Parties.Find(id);
            if (party == null)
            {
                return HttpNotFound();
            }
            return View(party);
        }

        // GET: Parties/Details/{id}/GuestList
        public ActionResult Guests(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Party party = db.Parties.Find(id);
            if (party == null)
            {
                return HttpNotFound();
            }
            return View(party.Residents.ToList());
        }

        // GET: Parties/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            ViewBag.NeighborhoodId = new SelectList(db.Neighborhoods, "NeighborhoodId", "Name");
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name");
            return View();
        }

        // POST: Parties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PartyCreate party)
        {
            if (ModelState.IsValid)
            {
                _userId = Guid.Parse(User.Identity.GetUserId());
                _partyService = new PartyService(_userId);
                _partyService.CreateParty(party);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", party.CategoryId);
            ViewBag.NeighborhoodId = new SelectList(db.Neighborhoods, "NeighborhoodId", "Name", party.NeighborhoodId);
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name", party.LocationId);
            return View();
        }

        // GET: Parties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Party party = db.Parties.Find(id);
            if (party == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", party.CategoryId);
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name", party.LocationId);
            ViewBag.NeighborhoodId = new SelectList(db.Neighborhoods, "NeighborhoodId", "Name", party.NeighborhoodId);
            return View(party);
        }

        // POST: Parties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PartyEdit party)
        {
            if (ModelState.IsValid)
            {
                _userId = Guid.Parse(User.Identity.GetUserId());
                _partyService = new PartyService(_userId);
                _partyService.EditParty(party);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", party.CategoryId);
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name", party.LocationId);
            ViewBag.NeighborhoodId = new SelectList(db.Neighborhoods, "NeighborhoodId", "Name", party.NeighborhoodId);
            return View(party);
        }

        // GET: Parties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Party party = db.Parties.Find(id);
            if (party == null)
            {
                return HttpNotFound();
            }
            return View(party);
        }

        // POST: Parties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Party party = db.Parties.Find(id);
            db.Parties.Remove(party);
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
