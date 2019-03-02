using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Users.Models; 

namespace Users.Controllers
{
    public class CourseStudentsController : Controller
    {
        private ManageUser db = new ManageUser();

        // GET: CourseStudents
        public ActionResult Index()
        {
            return View(db.CourseStudents.ToList());
        }

        // GET: CourseStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseStudents courseStudents = db.CourseStudents.Find(id);
            if (courseStudents == null)
            {
                return HttpNotFound();
            }
            return View(courseStudents);
        }

        // GET: CourseStudents/Create
        // JEG SKAL HAVE COURSES IND I MODELLEN, SÅ JEG KAN VÆLGE ET KURSUS I EN DROPDOWN MENU I VIEW'ET. sE I ITUCATION PROJEKTET, 
        // HVORDAN DE TO MODELLER KÆDES SAMMEN
        public ActionResult Create(string Id)
        {
            ViewBag.Student = (from s in db.AspNetUsers
                           where s.Id == Id
                           select s);
            return View();
        }

        // POST: CourseStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,CourseID")] CourseStudents courseStudents)
        {
            if (ModelState.IsValid)
            {
                db.CourseStudents.Add(courseStudents);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseStudents);
        }

        // GET: CourseStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseStudents courseStudents = db.CourseStudents.Find(id);
            if (courseStudents == null)
            {
                return HttpNotFound();
            }
            return View(courseStudents);
        }

        // POST: CourseStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,CourseID")] CourseStudents courseStudents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseStudents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseStudents);
        }

        // GET: CourseStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseStudents courseStudents = db.CourseStudents.Find(id);
            if (courseStudents == null)
            {
                return HttpNotFound();
            }
            return View(courseStudents);
        }

        // POST: CourseStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseStudents courseStudents = db.CourseStudents.Find(id);
            db.CourseStudents.Remove(courseStudents);
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
