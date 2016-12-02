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
    public class SituacaoProjetoController : Controller
    {
        private TCCModel db = new TCCModel();

        // GET: SituacaoProjeto
        public ActionResult Index()
        {
            var situacaoProjetoes = db.SituacaoProjetoes.Include(s => s.Projeto).Include(s => s.Situacao);
            return View(situacaoProjetoes.ToList());
        }

        // GET: SituacaoProjeto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SituacaoProjeto situacaoProjeto = db.SituacaoProjetoes.Find(id);
            if (situacaoProjeto == null)
            {
                return HttpNotFound();
            }
            return View(situacaoProjeto);
        }

        // GET: SituacaoProjeto/Create
        public ActionResult Create()
        {
            ViewBag.IdProjeto = new SelectList(db.Projetoes, "IdProjeto", "NomeProjeto");
            ViewBag.IdSituacao = new SelectList(db.Situacaos, "IdSituacao", "Descricao");
            return View();
        }

        // POST: SituacaoProjeto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProjeto,IdSituacao,DataAlteracao")] SituacaoProjeto situacaoProjeto)
        {
            if (ModelState.IsValid)
            {
                db.SituacaoProjetoes.Add(situacaoProjeto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProjeto = new SelectList(db.Projetoes, "IdProjeto", "NomeProjeto", situacaoProjeto.IdProjeto);
            ViewBag.IdSituacao = new SelectList(db.Situacaos, "IdSituacao", "Descricao", situacaoProjeto.IdSituacao);
            return View(situacaoProjeto);
        }

        // GET: SituacaoProjeto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SituacaoProjeto situacaoProjeto = db.SituacaoProjetoes.Find(id);
            if (situacaoProjeto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProjeto = new SelectList(db.Projetoes, "IdProjeto", "NomeProjeto", situacaoProjeto.IdProjeto);
            ViewBag.IdSituacao = new SelectList(db.Situacaos, "IdSituacao", "Descricao", situacaoProjeto.IdSituacao);
            return View(situacaoProjeto);
        }

        // POST: SituacaoProjeto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProjeto,IdSituacao,DataAlteracao")] SituacaoProjeto situacaoProjeto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(situacaoProjeto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProjeto = new SelectList(db.Projetoes, "IdProjeto", "NomeProjeto", situacaoProjeto.IdProjeto);
            ViewBag.IdSituacao = new SelectList(db.Situacaos, "IdSituacao", "Descricao", situacaoProjeto.IdSituacao);
            return View(situacaoProjeto);
        }

        // GET: SituacaoProjeto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SituacaoProjeto situacaoProjeto = db.SituacaoProjetoes.Find(id);
            if (situacaoProjeto == null)
            {
                return HttpNotFound();
            }
            return View(situacaoProjeto);
        }

        // POST: SituacaoProjeto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SituacaoProjeto situacaoProjeto = db.SituacaoProjetoes.Find(id);
            db.SituacaoProjetoes.Remove(situacaoProjeto);
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
