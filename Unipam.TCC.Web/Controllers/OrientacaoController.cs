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
    public class OrientacaoController : Controller
    {
        private TCCModel db = new TCCModel();

        // GET: Orientacao
        public ActionResult Index()
        {
            var orientacaos = db.Orientacaos.Include(o => o.Professor).Include(o => o.Projeto).Include(o => o.TipoOrientacao);
            return View(orientacaos.ToList());
        }

        // GET: Orientacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orientacao orientacao = db.Orientacaos.Find(id);
            if (orientacao == null)
            {
                return HttpNotFound();
            }
            return View(orientacao);
        }

        // GET: Orientacao/Create
        public ActionResult Create()
        {
            ViewBag.IdPessoa = new SelectList(db.Professors, "IdPessoa", "IdPessoa");
            ViewBag.IdProjeto = new SelectList(db.Projetoes, "IdProjeto", "NomeProjeto");
            ViewBag.IdTipoOrientacao = new SelectList(db.TipoOrientacaos, "IdTipoOrientacao", "Descricao");
            return View();
        }

        // POST: Orientacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPessoa,IdTipoOrientacao,IdProjeto,Data")] Orientacao orientacao)
        {
            if (ModelState.IsValid)
            {
                db.Orientacaos.Add(orientacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPessoa = new SelectList(db.Professors, "IdPessoa", "IdPessoa", orientacao.IdPessoa);
            ViewBag.IdProjeto = new SelectList(db.Projetoes, "IdProjeto", "NomeProjeto", orientacao.IdProjeto);
            ViewBag.IdTipoOrientacao = new SelectList(db.TipoOrientacaos, "IdTipoOrientacao", "Descricao", orientacao.IdTipoOrientacao);
            return View(orientacao);
        }

        // GET: Orientacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orientacao orientacao = db.Orientacaos.Find(id);
            if (orientacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPessoa = new SelectList(db.Professors, "IdPessoa", "IdPessoa", orientacao.IdPessoa);
            ViewBag.IdProjeto = new SelectList(db.Projetoes, "IdProjeto", "NomeProjeto", orientacao.IdProjeto);
            ViewBag.IdTipoOrientacao = new SelectList(db.TipoOrientacaos, "IdTipoOrientacao", "Descricao", orientacao.IdTipoOrientacao);
            return View(orientacao);
        }

        // POST: Orientacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPessoa,IdTipoOrientacao,IdProjeto,Data")] Orientacao orientacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orientacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPessoa = new SelectList(db.Professors, "IdPessoa", "IdPessoa", orientacao.IdPessoa);
            ViewBag.IdProjeto = new SelectList(db.Projetoes, "IdProjeto", "NomeProjeto", orientacao.IdProjeto);
            ViewBag.IdTipoOrientacao = new SelectList(db.TipoOrientacaos, "IdTipoOrientacao", "Descricao", orientacao.IdTipoOrientacao);
            return View(orientacao);
        }

        // GET: Orientacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orientacao orientacao = db.Orientacaos.Find(id);
            if (orientacao == null)
            {
                return HttpNotFound();
            }
            return View(orientacao);
        }

        // POST: Orientacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orientacao orientacao = db.Orientacaos.Find(id);
            db.Orientacaos.Remove(orientacao);
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
