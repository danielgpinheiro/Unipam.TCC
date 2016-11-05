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
    public class EtapaController : Controller
    {
        private TCCModel db = new TCCModel();

        // GET: Etapa
        public ActionResult Index()
        {
            var etapas = db.Etapas.Include(e => e.TipoEntrega);
            return View(etapas.ToList());
        }

        // GET: Etapa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etapa etapa = db.Etapas.Find(id);
            if (etapa == null)
            {
                return HttpNotFound();
            }
            return View(etapa);
        }

        // GET: Etapa/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoEntrega = new SelectList(db.TipoEntregas, "IdTipoEntrega", "Descricao");
            return View();
        }

        // POST: Etapa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEtapa,IdTipoEntrega,DataInicio,DataFim,NotaMinima")] Etapa etapa)
        {
            if (ModelState.IsValid)
            {
                db.Etapas.Add(etapa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoEntrega = new SelectList(db.TipoEntregas, "IdTipoEntrega", "Descricao", etapa.IdTipoEntrega);
            return View(etapa);
        }

        // GET: Etapa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etapa etapa = db.Etapas.Find(id);
            if (etapa == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoEntrega = new SelectList(db.TipoEntregas, "IdTipoEntrega", "Descricao", etapa.IdTipoEntrega);
            return View(etapa);
        }

        // POST: Etapa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEtapa,IdTipoEntrega,DataInicio,DataFim,NotaMinima")] Etapa etapa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etapa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoEntrega = new SelectList(db.TipoEntregas, "IdTipoEntrega", "Descricao", etapa.IdTipoEntrega);
            return View(etapa);
        }

        // GET: Etapa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etapa etapa = db.Etapas.Find(id);
            if (etapa == null)
            {
                return HttpNotFound();
            }
            return View(etapa);
        }

        // POST: Etapa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etapa etapa = db.Etapas.Find(id);
            db.Etapas.Remove(etapa);
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
