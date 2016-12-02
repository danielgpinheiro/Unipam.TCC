using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Unipam.TCC.BLL.ImplementationBLL;
using Unipam.TCC.BLL.InterfacesBLL;
using Unipam.TCC.DAL.Entity;

namespace Unipam.TCC.Web.Controllers
{
    public class EtapaController : Controller
    {
        private ITipoEntregaBLL tipoEntregaBLL = new TipoEntregaBLL();
        private IEtapaBLL etapaBLL = new EtapaBLL();

        // GET: Etapa
        public ActionResult Index()
        {
            return View(etapaBLL.Todas());
        }

        // GET: Etapa/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etapa etapa = etapaBLL.ObterPorId(id);
            if (etapa == null)
            {
                return HttpNotFound();
            }
            return View(etapa);
        }

        // GET: Etapa/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoEntrega = new SelectList(tipoEntregaBLL.Todos(), "IdTipoEntrega", "Descricao");
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
                etapaBLL.Salvar(etapa);
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoEntrega = new SelectList(tipoEntregaBLL.Todos(), "IdTipoEntrega", "Descricao", etapa.IdTipoEntrega);
            return View(etapa);
        }

        // GET: Etapa/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etapa etapa = etapaBLL.ObterPorId(id);
            if (etapa == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoEntrega = new SelectList(tipoEntregaBLL.Todos(), "IdTipoEntrega", "Descricao", etapa.IdTipoEntrega);
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
                etapaBLL.Salvar(etapa);
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoEntrega = new SelectList(tipoEntregaBLL.Todos(), "IdTipoEntrega", "Descricao", etapa.IdTipoEntrega);
            return View(etapa);
        }

        // GET: Etapa/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etapa etapa = etapaBLL.ObterPorId(id);
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
            Etapa usuario = etapaBLL.ObterPorId(id);
            etapaBLL.Excluir(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                etapaBLL.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
