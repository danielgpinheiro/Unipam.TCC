﻿using System;
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
    public class EntregaController : Controller
    {
        private TCCModel db = new TCCModel();

        // GET: Entrega
        public ActionResult Index()
        {
            var entregas = db.Entregas.Include(e => e.Etapa).Include(e => e.Projeto);
            return View(entregas.ToList());
        }

        // GET: Entrega/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrega entrega = db.Entregas.Find(id);
            if (entrega == null)
            {
                return HttpNotFound();
            }
            return View(entrega);
        }

        // GET: Entrega/Create
        public ActionResult Create()
        {
            ViewBag.IdEtapa = new SelectList(db.Etapas, "IdEtapa", "IdEtapa");
            ViewBag.IdProjeto = new SelectList(db.Projetoes, "IdProjeto", "NomeProjeto");
            return View();
        }

        // POST: Entrega/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEntrega,IdProjeto,IdEtapa,Data")] Entrega entrega)
        {
            if (ModelState.IsValid)
            {
                db.Entregas.Add(entrega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEtapa = new SelectList(db.Etapas, "IdEtapa", "IdEtapa", entrega.IdEtapa);
            ViewBag.IdProjeto = new SelectList(db.Projetoes, "IdProjeto", "NomeProjeto", entrega.IdProjeto);
            return View(entrega);
        }

        // GET: Entrega/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrega entrega = db.Entregas.Find(id);
            if (entrega == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEtapa = new SelectList(db.Etapas, "IdEtapa", "IdEtapa", entrega.IdEtapa);
            ViewBag.IdProjeto = new SelectList(db.Projetoes, "IdProjeto", "NomeProjeto", entrega.IdProjeto);
            return View(entrega);
        }

        // POST: Entrega/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEntrega,IdProjeto,IdEtapa,Data")] Entrega entrega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEtapa = new SelectList(db.Etapas, "IdEtapa", "IdEtapa", entrega.IdEtapa);
            ViewBag.IdProjeto = new SelectList(db.Projetoes, "IdProjeto", "NomeProjeto", entrega.IdProjeto);
            return View(entrega);
        }

        // GET: Entrega/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrega entrega = db.Entregas.Find(id);
            if (entrega == null)
            {
                return HttpNotFound();
            }
            return View(entrega);
        }

        // POST: Entrega/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entrega entrega = db.Entregas.Find(id);
            db.Entregas.Remove(entrega);
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
