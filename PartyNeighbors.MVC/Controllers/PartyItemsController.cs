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
using PartyNeighbors.Models.PartyItem;
using PartyNeighbors.Services;

namespace PartyNeighbors.MVC.Controllers
{
    public class PartyItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private PartyItemService _partyItemService;
        private Guid _userId;


        // GET: PartyItems
        public ActionResult Index()
        {
            return View(db.PartyItems.ToList());
        }

        // GET: PartyItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyItem partyItem = db.PartyItems.Find(id);
            if (partyItem == null)
            {
                return HttpNotFound();
            }
            return View(partyItem);
        }

        // GET: PartyItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartyItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PartyItemCreate partyItem)
        {
            if (ModelState.IsValid)
            {
                _userId = Guid.Parse(User.Identity.GetUserId());
                _partyItemService = new PartyItemService(_userId);
                _partyItemService.CreatePartyItem(partyItem);
                return RedirectToAction("Index");
            }

            return View(partyItem);
        }

        // GET: PartyItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyItem partyItem = db.PartyItems.Find(id);
            if (partyItem == null)
            {
                return HttpNotFound();
            }
            return View(partyItem);
        }

        // POST: PartyItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PartyItemEdit partyItem)
        {
            if (ModelState.IsValid)
            {
                _userId = Guid.Parse(User.Identity.GetUserId());
                _partyItemService = new PartyItemService(_userId);
                _partyItemService.EditPartyItem(partyItem);
                return RedirectToAction("Index");
            }
            return View(partyItem);
        }

        // GET: PartyItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyItem partyItem = db.PartyItems.Find(id);
            if (partyItem == null)
            {
                return HttpNotFound();
            }
            return View(partyItem);
        }

        // POST: PartyItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartyItem partyItem = db.PartyItems.Find(id);
            db.PartyItems.Remove(partyItem);
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
