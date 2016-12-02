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
    public class SituacaoController : Controller
    {
        private ISituacaoBLL situacaoBLL = new SituacaoBLL();

        // GET: Situacao
        public ActionResult Index()
        {
            return View(situacaoBLL.Todas().ToList());
        }

        // GET: Situacao/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Situacao situacao = situacaoBLL.ObterPorId(id);
            if (situacao == null)
            {
                return HttpNotFound();
            }
            return View(situacao);
        }

        // GET: Situacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Situacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSituacao,Descricao")] Situacao situacao)
        {
            if (ModelState.IsValid)
            {
                situacaoBLL.Salvar(situacao);
                return RedirectToAction("Index");
            }

            return View(situacao);
        }

        // GET: Situacao/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Situacao situacao = situacaoBLL.ObterPorId(id);
            if (situacao == null)
            {
                return HttpNotFound();
            }
            return View(situacao);
        }

        // POST: Situacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSituacao,Descricao")] Situacao situacao)
        {
            if (ModelState.IsValid)
            {
                situacaoBLL.Salvar(situacao);
                return RedirectToAction("Index");
            }
            return View(situacao);
        }

        // GET: Situacao/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Situacao situacao = situacaoBLL.ObterPorId(id);
            if (situacao == null)
            {
                return HttpNotFound();
            }
            return View(situacao);
        }

        // POST: Situacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            situacaoBLL.Excluir(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                situacaoBLL.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
