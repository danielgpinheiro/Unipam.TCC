using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unipam.TCC.DAL.Entity;

namespace Unipam.TCC.BLL.InterfacesBLL
{
    public interface IProfessorBLL
    {

        string Salvar(Professor etapa);

        string Excluir(int idProfessor);

        IList<Professor> Todas();

        Professor ObterPorId(int idProfessor);

        void Dispose();
    }
}
