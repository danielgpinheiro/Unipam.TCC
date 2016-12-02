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
using Unipam.TCC.BLL.InterfaceBLL;

namespace Unipam.TCC.Web.Controllers
{
    public class ProjetoController : Controller
    {
        private IProjetoBLL projetoBLL = new ProjetoBLL();
        private IAlunoBLL alunoBLL = new AlunoBLL();

        // GET: Projeto
        public ActionResult Index()
        {
            var projetoes = projetoBLL.Todos();
            return View(projetoes.ToList());
        }

        // GET: Projeto/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projeto projeto = projetoBLL.Obter(id);
            if (projeto == null)
            {
                return HttpNotFound();
            }
            return View(projeto);
        }

        // GET: Projeto/Create
        public ActionResult Create()
        {
            ViewBag.IdPessoaAluno = new SelectList(alunoBLL.Todas(), "IdPessoa", "IdPessoa");
            return View();
        }

        // POST: Projeto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProjeto,NomeProjeto,NotaProjeto,IdPessoaAluno")] Projeto projeto)
        {
            if (ModelState.IsValid)
            {
                projetoBLL.Salvar(projeto);
                return RedirectToAction("Index");
            }

            ViewBag.IdPessoaAluno = new SelectList(alunoBLL.Todas(), "IdPessoa", "IdPessoa", projeto.IdPessoaAluno);
            return View(projeto);
        }

        // GET: Projeto/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projeto projeto = projetoBLL.Obter(id);
            if (projeto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPessoaAluno = new SelectList(alunoBLL.Todas(), "IdPessoa", "IdPessoa", projeto.IdPessoaAluno);
            return View(projeto);
        }

        // POST: Projeto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProjeto,NomeProjeto,NotaProjeto,IdPessoaAluno")] Projeto projeto)
        {
            if (ModelState.IsValid)
            {
                projetoBLL.Salvar(projeto);
                return RedirectToAction("Index");
            }
            ViewBag.IdPessoaAluno = new SelectList(alunoBLL.Todas(), "IdPessoa", "IdPessoa", projeto.IdPessoaAluno);
            return View(projeto);
        }

        // GET: Projeto/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projeto projeto = projetoBLL.Obter(id);
            if (projeto == null)
            {
                return HttpNotFound();
            }
            return View(projeto);
        }

        // POST: Projeto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            projetoBLL.Excluir(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                projetoBLL.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
