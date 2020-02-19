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
    public class SedeDatasController : Controller
    {
        private WebApplication12Context db = new WebApplication12Context();

        // GET: SedeDatas
        public ActionResult Index()
        {
            return View(db.SedeDatas.ToList());
        }

        // GET: SedeDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SedeData sedeData = db.SedeDatas.Find(id);
            if (sedeData == null)
            {
                return HttpNotFound();
            }
            return View(sedeData);
        }

        // GET: SedeDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SedeDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Direccion,Telefono")] SedeData sedeData)
        {
            if (ModelState.IsValid)
            {
                db.SedeDatas.Add(sedeData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sedeData);
        }

        // GET: SedeDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SedeData sedeData = db.SedeDatas.Find(id);
            if (sedeData == null)
            {
                return HttpNotFound();
            }
            return View(sedeData);
        }

        // POST: SedeDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Direccion,Telefono")] SedeData sedeData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sedeData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sedeData);
        }

        // GET: SedeDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SedeData sedeData = db.SedeDatas.Find(id);
            if (sedeData == null)
            {
                return HttpNotFound();
            }
            return View(sedeData);
        }

        // POST: SedeDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SedeData sedeData = db.SedeDatas.Find(id);
            db.SedeDatas.Remove(sedeData);
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
