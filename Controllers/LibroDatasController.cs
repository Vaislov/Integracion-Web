using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication10.Models;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    public class LibroDatasController : Controller
    {
        private WebApplication12Context db = new WebApplication12Context();

        // GET: LibroDatas
        public ActionResult Index()
        {
            return View(db.LibroDatas.ToList());
        }

        // GET: LibroDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibroData libroData = db.LibroDatas.Find(id);
            if (libroData == null)
            {
                return HttpNotFound();
            }
            return View(libroData);
        }

        // GET: LibroDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibroDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Año,Autor,Cantidad")] LibroData libroData)
        {
            if (ModelState.IsValid)
            {
                db.LibroDatas.Add(libroData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(libroData);
        }

        // GET: LibroDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibroData libroData = db.LibroDatas.Find(id);
            if (libroData == null)
            {
                return HttpNotFound();
            }
            return View(libroData);
        }

        // POST: LibroDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Año,Autor,Cantidad")] LibroData libroData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libroData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(libroData);
        }

        // GET: LibroDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibroData libroData = db.LibroDatas.Find(id);
            if (libroData == null)
            {
                return HttpNotFound();
            }
            return View(libroData);
        }

        // POST: LibroDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LibroData libroData = db.LibroDatas.Find(id);
            db.LibroDatas.Remove(libroData);
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
