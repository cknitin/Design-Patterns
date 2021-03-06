﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentDemo.DAL;
using StudentDemo.Models;

namespace StudentDemo.Controllers
{
    public class FaculityController : Controller
    {
        //private StudentDemoContext db = new StudentDemoContext();

        private UnitOfWork unitofwork = new UnitOfWork();

        // GET: Faculity
        public ActionResult Index()
        {
            //return View(db.Faculities.ToList());
            return View(unitofwork.FaculityRepository.Get());
        }

        // GET: Faculity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Faculity faculity = db.Faculities.Find(id);

            Faculity faculity = unitofwork.FaculityRepository.GetById(id);

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
                //db.Faculities.Add(faculity);
                //db.SaveChanges();
                unitofwork.FaculityRepository.Insert(faculity);
                unitofwork.Save();

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
            //Faculity faculity = db.Faculities.Find(id);

            Faculity faculity = unitofwork.FaculityRepository.GetById(id);
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
                //db.Entry(faculity).State = EntityState.Modified;
                //db.SaveChanges();
                unitofwork.FaculityRepository.Update(faculity);
                unitofwork.Save();

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
            //Faculity faculity = db.Faculities.Find(id);
            Faculity faculity = unitofwork.FaculityRepository.GetById(id);
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
            //Faculity faculity = db.Faculities.Find(id);
            //db.Faculities.Remove(faculity);
            //db.SaveChanges();

            Faculity faculity = unitofwork.FaculityRepository.GetById(id);
            unitofwork.FaculityRepository.Update(faculity);
            unitofwork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                unitofwork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
