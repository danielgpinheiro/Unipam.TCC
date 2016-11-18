using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unipam.TCC.BLL.ImplementationBLL;
using Unipam.TCC.BLL.InterfacesBLL;
using Unipam.TCC.DAL.Entity;

namespace Unipam.TCC.Web.Controllers
{
    public class ProfessorController : Controller
    {

        private IProfessorBLL professorBLL;


        public ProfessorController()
        {
            professorBLL = new ProfessorBLL();
        }

        public ActionResult Index()
        {
            var professores = professorBLL.Todas();
            return View(professores);

        }

        // GET: Professor/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professor/Create
        [HttpPost]
        public ActionResult Create(Professor professor)
        {
            var erro = professorBLL.Salvar(professor);
            if (erro == null)
            {
                return RedirectToAction("Index");
            } else
            {
                ModelState.AddModelError("", erro);
                return View();
            }
        }
    }
}