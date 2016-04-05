using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimpleCapaApplication.Models;

namespace SimpleCapaApplication.Controllers
{
    public class CapasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Capas
        public ActionResult Index()
        {
            var capas = db.Capas.Include(c => c.Owner);
            return View(capas.ToList());
        }

        // GET: Capas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Capa capa = db.Capas.Find(id);
            if (capa == null)
            {
                return HttpNotFound();
            }
            return View(capa);
        }

        // GET: Capas/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Capas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ApplicationUserId")] Capa capa)
        {
            if (ModelState.IsValid)
            {
                db.Capas.Add(capa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", capa.ApplicationUserId);
            return View(capa);
        }

        // GET: Capas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Capa capa = db.Capas.Find(id);
            if (capa == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", capa.ApplicationUserId);
            return View(capa);
        }

        // POST: Capas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ApplicationUserId")] Capa capa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(capa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", capa.ApplicationUserId);
            return View(capa);
        }

        // GET: Capas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Capa capa = db.Capas.Find(id);
            if (capa == null)
            {
                return HttpNotFound();
            }
            return View(capa);
        }

        // POST: Capas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Capa capa = db.Capas.Find(id);
            db.Capas.Remove(capa);
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
