using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentDemo.Models;

namespace StudentDemo.Controllers
{
    public class FaculityController : Controller
    {
        private StudentDemoContext db = new StudentDemoContext();

        // GET: Faculity
        public ActionResult Index()
        {
            return View(db.Faculities.ToList());
        }

        // GET: Faculity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculity faculity = db.Faculities.Find(id);
            if (faculity == null)
            {
                return HttpNotFound();
            }
            return View(faculity);
        }

        // GET: Faculity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Faculity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Faculity faculity)
        {
            if (ModelState.IsValid)
            {
                db.Faculities.Add(faculity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(faculity);
        }

        // GET: Faculity/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculity faculity = db.Faculities.Find(id);
            if (faculity == null)
            {
                return HttpNotFound();
            }
            return View(faculity);
        }

        // POST: Faculity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Faculity faculity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faculity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faculity);
        }

        // GET: Faculity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculity faculity = db.Faculities.Find(id);
            if (faculity == null)
            {
                return HttpNotFound();
            }
            return View(faculity);
        }

        // POST: Faculity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faculity faculity = db.Faculities.Find(id);
            db.Faculities.Remove(faculity);
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
