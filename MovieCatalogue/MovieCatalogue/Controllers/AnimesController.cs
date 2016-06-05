using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieCatalogue.Models;

namespace MovieCatalogue.Controllers
{
    [Authorize]
    public class AnimesController : Controller
    {
        private AnimesDBConetext db = new AnimesDBConetext();

        // GET: /Animes/
        public ActionResult Index()
        {
            return View(db.Animes.ToList());
        }

        // GET: /Animes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animes animes = db.Animes.Find(id);
            if (animes == null)
            {
                return HttpNotFound();
            }
            return View(animes);
        }

        // GET: /Animes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Animes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Title,Genre,Season,Episode")] Animes animes)
        {
            if (ModelState.IsValid)
            {
                db.Animes.Add(animes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(animes);
        }

        // GET: /Animes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animes animes = db.Animes.Find(id);
            if (animes == null)
            {
                return HttpNotFound();
            }
            return View(animes);
        }

        // POST: /Animes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Title,Genre,Season,Episode")] Animes animes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animes);
        }

        // GET: /Animes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animes animes = db.Animes.Find(id);
            if (animes == null)
            {
                return HttpNotFound();
            }
            return View(animes);
        }

        // POST: /Animes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animes animes = db.Animes.Find(id);
            db.Animes.Remove(animes);
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
