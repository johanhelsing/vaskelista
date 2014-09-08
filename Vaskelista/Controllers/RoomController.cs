using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vaskelista.Models;

namespace Vaskelista.Controllers
{
    public class RoomController : BaseController
    {
        private VaskelistaContext db = new VaskelistaContext();

        // GET: /Room/
        public ActionResult Index()
        {
            return View(db.Rooms.Where(s => s.Household.Token == HouseholdToken).ToList());
        }

        // GET: /Room/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null || room.Household.Token != HouseholdToken)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: /Room/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Room/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="RoomId,Name")] Room room)
        {
            room.Household = db.Households.FirstOrDefault(s => s.Token == HouseholdToken);
            ModelState.Clear();
            TryValidateModel(room);
            if (ModelState.IsValid)
            {
                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(room);
        }

        // GET: /Room/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: /Room/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="RoomId,Name")] Room room)
        {
            var household = db.Households.FirstOrDefault(h => h.Token == HouseholdToken);
            if (household == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            room.HouseholdId = household.HouseholdId;
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(room);
        }

        // GET: /Room/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null || room.Household.Token != HouseholdToken)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: /Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = db.Rooms.Find(id);
            if (room == null || room.Household.Token != HouseholdToken)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db.Tasks.RemoveRange(db.Tasks.Where(t => t.RoomId == id));
            db.Rooms.Remove(room);
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
