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
    public class AlunoController : Controller
    {
        private IAlunoBLL alunoBLL = new AlunoBLL();
        private ICursoBLL cursoBLL = new CursoBLL();
        private IPessoaBLL pessoaBLL = new PessoaBLL();

        // GET: Aluno
        public ActionResult Index()
        {
            var alunoes = alunoBLL.Todas();
            return View(alunoes.ToList());
        }

        // GET: Aluno/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = alunoBLL.ObterPorId(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            ViewBag.IdCurso = new SelectList(cursoBLL.Todas(), "IdCurso", "NomeCurso");
            ViewBag.IdPessoa = new SelectList(pessoaBLL.Todas(), "IdPessoa", "Nome");
            return View();
        }

        // POST: Aluno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPessoa,IdCurso")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                alunoBLL.Salvar(aluno);
                return RedirectToAction("Index");
            }

            ViewBag.IdCurso = new SelectList(cursoBLL.Todas(), "IdCurso", "NomeCurso", aluno.IdCurso);
            ViewBag.IdPessoa = new SelectList(pessoaBLL.Todas(), "IdPessoa", "Nome", aluno.IdPessoa);
            return View(aluno);
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = alunoBLL.ObterPorId(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCurso = new SelectList(cursoBLL.Todas(), "IdCurso", "NomeCurso", aluno.IdCurso);
            ViewBag.IdPessoa = new SelectList(pessoaBLL.Todas(), "IdPessoa", "Nome", aluno.IdPessoa);
            return View(aluno);
        }

        // POST: Aluno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPessoa,IdCurso")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                alunoBLL.Salvar(aluno);
                return RedirectToAction("Index");
            }
            ViewBag.IdCurso = new SelectList(cursoBLL.Todas(), "IdCurso", "NomeCurso", aluno.IdCurso);
            ViewBag.IdPessoa = new SelectList(pessoaBLL.Todas(), "IdPessoa", "Nome", aluno.IdPessoa);
            return View(aluno);
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = alunoBLL.ObterPorId(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            alunoBLL.Excluir(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                alunoBLL.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
