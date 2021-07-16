using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Exam.Context;
using Exam.Models;

namespace Exam.Controllers
{
    public class FalcultyController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Falculty
        public ActionResult Index()
        {
            return View(db.Falculties.ToList());
        }

        // GET: Falculty/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Falculty falculty = db.Falculties.Find(id);
            if (falculty == null)
            {
                return HttpNotFound();
            }
            return View(falculty);
        }

        // GET: Falculty/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Falculty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FalcultyID,Name")] Falculty falculty)
        {
            if (ModelState.IsValid)
            {
                db.Falculties.Add(falculty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(falculty);
        }

        // GET: Falculty/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Falculty falculty = db.Falculties.Find(id);
            if (falculty == null)
            {
                return HttpNotFound();
            }
            return View(falculty);
        }

        // POST: Falculty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FalcultyID,Name")] Falculty falculty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(falculty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(falculty);
        }

        // GET: Falculty/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Falculty falculty = db.Falculties.Find(id);
            if (falculty == null)
            {
                return HttpNotFound();
            }
            return View(falculty);
        }

        // POST: Falculty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Falculty falculty = db.Falculties.Find(id);
            db.Falculties.Remove(falculty);
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
