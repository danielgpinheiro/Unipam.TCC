using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unipam.TCC.BLL.InterfacesBLL;
using Unipam.TCC.DAL.Entity;
using Unipam.TCC.DAL.ImplementationRepository;
using Unipam.TCC.DAL.InterfaceRepository;

namespace Unipam.TCC.BLL.ImplementationBLL
{
    public class CursoBLL : ICursoBLL
    {
        private readonly ICursoRepository CursoRepository;

        public CursoBLL()
        {
            this.CursoRepository = new CursoRepository();
        }

        public CursoBLL(ICursoRepository CursoRepository)
        {
            this.CursoRepository = CursoRepository;
        }

        public void Dispose()
        {
            CursoRepository.Dispose();
        }

        public string Excluir(int idCurso)
        {
            try
            {
                Curso curso = ObterPorId(idCurso);
                CursoRepository.Excluir(curso);
                CursoRepository.SalvarAlteracoes();
                return null;
            }
            catch (Exception ex)
            {
                return "Erro:" + ex.Message;
            }
        }

        public Curso ObterPorId(int idCurso)
        {
            return CursoRepository.Obter(x => x.IdCurso == idCurso);
        }

        public string Salvar(Curso curso)
        {
            try
            {
                if (curso.IdCurso == 0)
                {
                    CursoRepository.Adicionar(curso);
                }
                else
                {
                    CursoRepository.Alterar(curso);
                }

                CursoRepository.SalvarAlteracoes();

                return null;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IList<Curso> Todas()
        {
            return CursoRepository.Todos().ToList();
        }
    }
}
