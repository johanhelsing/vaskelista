using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vaskelista.Models;
using Vaskelista.ViewModels;

namespace Vaskelista.Controllers
{
    public class TaskController : BaseController
    {
        private VaskelistaContext db = new VaskelistaContext();

        // GET: /Task/
        public ActionResult Index()
        {
            var household = db.Households.Where(s=>s.Token == HouseholdToken).FirstOrDefault();
            if (household == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = household.ScheduleElements.Select(s => new TaskIndexViewModel(s)).ToList();
            return View(vm);
        }

        // GET: /Task/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity task = db.Activities.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            if (task.Household.Token != HouseholdToken)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: /Task/Create
        public ActionResult Create()
        {
            ViewBag.RoomList = new SelectList(db.Rooms.Where(r => r.Household.Token == HouseholdToken).ToList(), "RoomId", "Name");
            return View();
        }

        // POST: /Task/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TaskId,Name,Description,Start,RoomId,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday")] TaskCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var activity = new Activity
                {
                    Description = vm.Description,
                    Name = vm.Name,
                    RoomId = vm.RoomId,
                    
                };
                activity.Household = db.Households.FirstOrDefault(s => s.Token == HouseholdToken);
                activity.Household.Activities.Add(activity);
                db.Activities.Add(activity);

                var scheduleElement = new ScheduleElement
                {
                    Start = vm.Start,
                    Days = WeekdayHelpers.FromBooleans(vm.Monday, vm.Tuesday, vm.Wednesday, vm.Thursday, vm.Friday, vm.Saturday, vm.Sunday),
                    Activity = activity
                };
                db.ScheduleElements.Add(scheduleElement);

                activity.Household.ScheduleElements.Add(scheduleElement);
                db.Entry(activity.Household).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: /Task/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleElement scheduleElement = db.ScheduleElements.Find(id);
            if (scheduleElement == null)
            {
                return HttpNotFound();
            }
            if (scheduleElement.Activity.Household.Token != HouseholdToken)
            {
                return HttpNotFound();
            }
            ViewBag.RoomList = new SelectList(db.Rooms.Where(r => r.Household.Token == HouseholdToken).ToList(), "RoomId", "Name");
            return View(new TaskEditViewModel(scheduleElement));
        }

        // POST: /Task/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskId,Name,Description,Start,RoomId,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday")] TaskEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                ScheduleElement scheduleElement = db.ScheduleElements.FirstOrDefault(t => t.ScheduleElementId == vm.ScheduleElementId && t.Activity.Household.Token == HouseholdToken);
                if (scheduleElement == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                vm.ApplyChanges(scheduleElement);
                
                
                db.Entry(scheduleElement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: /Task/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity task = db.Activities.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: /Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity task = db.Activities.Find(id);
            db.Activities.Remove(task);
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
