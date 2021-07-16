﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PRATICAL_WAD.Context;
using PRATICAL_WAD.Models;

namespace PRATICAL_WAD.Controllers
{
    public class ExamsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Exams
        public ActionResult Index()
        {
            var exams = db.Exams.Include(e => e.ClassRoom).Include(e => e.ExamSubject).Include(e => e.Faculty);
            return View(exams.ToList());
        }

        // GET: Exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Exams/Create
        public ActionResult Create()
        {
            ViewBag.ClassroomId = new SelectList(db.Classrooms, "Id", "ClassroomName");
            ViewBag.ExamSubjectId = new SelectList(db.ExamSubjects, "Id", "facultyName");
            ViewBag.FacultyId = new SelectList(db.Faculties, "Id", "facultyName");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ExamSubjectId,FacultyId,ClassroomId,StartTime,ExamDate,Status,Duration")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassroomId = new SelectList(db.Classrooms, "Id", "ClassroomName", exam.ClassroomId);
            ViewBag.ExamSubjectId = new SelectList(db.ExamSubjects, "Id", "facultyName", exam.ExamSubjectId);
            ViewBag.FacultyId = new SelectList(db.Faculties, "Id", "facultyName", exam.FacultyId);
            return View(exam);
        }

        // GET: Exams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassroomId = new SelectList(db.Classrooms, "Id", "ClassroomName", exam.ClassroomId);
            ViewBag.ExamSubjectId = new SelectList(db.ExamSubjects, "Id", "facultyName", exam.ExamSubjectId);
            ViewBag.FacultyId = new SelectList(db.Faculties, "Id", "facultyName", exam.FacultyId);
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ExamSubjectId,FacultyId,ClassroomId,StartTime,ExamDate,Status,Duration")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassroomId = new SelectList(db.Classrooms, "Id", "ClassroomName", exam.ClassroomId);
            ViewBag.ExamSubjectId = new SelectList(db.ExamSubjects, "Id", "facultyName", exam.ExamSubjectId);
            ViewBag.FacultyId = new SelectList(db.Faculties, "Id", "facultyName", exam.FacultyId);
            return View(exam);
        }

        // GET: Exams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = db.Exams.Find(id);
            db.Exams.Remove(exam);
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
