using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Unipam.TCC.DAL.Entity;

namespace Unipam.TCC.Web.Controllers
{
    public class TipoEntregaController : Controller
    {
        private TCCModel db = new TCCModel();

        // GET: TipoEntrega
        public ActionResult Index()
        {
            return View(db.TipoEntregas.ToList());
        }

        // GET: TipoEntrega/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEntrega tipoEntrega = db.TipoEntregas.Find(id);
            if (tipoEntrega == null)
            {
                return HttpNotFound();
            }
            return View(tipoEntrega);
        }

        // GET: TipoEntrega/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEntrega/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoEntrega,Descricao")] TipoEntrega tipoEntrega)
        {
            if (ModelState.IsValid)
            {
                db.TipoEntregas.Add(tipoEntrega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoEntrega);
        }

        // GET: TipoEntrega/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEntrega tipoEntrega = db.TipoEntregas.Find(id);
            if (tipoEntrega == null)
            {
                return HttpNotFound();
            }
            return View(tipoEntrega);
        }

        // POST: TipoEntrega/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoEntrega,Descricao")] TipoEntrega tipoEntrega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEntrega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoEntrega);
        }

        // GET: TipoEntrega/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEntrega tipoEntrega = db.TipoEntregas.Find(id);
            if (tipoEntrega == null)
            {
                return HttpNotFound();
            }
            return View(tipoEntrega);
        }

        // POST: TipoEntrega/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEntrega tipoEntrega = db.TipoEntregas.Find(id);
            db.TipoEntregas.Remove(tipoEntrega);
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
