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
    public class PapelController : Controller
    {
        private IPapelBLL papelBLL = new PapelBLL();

        // GET: Papel
        public ActionResult Index()
        {
            return View(papelBLL.Todas().ToList());
        }

        // GET: Papel/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Papel papel = papelBLL.ObterPorId(id);
            if (papel == null)
            {
                return HttpNotFound();
            }
            return View(papel);
        }

        // GET: Papel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Papel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPapel,Descricao")] Papel papel)
        {
            if (ModelState.IsValid)
            {
                papelBLL.Salvar(papel);
                return RedirectToAction("Index");
            }

            return View(papel);
        }

        // GET: Papel/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Papel papel = papelBLL.ObterPorId(id);
            if (papel == null)
            {
                return HttpNotFound();
            }
            return View(papel);
        }

        // POST: Papel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPapel,Descricao")] Papel papel)
        {
            if (ModelState.IsValid)
            {
                papelBLL.Salvar(papel);
                return RedirectToAction("Index");
            }
            return View(papel);
        }

        // GET: Papel/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Papel papel = papelBLL.ObterPorId(id);
            if (papel == null)
            {
                return HttpNotFound();
            }
            return View(papel);
        }

        // POST: Papel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            papelBLL.Excluir(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                papelBLL.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
