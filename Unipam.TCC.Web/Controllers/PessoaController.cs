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
    public class PessoaController : Controller
    {
        private IPessoaBLL pessoaBLL = new PessoaBLL();
        private IAlunoBLL alunoBLL = new AlunoBLL();
        private IProfessorBLL professorBLL = new ProfessorBLL();
        private IUsuarioBLL usuarioBLL = new UsuarioBLL();

        // GET: Pessoa
        public ActionResult Index()
        {
            var pessoas = pessoaBLL.Todas();
            return View(pessoas.ToList());
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = pessoaBLL.ObterPorId(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            ViewBag.IdAluno = new SelectList(alunoBLL.Todas(), "IdPessoa", "IdPessoa");
            ViewBag.IdPessoa = new SelectList(pessoaBLL.Todas(), "IdPessoa", "IdPessoa");
            ViewBag.IdUsuario = new SelectList(usuarioBLL.Todas(), "IdUsuario", "NomeUsuario");
            return View();
        }

        // POST: Pessoa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPessoa,IdUsuario,Nome")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoaBLL.Salvar(pessoa);
                return RedirectToAction("Index");
            }

            ViewBag.IdPessoa = new SelectList(pessoaBLL.Todas(), "IdPessoa", "IdPessoa", pessoa.IdPessoa);
            ViewBag.IdUsuario = new SelectList(usuarioBLL.Todas(), "IdUsuario", "NomeUsuario", pessoa.IdUsuario);
            return View(pessoa);
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = pessoaBLL.ObterPorId(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPessoa = new SelectList(pessoaBLL.Todas(), "IdPessoa", "IdPessoa", pessoa.IdPessoa);
            ViewBag.IdUsuario = new SelectList(usuarioBLL.Todas(), "IdUsuario", "NomeUsuario", pessoa.IdUsuario);
            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPessoa,IdUsuario,Nome")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoaBLL.Salvar(pessoa);
                return RedirectToAction("Index");
            }
            ViewBag.IdPessoa = new SelectList(pessoaBLL.Todas(), "IdPessoa", "IdPessoa", pessoa.IdPessoa);
            ViewBag.IdUsuario = new SelectList(usuarioBLL.Todas(), "IdUsuario", "NomeUsuario", pessoa.IdUsuario);
            return View(pessoa);
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = pessoaBLL.ObterPorId(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pessoaBLL.Excluir(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pessoaBLL.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
