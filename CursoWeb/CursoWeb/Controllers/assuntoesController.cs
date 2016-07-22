using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CursoWeb.Models;

namespace CursoWeb.Controllers
{
    public class assuntoesController : Controller
    {
        private cursomvcEntities db = new cursomvcEntities();

        // GET: assuntoes
        public ActionResult Index()
        {
            return View(db.assunto.ToList());
        }

        // GET: assuntoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            assunto assunto = db.assunto.Find(id);
            if (assunto == null)
            {
                return HttpNotFound();
            }
            return View(assunto);
        }

        // GET: assuntoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: assuntoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssuntoID,DescAssunto")] assunto assunto)
        {
            if (ModelState.IsValid)
            {
                db.assunto.Add(assunto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assunto);
        }

        // GET: assuntoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            assunto assunto = db.assunto.Find(id);
            if (assunto == null)
            {
                return HttpNotFound();
            }
            return View(assunto);
        }

        // POST: assuntoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssuntoID,DescAssunto")] assunto assunto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assunto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assunto);
        }

        // GET: assuntoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            assunto assunto = db.assunto.Find(id);
            if (assunto == null)
            {
                return HttpNotFound();
            }
            return View(assunto);
        }

        // POST: assuntoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            assunto assunto = db.assunto.Find(id);
            db.assunto.Remove(assunto);
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
