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
    public class TestController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Test
        public ActionResult Index()
        {
            var tests = db.Tests.Include(t => t.Classroom).Include(t => t.ExamSubject).Include(t => t.Falculty).Include(t => t.Status);
            return View(tests.ToList());
        }

        // GET: Test/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            ViewBag.ClassroomID = new SelectList(db.Classrooms, "ClassroomID", "Name");
            ViewBag.ExamSubjectID = new SelectList(db.ExamSubjects, "ExamSubjectID", "Name");
            ViewBag.FalcultyID = new SelectList(db.Falculties, "FalcultyID", "Name");
            ViewBag.StatusID = new SelectList(db.Status, "Id", "StatusName");
            return View();
        }

        // POST: Test/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Starttime,ExamDate,ExamDur,ClassroomID,ExamSubjectID,FalcultyID,StatusID")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Tests.Add(test);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassroomID = new SelectList(db.Classrooms, "ClassroomID", "Name", test.ClassroomID);
            ViewBag.ExamSubjectID = new SelectList(db.ExamSubjects, "ExamSubjectID", "Name", test.ExamSubjectID);
            ViewBag.FalcultyID = new SelectList(db.Falculties, "FalcultyID", "Name", test.FalcultyID);
            ViewBag.StatusID = new SelectList(db.Status, "Id", "StatusName", test.StatusID);
            return View(test);
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassroomID = new SelectList(db.Classrooms, "ClassroomID", "Name", test.ClassroomID);
            ViewBag.ExamSubjectID = new SelectList(db.ExamSubjects, "ExamSubjectID", "Name", test.ExamSubjectID);
            ViewBag.FalcultyID = new SelectList(db.Falculties, "FalcultyID", "Name", test.FalcultyID);
            ViewBag.StatusID = new SelectList(db.Status, "Id", "StatusName", test.StatusID);
            return View(test);
        }

        // POST: Test/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Starttime,ExamDate,ExamDur,ClassroomID,ExamSubjectID,FalcultyID,StatusID")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassroomID = new SelectList(db.Classrooms, "ClassroomID", "Name", test.ClassroomID);
            ViewBag.ExamSubjectID = new SelectList(db.ExamSubjects, "ExamSubjectID", "Name", test.ExamSubjectID);
            ViewBag.FalcultyID = new SelectList(db.Falculties, "FalcultyID", "Name", test.FalcultyID);
            ViewBag.StatusID = new SelectList(db.Status, "Id", "StatusName", test.StatusID);
            return View(test);
        }

        // GET: Test/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test test = db.Tests.Find(id);
            db.Tests.Remove(test);
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
