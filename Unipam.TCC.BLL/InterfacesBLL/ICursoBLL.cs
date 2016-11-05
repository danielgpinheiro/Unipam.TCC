using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unipam.TCC.DAL.Entity;

namespace Unipam.TCC.BLL.InterfacesBLL
{
    public interface ICursoBLL
    {
        string Salvar(Curso curso);

        string Excluir(int idCurso);

        IList<Curso> Todas();

        Curso ObterPorId(int idCurso);

        void Dispose();
    }
}
