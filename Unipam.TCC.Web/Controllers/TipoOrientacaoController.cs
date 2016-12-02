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
    public class TipoOrientacaoController : Controller
    {
        private ITipoOrientacaoBLL tipoOriBLL = new TipoOrientacaoBLL();

        // GET: TipoOrientacao
        public ActionResult Index()
        {
            return View(tipoOriBLL.Todas().ToList());
        }

        // GET: TipoOrientacao/Details/5
        public ActionResult Details(short id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoOrientacao tipoOrientacao = tipoOriBLL.ObterPorId(id);
            if (tipoOrientacao == null)
            {
                return HttpNotFound();
            }
            return View(tipoOrientacao);
        }

        // GET: TipoOrientacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoOrientacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoOrientacao,Descricao")] TipoOrientacao tipoOrientacao)
        {
            if (ModelState.IsValid)
            {
                tipoOriBLL.Salvar(tipoOrientacao);
                return RedirectToAction("Index");
            }

            return View(tipoOrientacao);
        }

        // GET: TipoOrientacao/Edit/5
        public ActionResult Edit(short id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoOrientacao tipoOrientacao = tipoOriBLL.ObterPorId(id);
            if (tipoOrientacao == null)
            {
                return HttpNotFound();
            }
            return View(tipoOrientacao);
        }

        // POST: TipoOrientacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoOrientacao,Descricao")] TipoOrientacao tipoOrientacao)
        {
            if (ModelState.IsValid)
            {
                tipoOriBLL.Salvar(tipoOrientacao);
                return RedirectToAction("Index");
            }
            return View(tipoOrientacao);
        }

        // GET: TipoOrientacao/Delete/5
        public ActionResult Delete(short id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoOrientacao tipoOrientacao = tipoOriBLL.ObterPorId(id);
            if (tipoOrientacao == null)
            {
                return HttpNotFound();
            }
            return View(tipoOrientacao);
        }

        // POST: TipoOrientacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            tipoOriBLL.Excluir(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                tipoOriBLL.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
