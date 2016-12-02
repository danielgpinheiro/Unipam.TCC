using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Unipam.TCC.DAL.Entity;
using Unipam.TCC.BLL.ImplementationBLL;
using Unipam.TCC.BLL.InterfacesBLL;

namespace Unipam.TCC.Web.Controllers
{
    public class NotaController : Controller
    {
 
        private INotaBLL notaBLL = new NotaBLL();
        private IEntregaBLL entregaBLL = new EntregaBLL();

        // GET: Nota
        public ActionResult Index()
        {
            var notas = notaBLL.Todas();
            return View(notas.ToList());
        }

        // GET: Nota/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nota nota = notaBLL.ObterPorId(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            return View(nota);
        }

        // GET: Nota/Create
        public ActionResult Create()
        {
            ViewBag.IdEntrega = new SelectList(entregaBLL.Todas(), "IdEntrega", "IdEntrega");
            return View();
        }

        // POST: Nota/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdNota,IdEntrega,DataAlteracao,Valor,IdUsuario")] Nota nota)
        {
            if (ModelState.IsValid)
            {
                notaBLL.(nota);
                return RedirectToAction("Index");
            }

            ViewBag.IdEntrega = new SelectList(entregaBLL.Todas(), "IdEntrega", "IdEntrega", nota.IdEntrega);
            return View(nota);
        }

        // GET: Nota/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nota nota = notaBLL.ObterPorId(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEntrega = new SelectList(entregaBLL.Todas(), "IdEntrega", "IdEntrega", nota.IdEntrega);
            return View(nota);
        }

        // POST: Nota/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdNota,IdEntrega,DataAlteracao,Valor,IdUsuario")] Nota nota)
        {
            if (ModelState.IsValid)
            {
                notaBLL.Salvar(nota);
                return RedirectToAction("Index");
            }
            ViewBag.IdEntrega = new SelectList(entregaBLL.Todas(), "IdEntrega", "IdEntrega", nota.IdEntrega);
            return View(nota);
        }

        // GET: Nota/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nota nota = db.Notas.Find(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            return View(nota);
        }

        // POST: Nota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nota nota = db.Notas.Find(id);
            db.Notas.Remove(nota);
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
