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
    public class ProfessorController : Controller
    {
        private IProfessorBLL professorBLL = new ProfessorBLL();
        private IPessoaBLL pessoaBLL = new PessoaBLL();

        // GET: Professor
        public ActionResult Index()
        {
            var professors = professorBLL.Todas();
            return View(professors.ToList());
        }

        // GET: Professor/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = professorBLL.ObterPorId(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // GET: Professor/Create
        public ActionResult Create()
        {
            ViewBag.IdPessoa = new SelectList(pessoaBLL.Todas(), "IdPessoa", "Nome");
            return View();
        }

        // POST: Professor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPessoa")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                professorBLL.Salvar(professor);
                return RedirectToAction("Index");
            }

            ViewBag.IdPessoa = new SelectList(pessoaBLL.Todas(), "IdPessoa", "Nome", professor.IdPessoa);
            return View(professor);
        }

        // GET: Professor/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = professorBLL.ObterPorId(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPessoa = new SelectList(pessoaBLL.Todas(), "IdPessoa", "Nome", professor.IdPessoa);
            return View(professor);
        }

        // POST: Professor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPessoa")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                professorBLL.Salvar(professor);
                return RedirectToAction("Index");
            }
            ViewBag.IdPessoa = new SelectList(pessoaBLL.Todas(), "IdPessoa", "Nome", professor.IdPessoa);
            return View(professor);
        }

        // GET: Professor/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = professorBLL.ObterPorId(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // POST: Professor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            professorBLL.Excluir(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                professorBLL.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
